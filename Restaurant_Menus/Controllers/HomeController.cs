using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Menus.Models;
using Microsoft.Extensions.Configuration;
using Restaurant_Menus.ViewModels;
using Restaurant_Menus.Repository;


namespace Restaurant_Menus.Controllers
{
    public class HomeController : Controller

    {
        private readonly MenuRepository sMenuRepository;

        public HomeController(IConfiguration configuration)
        {
            sMenuRepository = new MenuRepository(configuration);
            var menus = sMenuRepository.FindAll();
        }

        [HttpGet]
        public IActionResult ViewCreate()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        public IActionResult Create(Menu cust)
        {
            int create_file_id = cust.File_Id;
            sMenuRepository.Add(cust);

            var menus = sMenuRepository.FindAll();

            IndexViewModel ivm = new IndexViewModel { Menus = menus };

            ivm.Menus = menus.Where(p => p.File_Id == create_file_id);
            return PartialView("_Table", ivm);
        }


        public IActionResult ViewEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Menu obj = sMenuRepository.FindByID(id.Value);

            if (obj == null)
            {
                return NotFound();
            }
            return PartialView("_Edit", obj);
        }

        [HttpPost]
        public IActionResult ViewEdit(Menu obj)
        {
            if (ModelState.IsValid)
            {
                int cur_file_update = obj.File_Id;
                sMenuRepository.Update(obj);
                var menus = sMenuRepository.FindAll();

                IndexViewModel ivm = new IndexViewModel { Menus = menus };

                ivm.Menus = menus.Where(p => p.File_Id == cur_file_update);
                return PartialView("_Table", ivm);
            }

            return View(obj);
        }


        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var file_id = sMenuRepository.FindByID(id.Value);
            int tmp_id = file_id.File_Id;

            sMenuRepository.Remove(id.Value);
            var menus = sMenuRepository.FindAll();

            IndexViewModel ivm = new IndexViewModel { Menus = menus };

            ivm.Menus = menus.Where(p => p.File_Id == tmp_id);

            return PartialView("_Table", ivm);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult withoutAuthorization()
        {
            return View();
        }

        public IActionResult About(int? fileID = 2)
        {
            var menus = sMenuRepository.FindAll();
            int file_id = fileID.Value;

            ViewData["file_id_next"] = file_id + 1;

            IndexViewModel ivm = new IndexViewModel { Menus = menus };

            // если передан id компании, фильтруем список
            ViewData["file_id"] = 1;
            ViewData["file_name"] = "PDF/2.pdf";



            if (fileID != null && fileID > 0)
            {
                ViewData["file_id"] = fileID.Value;
                ViewData["file_name"] = "PDF/" + fileID.Value.ToString() + ".pdf";
                ivm.Menus = menus.Where(p => p.File_Id == fileID);
            }

            if (User.Identity.IsAuthenticated)
            {
                return View(ivm);
            }
           return View("withoutAuthorization");
           
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}