using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using UseSeleniumWithAPI.Models;

namespace UseSeleniumWithAPI.Utils
{
    public class WebAutomation
    {
        private static IWebDriver driver;

        public async Task<List<ActionResultModel>> StartSelenium(RequestModel request)
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            driver = new ChromeDriver(options);
            AutomationTools tools = new AutomationTools(driver);

            var main_tool_result = await tools.GoWebsite(request.Url ?? "");

            if (main_tool_result.Success == false)
            {
                List<ActionResultModel> error_proccess_actions_result = new List<ActionResultModel>();
                error_proccess_actions_result.Add(new ActionResultModel
                {
                    Success = false,
                    ActionType = "MAIN_GO_WEBSITE",
                    Error = main_tool_result.ErrorMessage
                });
                return error_proccess_actions_result;
            }

            var proccess_actions_result = await ProcessActions(request.Actions);
            driver.Quit();
            return proccess_actions_result;

        }


        public static async Task<List<ActionResultModel>> ProcessActions(List<ActionModel> actions)
        {

            var results = new List<ActionResultModel>();

            AutomationTools tools = new AutomationTools(driver);


            foreach (ActionModel action in actions)
            {
                var actionType = action.ActionType;
                ActionResultModel result;
                AutomationResult tool_result;

                switch (actionType)
                {
                    case "GO_WEBSITE":
                        tool_result = await tools.GoWebsite(action.Url ?? "");
                        result = tools.CreateToolResult(actionType, tool_result, action);
                        //if (tool_result.Success)
                        //{
                        //    result = new ActionResultModel
                        //    {
                        //        Success = true,
                        //        ActionType = actionType,
                        //        Data = tool_result.Data,
                        //        Url = action.Url
                        //    };
                        //}
                        //else
                        //{
                        //    result = new ActionResultModel
                        //    {
                        //        Success = false,
                        //        ActionType = actionType,
                        //        Error = tool_result.ErrorMessage
                        //    };
                        //}

                        results.Add(result);


                        break;
                    case "SEARCH_ELEMENT":
                        tool_result = await tools.SearchElement(action);
                        result = tools.CreateToolResult(actionType, tool_result, action);
                        //if (tool_result.Success)
                        //{
                        //    result = new ActionResultModel
                        //    {
                        //        Success = true,
                        //        ActionType = actionType,
                        //        Data = tool_result.Data,
                        //        selector = action.selector,
                        //        selector_type = action.selector_type,
                        //        Operation = action.Operation
                        //    };
                        //}
                        //else
                        //{
                        //    result = new ActionResultModel
                        //    {
                        //        Success = false,
                        //        ActionType = actionType,
                        //        Error = tool_result.ErrorMessage
                        //    };
                        //}

                        results.Add(result);
                        break;
                    case "WAIT_FOR_ELEMENT":
                        tool_result = await tools.WaitForElement(action);
                        result = tools.CreateToolResult(actionType, tool_result, action);
                        //if (tool_result.Success)
                        //{
                        //    result = new ActionResultModel
                        //    {
                        //        Success = true,
                        //        ActionType = actionType,
                        //        Data = tool_result.Data,
                        //        selector = action.selector,
                        //        selector_type = action.selector_type,
                        //        Operation = action.Operation
                        //    };
                        //}
                        //else
                        //{
                        //    result = new ActionResultModel
                        //    {
                        //        Success = false,
                        //        ActionType = actionType,
                        //        Error = tool_result.ErrorMessage
                        //    };
                        //}

                        results.Add(result);
                        break;
                    case "CLICK_ELEMENT":
                        tool_result = await tools.ClickElement(action);
                        result = tools.CreateToolResult(actionType, tool_result, action);
                        //if (tool_result.Success)
                        //{
                        //    result = new ActionResultModel
                        //    {
                        //        Success = true,
                        //        ActionType = actionType,
                        //        Data = tool_result.Data,
                        //        selector = action.selector,
                        //        selector_type = action.selector_type,
                        //        Operation = action.Operation
                        //    };
                        //}
                        //else
                        //{
                        //    result = new ActionResultModel
                        //    {
                        //        Success = false,
                        //        ActionType = actionType,
                        //        Error = tool_result.ErrorMessage
                        //    };
                        //}

                        results.Add(result);
                        break;
                    case "EXTRACT_TEXT":
                        tool_result = await tools.ExtractText(action);
                        result = tools.CreateToolResult(actionType, tool_result, action);
                        //if (tool_result.Success)
                        //{
                        //    result = new ActionResultModel
                        //    {
                        //        Success = true,
                        //        ActionType = actionType,
                        //        Data = tool_result.Data,
                        //        selector = action.selector,
                        //        selector_type = action.selector_type,
                        //        Operation = action.Operation
                        //    };
                        //}
                        //else
                        //{
                        //    result = new ActionResultModel
                        //    {
                        //        Success = false,
                        //        ActionType = actionType,
                        //        Error = tool_result.ErrorMessage
                        //    };
                        //}

                        results.Add(result);
                        break;
                    case "EXTRACT_ATTRIBUTE":
                        tool_result = await tools.ExtractText(action);
                        result = tools.CreateToolResult(actionType, tool_result, action);
                        //if (tool_result.Success)
                        //{
                        //    result = new ActionResultModel
                        //    {
                        //        Success = true,
                        //        ActionType = actionType,
                        //        Data = tool_result.Data,
                        //        selector = action.selector,
                        //        selector_type = action.selector_type,
                        //        Attribute = action.Attribute,
                        //        Operation = action.Operation
                        //    };
                        //}
                        //else
                        //{
                        //    result = new ActionResultModel
                        //    {
                        //        Success = false,
                        //        ActionType = actionType,
                        //        Error = tool_result.ErrorMessage
                        //    };
                        //}

                        results.Add(result);
                        break;

                    case "TYPING_TEXT":
                        tool_result = await tools.TypingText(action);
                        result = tools.CreateToolResult(actionType, tool_result, action);
                        //if (tool_result.Success)
                        //{
                        //    result = new ActionResultModel
                        //    {
                        //        Success = true,
                        //        ActionType = actionType,
                        //        Data = tool_result.Data,
                        //        Submit = action.Submit,
                        //        selector = action.selector,
                        //        selector_type = action.selector_type,
                        //        Attribute = action.Attribute,
                        //        Operation = action.Operation
                        //    };
                        //}
                        //else
                        //{
                        //    result = new ActionResultModel
                        //    {
                        //        Success = false,
                        //        ActionType = actionType,
                        //        Error = tool_result.ErrorMessage
                        //    };
                        //}

                        results.Add(result);
                        break;

                }
            }


            return results;
        }
    }
}
