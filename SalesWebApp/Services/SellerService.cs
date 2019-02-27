﻿using SalesWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebApp.Services
{
    public class SellerService
    {
        private readonly SalesWebAppContext _context;

        public SellerService(SalesWebAppContext context)
        {
            _context = context;
        }

        public List<Seller> findAll()
        {
            /*  assincrono  */
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            obj.department = _context.Department.First();
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}