using Microsoft.AspNetCore.Mvc;
using P23517082023.Models;
using P23517082023.ViewModels.HomeVMs;

namespace P23517082023.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<Group> _groups;

        public HomeController()
        {
            _groups = new List<Group>
            {
                new Group {Id = 1,Name = "P235",Count=16,EducationType="Back End"},
                new Group {Id = 2,Name = "P234",Count=16,EducationType="Front End"},
                new Group {Id = 3,Name = "229",Count=16,EducationType="Bitib"},
                new Group {Id = 4,Name = "P138",Count=16,EducationType="Sabah Teqdimatdi"},
            };
        }

        public IActionResult Index() 
        { 

            return View(_groups); 
        }

        public IActionResult Detail(int? id)
        {
            if (id == null) return BadRequest("Group Id Mutleq Gonderilmelidi");

            if (!_groups.Exists(g => g.Id == id)) return NotFound("Gonderilen Id Yanlisdir");

            Group group = _groups.Find(g => g.Id == id);

            return View(group);
        }

        #region Comment
        //public IActionResult Index()
        //{
        //    //ViewData["name"] = "Hamid";
        //    //ViewBag.Age = 15;

        //    //int a = 10;

        //    //a = 20;

        //    //TempData["name"] = "Mammadov";

        //    //return RedirectToAction(nameof(Detail));

        //    //Group group = new Group();
        //    //group.Name = "P235";
        //    //group.Count = 16;
        //    //group.EducationType = "Back End";

        //    //Student student = new Student();
        //    //student.Name = "Hamid";
        //    //student.SurName = "Mammadov";
        //    //student.Age = 33;

        //    //ViewBag.stu = student;
        //    //ViewBag.group = group;

        //    //IndexVM indexVM = new IndexVM();
        //    //indexVM.Student = student;
        //    //indexVM.Group = group;
        //    //indexVM.A = a;

        //    //return View(indexVM);
        //}
        #endregion
    }
}