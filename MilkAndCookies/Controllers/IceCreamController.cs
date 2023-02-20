using Microsoft.AspNetCore.Mvc;

namespace MilkAndCookies.Controllers
{
	// This controller is showing how to get data from the cookie, even though the cookies was set in the other controller,
	// in two seperate controllers. One where the favorite ice cream is set to be the same as the favorite milkshake, value taken
	// from the cookie, and one deleting the cookie
	[ApiController]
	[Route("[controller]")]
	public class IceCreamController : ControllerBase
	{
		[HttpGet(Name = "GetFavoriteIceCream")]	
		public IceCream Get()
		{
			if (Request.Cookies["favoriteMilkshake"] == null)
			{
				return new IceCream {
					Flavour = "Unknown"
				};
			} else
			{
				return new IceCream
				{
					Flavour = Request.Cookies["favoriteMilkshake"]
				};
			}
		}

		[HttpDelete]
		public void Delete()
		{
			if (Request.Cookies["favoriteMilkshake"] != null)
			{
				Response.Cookies.Delete("favoriteMilkshake");
			}
		}	
	}
}