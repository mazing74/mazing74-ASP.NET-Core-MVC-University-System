using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace PL.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository) //ask clr for creating obj from class that implment the interface IdepartmentRepository and inject it here in the constructor 
        {
            _departmentRepository = departmentRepository;
        }

        public IActionResult Index()
        {
            var departments = _departmentRepository.GetAll();

            return View(departments); 
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();//bta3 el form 
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                int result = _departmentRepository.add(department);
                if (result > 0)
                {
     
                    //TempData["Message"] = "Department created successfully!";

                }
                return RedirectToAction("Index");
            }
            return View(department);
        }
        //BaseUrl/Department/Details/100
        public IActionResult Details(int? id, string ViewName = "Details")
        {
            if (id == null)
                return BadRequest(); // response with status code 400
            var department = _departmentRepository.GetById(id.Value);
            if (department == null)
                return NotFound(); // response with status code 404
            return View(ViewName, department);

        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {

            return Details(id.Value, "Edit");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Department department, [FromRoute] int id)//هنا بستخدم ال from route عشان اقول لل MVC ان ال id ده جاي من ال route مش من ال form data
        {
            if (id != department.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _departmentRepository.update(department);
                    return RedirectToAction("Index");
                }
                catch (System.Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }

            }
            return View(department);

        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return Details(id.Value, "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Department department, [FromRoute] int id)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }

            try
            {
                _departmentRepository.delete(department);
                return RedirectToAction("Index");
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(department);
            }

        }
    }
}
