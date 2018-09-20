using System.Security.Principal;
using JDMallen.Toolbox.Factories;
using Microsoft.AspNetCore.Mvc;

namespace SprintFeedback.Web.Controllers
{
	[Route("api/user")]
	[ApiController]
	public class ApiUserController : ControllerBase
	{
		private readonly IJwtTokenFactory _tokenFactory;

		public ApiUserController(IJwtTokenFactory tokenFactory)
		{
			_tokenFactory = tokenFactory;
		}

		// GET api/values
		[Route("")]
		[HttpGet]
		public IActionResult GetCurrentUser()
		{
			var token = _tokenFactory.GenerateToken(WindowsIdentity.GetCurrent());
			return Ok(token);
		}
	}
}
