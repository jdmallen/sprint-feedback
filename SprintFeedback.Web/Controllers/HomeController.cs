using Microsoft.AspNetCore.Mvc;

namespace SprintFeedback.Web.Controllers
{
	[Route("")]
	public class BaseViewController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
