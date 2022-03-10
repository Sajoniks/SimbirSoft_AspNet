using Microsoft.AspNetCore.Mvc;

namespace SimbirHomework.Controllers
{
    public class IndexController : Controller
    {
        // GET
        [Route("/")]
        public IActionResult Index()
        {
            return Redirect("~/index.html");
        }
    }
}