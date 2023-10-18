using Microsoft.AspNetCore.Mvc;
using P23517082023.Models;

namespace P23517082023.Controllers
{
    public class StudnetController : Controller
    {
        private readonly List<Student> _students;

        public StudnetController()
        {
            _students = new List<Student>
            {
                new Student {Name = "Mustafa",SurName = "Melikov",Age = 16,GroupId = 2,Id = 1 },
                new Student {Name = "Emrah",SurName = "Nesirov",Age = 23,GroupId = 2,Id = 2 },
                new Student {Name = "Ehmed",SurName = "Mehdiyev",Age = 23,GroupId = 2,Id = 3 },
                new Student {Name = "Nesrin",SurName = "Esedli",Age = 16,GroupId = 2,Id = 4 },
                new Student {Name = "Murad",SurName = "Eliyev",Age = 20,GroupId = 1,Id = 5 },
                new Student {Name = "Aykhan",SurName = "Quliyev",Age = 9999,GroupId = 1,Id = 6 },
                new Student {Name = "Nicat",SurName = "Misirxanli",Age = 1000,GroupId = 1,Id = 7 },
                new Student {Name = "Mahmud",SurName = "Eliyev",Age = 21,GroupId =3,Id = 8 },
            };
        }

        public IActionResult Index(int? id)
        {
            if (id == null)
            {
                return View(_students);
            }
            else
            {
                if (_students.Exists(s=>s.GroupId == id))
                {
                    List<Student> students = _students.FindAll(s=>s.GroupId == id);
                    return View(students);
                }
                else
                {
                    return NotFound($"Gonderilen Group Id = {id} Yanlisdir");
                }
            }
        }

        public IActionResult Detail(int id)
        {
            if (id == null) return BadRequest("Studnet Id Mutleq Gonderilmelidi");

            Student student = _students.Find(s=>s.Id == id);

            if (student == null) return NotFound();

            return View(student);
        }
    }
}
