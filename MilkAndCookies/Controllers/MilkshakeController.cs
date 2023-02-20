using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Swagger;

namespace MilkAndCookies.Controllers
{
	// This controller takes care of the methods setting the favorite milkshake flavour + plus expiry in a cookie in one method and getting it
	// in another method.
	[ApiController]
	[Route("[controller]")]
	public class MilkshakeController : ControllerBase
	{
		CookieOptions co = new CookieOptions();
		DateTime now = DateTime.Now;
		
		[HttpGet]
		public string GetFavoriteMilkshake(string favoriteMilkshake)
		{		
			if (favoriteMilkshake == null)
			{
				return "Unknown";				
			} else
			{
				co.Expires = now.AddMinutes(5);
				Response.Cookies.Append("favoriteMilkshake", favoriteMilkshake, co);
				return favoriteMilkshake;
			}						
		}

		[HttpGet]
		[Route("[action]")]
		public string GetFavoriteMilkshakeFromCookie()
		{
			if (Request.Cookies["favoriteMilkshake"] == null) {
				return "Unknown"; 
			} else {
				return Request.Cookies["favoriteMilkshake"]!;
			}
		}
	}
}