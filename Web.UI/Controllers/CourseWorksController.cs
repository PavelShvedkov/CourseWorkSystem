using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interface.Entities;
using BLL.Interface.Servicies;
using DAL.Interface.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.UI.Infrastructure;
using Web.UI.Models;
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
            mapper = new MapperConfiguration(c => c.AddProfile(new MappingProfile())).CreateMapper();
        }

        public IActionResult Index()
        {
           var works = service.GetCourseWorks().Select(w => mapper.Map<CourseWork,CourseWorkViewModel>(w));
            return View(works);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}