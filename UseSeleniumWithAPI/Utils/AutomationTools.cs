//using Microsoft.AspNetCore.Mvc.ApplicationModels;
using OpenQA.Selenium;
using UseSeleniumWithAPI.Models;


namespace UseSeleniumWithAPI.Utils
{
    public class AutomationTools
    {
        private readonly IWebDriver driver;

        public AutomationTools(IWebDriver _driver)
        {
            driver = _driver;

        }
        public async Task<AutomationResult> GoWebsite(string url)
        {


            if (!(url.StartsWith("http://") || url.StartsWith("https://")))
            {
                Console.WriteLine("The URL must start with 'http://' or 'https://'.");
                return new AutomationResult
                {
                    Success = false,
                    ErrorMessage = "The URL must start with 'http://' or 'https://'."
                };
            }
            else if (!string.IsNullOrEmpty(url))
            {
                driver.Navigate().GoToUrl(url);
                await Task.Delay(1500);
                Console.WriteLine($"Navigated to {url}");
                return new AutomationResult
                {
                    Success = true,
                    ErrorMessage = "",
                    Data = new { text = $"Navigated to {url}" }
                };

            }
            else
            {




                Console.WriteLine("URL is empty or null.");
                return new AutomationResult
                {
                    Success = false,
                    ErrorMessage = "URL is empty or null."
                };
            }

        }

        public async Task<AutomationResult> SearchElements(ActionModel action)
        {
            var selector = action.selector;
            var operation = action.Operation;

            if (string.IsNullOrEmpty(operation) || string.IsNullOrEmpty(selector))
            {
                return new AutomationResult
                {
                    Success = false,
                    ErrorMessage = "CssSelector or Operation Missing."
                };
            }


            //var elements = driver.FindElements(By.CssSelector(cssSelector));
            var elements = driver.FindElements(By.CssSelector(selector));



            if (elements.Count == 0)
            {
                return new AutomationResult
                {
                    Success = false,
                    ErrorMessage = "Elements not Found"
                };
            }


            List<object> extractedTexts = new List<object>();

            //Console.WriteLine("Search Element text: ", elements.Text);

            foreach (var element in elements)
            {
                extractedTexts.Add(new { text = element.Text });
            }

            return new AutomationResult
            {
                Success = true,
                ErrorMessage = "",
                Data = extractedTexts
            };

        }


        public async Task<AutomationResult> SearchElement(ActionModel action)
        {
            var selector = action.selector;
            var operation = action.Operation;

            if (string.IsNullOrEmpty(operation) || string.IsNullOrEmpty(selector))
            {
                return new AutomationResult
                {
                    Success = false,
                    ErrorMessage = "CssSelector or Operation Missing."
                };
            }

            try
            {
                //var element = driver.FindElement(By.CssSelector(selectpor))
                var element = driver.FindElement(By.CssSelector(selector));



                return new AutomationResult
                {
                    Success = true,
                    ErrorMessage = "",
                    Data = new { text = element.Text }
                };
            }
            catch (Exception ex)
            {
                return new AutomationResult
                {
                    Success = false,
                    ErrorMessage = "Elements not Found"
                };
            }



        }

