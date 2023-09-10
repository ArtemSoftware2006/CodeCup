using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Новая_папка.Models;

namespace Новая_папка.Controllers
{
    [Route("[controller]/[action]")]
    public class GroupController : Controller
    {
        private readonly ILogger<GroupController> _logger;

        public GroupController(ILogger<GroupController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Route("{group}")]
        public IActionResult CreateLinkGroup(Guid group)
        {
            _logger.LogInformation(group.ToString());
            return View("CreateLinkGroup", new GroupModel() {Id = group});
        }
        public IActionResult CreateGroup() 
        {
            _logger.LogInformation("Add group");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}