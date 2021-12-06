using System.Linq;
using AutoMapper;
using BLL.Interface.Entities;
using BLL.Interface.Servicies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.UI.Infrastructure;
using Web.UI.ViewModels;

namespace Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private ICourseWorkService service;
        private IMapper mapper;
        private IMessageSender sender;
        public HomeController(ICourseWorkService service, IMessageSender sender)
        {
            this.service = service;
            this.sender = sender;
            mapper = new MapperConfiguration(c => c.AddProfile(new MappingProfileWeb())).CreateMapper();
        }
        
        [Authorize(Roles = "Mentor, Student")]
        public IActionResult Index()
        {
            var userName = this.User?.Identity?.Name;
            //var claim = this.User.Identity.IsAuthenticated;
            //var role = this.User.IsInRole("Mentor");
            //var works = service.GetCourseWorks();

            var mentor = service.GetMentors().FirstOrDefault(m => m.Email == userName);

            var works = service
                .GetCourseWorks(mapper.Map<Mentor>(mentor))
                .Select(w => mapper.Map<CourseWork, CourseWorkViewModel>(w));
            
            return View(service
                .GetCourseWorks()
                .Select(w => mapper.Map<CourseWork, CourseWorkViewModel>(w)));
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