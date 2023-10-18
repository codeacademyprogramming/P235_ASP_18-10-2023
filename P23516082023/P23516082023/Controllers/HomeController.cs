using Microsoft.AspNetCore.Mvc;

namespace P23516082023.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(/*int? id*/)
        {
            return View();
            //if (id < 0)
            //{
            //    //ViewResult result = new ViewResult();
            //    //result.ViewName = "test";

            //    //return result;

            //    return View();
            //}
            //else
            //{
            //    //ContentResult resultcontent = new ContentResult();
            //    //resultcontent.Content = "Hello World ContentResult";
            //    //resultcontent.StatusCode = 200;
            //    //resultcontent.ContentType = "asdasd";

            //    //return resultcontent;

            //    return Content("Hello World ContentResult");
            //}
        }

        public IActionResult Detail( )
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        //public JsonResult Index()
        //{
        //    JsonResult result = new JsonResult("{name:'Hamid',surname:'Mammadov'}");

        //    return result;
        //}

        //public ContentResult Index()
        //{
        //    ContentResult result = new ContentResult();
        //    result.Content = "Hello World ContentResult";
        //    result.StatusCode = 200;
        //    result.ContentType = "asdasd";

        //    return result;
        //}
    }
}
