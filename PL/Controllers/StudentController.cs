using BLL.Interfaces;
using BLL.Repository;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace PL.Controllers
{

    [Authorize]     
    public class StudentController : Controller
    {

        private readonly IstudentRepository _repository;
        private readonly IDepartmentRepository _departmentRepository;

        public StudentController(IstudentRepository repository, IDepartmentRepository departmentRepository)
        {
            _repository = repository;
            _departmentRepository = departmentRepository;
        }
        [Authorize]
        public IActionResult Index()
        {
            var students = _repository.GetAll();
            return View(students);
        }

        public IActionResult Details(int? id)
        {
            if (id == null) 
                return BadRequest();
            var student = _repository.GetById(id.Value);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        public IActionResult getbyid(int id)
        {

            var student = _repository.GetById(id);
            if (student == null)
            {
                return BadRequest();
            }
            return View(student);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.departments = _departmentRepository.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student, IFormFile imagefile)
        {
            if (imagefile != null && imagefile.Length > 0)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imagefile.FileName);

                string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                string filePath = Path.Combine(folderPath, fileName);

                // بدل async بنستخدم CopyTo العادية
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imagefile.CopyTo(stream);
                }

                student.image = fileName;
            }
            if (ModelState.IsValid)
            {
                _repository.add(student);
                return RedirectToAction("Index");
            }

            return View(student);

        }


        public IActionResult Edit(int? id)
        {
            ViewBag.departments = _departmentRepository.GetAll();
            if (id == null)
            {
                return BadRequest();
            }
            var student = _repository.GetById(id.Value);
            if (student == null)
                return NotFound();
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id, Student student, IFormFile imagefile)
        {
            if (imagefile != null && imagefile.Length > 0)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imagefile.FileName);

                string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                string filePath = Path.Combine(folderPath, fileName);

                // بدل async بنستخدم CopyTo العادية
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imagefile.CopyTo(stream);
                }

                student.image = fileName;
            }
            if (id != student.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _repository.update(student);
                return RedirectToAction("Index");
            }

            ViewBag.departments = _departmentRepository.GetAll();
            return View(student);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var student = _repository.GetById(id.Value);
            return View(student);
        }
        [HttpPost]
        public ActionResult Delete(Student student ,[FromRoute ]int id)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            try
            {
                _repository.delete(student);
                return RedirectToAction("Index");
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(student);
            }

        }
    }
}
