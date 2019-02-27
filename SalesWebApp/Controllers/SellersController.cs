using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebApp.Models;
using SalesWebApp.Models.ViewModels;
using SalesWebApp.Services;

namespace SalesWebApp.Controllers
{

    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }
                
        public IActionResult Index()
        {
            var list = _sellerService.findAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel() { Departments = departments};
            return View(viewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.remove(id);

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = _sellerService.findById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }

            //return to View/Seller/delete.cshtml
            return View(obj);
        }
    }
}