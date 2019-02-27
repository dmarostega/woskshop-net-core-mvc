using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebApp.Models;
using SalesWebApp.Models.ViewModels;
using SalesWebApp.Services;
using SalesWebApp.Services.Exceptions;

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

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if (id != seller.id)
            {
                return BadRequest();
            }
            try
            {
                _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }catch(NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }

        }
        public IActionResult Edit(int? id)
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

            List<Department> departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Seller =  obj, Departments = departments };
            
            return View(viewModel);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _sellerService.findById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }


            return View(obj);
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