using DesignPatternChainOfResponsibilityAkademiPlus.ChainOfResponsibility;
using DesignPatternChainOfResponsibilityAkademiPlus.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternChainOfResponsibilityAkademiPlus.Controllers
{
    public class DefaultController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Index(CustomerProcessViewModel viewModel)
        {
            Employee treasurer = new Treasurer();
            Employee managerAssistant = new ManagerAssistant();
            Employee manager = new Manager();
            Employee regionalManager = new RegionalManager();

            treasurer.SetNextApprover(managerAssistant);
            managerAssistant.SetNextApprover(manager);
            manager.SetNextApprover(regionalManager);

            treasurer.ProcessRequest(viewModel);
            return View();

        }
    }
}