        public async Task<AutomationResult> WaitForElement(ActionModel action)
        {
            var timeout = Convert.ToInt32(action.Timeout);
            //var cssSelector = action.CssSelector ?? "";
            //var element = driver.FindElements(By.CssSelector(cssSelector));

            try
            {
                var element = GetElement(action.selector_type ?? "cssSelector", action.selector ?? "");

                int elapsedTime = 0;

                if (timeout > elapsedTime)
                {
                    await Task.Delay(1000);
                    elapsedTime++;
                }

                return new AutomationResult
                {
                    Success = true,
                    Data = new { text = $"element waited for  {timeout} second" }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new AutomationResult
                {
                    Success = false,
                    ErrorMessage = "a problem has occurred the problem could be one of these \n\n\r\n1. Because a wrong selector or element was not found\r\n2. there may have been an unknown error"
                };
            }


        }


        public async Task<AutomationResult> ClickElement(ActionModel action)
        {

            try
            {
                //var cssSelector = action.CssSelector ?? "";
                //var element = driver.FindElement(By.CssSelector(cssSelector));
                var element = GetElement(action.selector_type ?? "cssSelector", action.selector ?? "");

                element.Click();

                return new AutomationResult
                {
                    Success = true,
                    Data = new { text = "Clicked on the desired element" }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new AutomationResult
                {
                    Success = false,
                    ErrorMessage = "a problem has occurred the problem could be one of these \n\n\r\n1. Because a wrong selector or element was not found\r\n2. there may have been an unknown error"
                };
            }


        }


        public async Task<AutomationResult> ExtractText(ActionModel action)
        {

            try
            {
                //var cssSelector = action.CssSelector ?? "";
                //var element = driver.FindElement(By.CssSelector(cssSelector));
                var element = GetElement(action.selector_type ?? "cssSelector", action.selector ?? "");

                return new AutomationResult
                {
                    Success = true,
                    Data = new { text = element.Text }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new AutomationResult
                {
                    Success = false,
                    ErrorMessage = "a problem has occurred the problem could be one of these \n\n\r\n1. Because a wrong selector or element was not found\r\n2. there may have been an unknown error"
                };
            }

        }


        public async Task<AutomationResult> ExtractAttribute(ActionModel action)
        {

            try
            {
                //var cssSelector = action.CssSelector ?? "";
                //var element = driver.FindElement(By.CssSelector(cssSelector));
                var attribute = action.Attribute;


                if (attribute is null)
                {
                    return new AutomationResult
                    {
                        Success = false,
                        ErrorMessage = "Attribute Value is mandatory when using the ExtractAttribute function"
                    };
                }

                var element = GetElement(action.selector_type ?? "cssSelector", action.selector ?? "");

                return new AutomationResult
                {
                    Success = true,
                    Data = new { text = element.GetAttribute(action.Attribute) }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new AutomationResult
                {
                    Success = false,
                    ErrorMessage = "a problem has occurred the problem could be one of these \n\n\r\n1. Because a wrong selector or element was not found\r\n2. there may have been an unknown error"
                };
            }


        }


        public async Task<AutomationResult> TypingText(ActionModel action)
        {

            try
            {
                //var cssSelector = action.CssSelector ?? "";
                //var element = driver.FindElement(By.CssSelector(cssSelector));
                var text = action.Text;


                if (text is null)
                {
                    return new AutomationResult
                    {
                        Success = false,
                        ErrorMessage = "Text Value is mandatory when using the TypingText function"
                    };
                }

                var element = GetElement(action.selector_type ?? "cssSelector", action.selector ?? "");

                element.SendKeys(text);

                if (action?.Submit?.isSubmit == true)
                {
                    element.Submit();
                }
                else if (action?.Submit?.selector is not null && action.Submit.selector_type is not null)
                {
                    var submit_button = GetElement(action.Submit.selector_type ?? "cssSelector", action.Submit.selector ?? "");
                    submit_button.Click();
                }
                else

                {
                    return new AutomationResult
                    {
                        Success = false,
                        ErrorMessage = "Submit is mandatory when using the TypingText function"
                    };
                }




                return new AutomationResult
                {
                    Success = true,
                    Data = new { text = element.GetAttribute(action.Attribute) }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new AutomationResult
                {
                    Success = false,
                    ErrorMessage = "a problem has occurred the problem could be one of these \n\n\r\n1. Because a wrong selector or element was not found\r\n2. there may have been an unknown error"
                };
            }


        }


        public IWebElement GetElement(string type, string selector)
        {
            By _by = type == "className" ? By.ClassName(selector) : type == "id" ? By.Id(selector) : type == "tagName" ? By.TagName(selector) : By.CssSelector(selector);



            var element = driver.FindElement(_by);

            return element;
        }


        public ActionResultModel CreateToolResult(string actionType, AutomationResult toolResult, ActionModel? action)
        {
            return toolResult.Success
                ? new ActionResultModel
                {
                    Success = true,
                    ActionType = actionType,
                    Data = toolResult?.Data,
                    selector = action?.selector,
                    selector_type = action.selector_type,
                    Operation = action.Operation,
                    Attribute = action.Attribute,
                    Submit = action.Submit,
                    Url = action.Url
                }
                : new ActionResultModel
                {
                    Success = false,
                    ActionType = actionType,
                    Error = toolResult.ErrorMessage
                };
        }


    }
}
