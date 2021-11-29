using System.Linq;
using AutoMapper;
using BLL.Interface.Entities;
using BLL.Interface.Servicies;
using Microsoft.AspNetCore.Mvc;
using Web.UI.Infrastructure;
using Web.UI.ViewModels;

namespace Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private ICourseWorkService service;
        private IMapper mapper;
        public HomeController(ICourseWorkService service)
        {
            this.service = service;
            mapper = new MapperConfiguration(c => c.AddProfile(new MappingProfileWeb())).CreateMapper();
        }

        public IActionResult Index()
        {
            var works = service.GetCourseWorks();
            return View(works.Select(w => mapper.Map<CourseWork, CourseWorkViewModel>(w)));
        }

        public IActionResult Students()
        {
            var works = service.GetStudents()
                .Select(s => mapper.Map<Student, StudentViewModel>(s));
            return View(works);
        }

        [HttpGet]
        public IActionResult Create()
        {
            /*CourseWorkViewModel work = new CourseWorkViewModel()
            {
                Title = "Enter the title"
            };*/
            
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(CourseWorkViewModel courseWork)
        {
            CourseWork work = mapper.Map<CourseWork>(courseWork);
            service.Add(mapper.Map<CourseWork>(courseWork));
            return RedirectToAction("Index");
        }

        public IActionResult Select(int id)
        {
            var studentUser = service.GetStudents().First();
            service.Select(studentUser, service.GetCourseWorks().First(x => (x.Id == id)));
            return RedirectToAction("Index");
        }
        
        public IActionResult Approve(int id)
        {
            //this.User
            var mentorUser = service.GetMentors().First();
            service.Approve(mentorUser, service.GetCourseWorks().First(x => (x.Id == id)));
            return RedirectToAction("Index");
        }
        
        public IActionResult Decline(int id)
        {
            var mentorUser = service.GetMentors().First();
            service.Decline(mentorUser, service.GetCourseWorks().First(x => (x.Id == id)));
            return RedirectToAction("Index");
        }
        
    }
}