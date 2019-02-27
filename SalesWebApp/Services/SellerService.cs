using Microsoft.EntityFrameworkCore;
using SalesWebApp.Models;
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
          //  obj.department = _context.Department.First();
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller findById(int id)
        {   /*  old    */
            //return _context.Seller.FirstOrDefault(x => x.id == id);
            /*  eager loading*/
            return _context.Seller.Include(obj => obj.department).FirstOrDefault(obj => obj.id == id);
        }

        public  void remove(int id)
        {
            var obj =_context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
    }
}
