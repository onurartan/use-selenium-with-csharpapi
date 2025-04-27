using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UseSeleniumWithAPI.Models;
using UseSeleniumWithAPI.Utils;

namespace UseSeleniumWithAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeleniumController : ControllerBase
    {
        [HttpPost]
        public async  Task<ActionResult<ResponseModel>> AutomationRoute(RequestModel request)
        {
            WebAutomation automation = new WebAutomation();
            var automation_result = await automation.StartSelenium(request);

            return new ResponseModel
            {
                Success = true,
                result = automation_result
                .Select(result => result.GetNotNullProperties()).ToList()
                //.GroupBy(kvp => kvp.Key)
                //.Select(group => group.Last())
                //.ToDictionary(kvp => kvp.Key, kvp => kvp.Value)
            };

        }
    }
}
