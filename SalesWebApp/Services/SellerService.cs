using Microsoft.EntityFrameworkCore;
using SalesWebApp.Models;
using SalesWebApp.Services.Exceptions;
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

        public async Task<List<Seller>> findAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

       /*   sincrono
        *public List<Seller> findAll()
        {
            
            return _context.Seller.ToList();
        }*/

        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

    /*    public void Insert(Seller obj)
        {
          //  obj.department = _context.Department.First();
            _context.Add(obj);
            _context.SaveChanges();
        }
        */

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.department).FirstOrDefaultAsync(obj => obj.id == id);
        }

     /* finById sincrono
      * 
      * public Seller findById(int id)
        {   /*  old    * /
            //return _context.Seller.FirstOrDefault(x => x.id == id);
            // ===>  eager loading 
            return _context.Seller.Include(obj => obj.department).FirstOrDefault(obj => obj.id == id);
        }
    */
      
        public async Task removeAsync(int id)
        {
            var obj = await _context.Seller.FindAsync(id);
            _context.Remove(obj);
            await _context.SaveChangesAsync();
        }

        
        /*    remove sincrono
       *
       *  
       *  public  void remove(int id)
        {
            var obj =_context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
        */
        
        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.id == obj.id);
            if (!hasAny)
            {
                throw new NotFoundException("Id Not Found!");
            }

            _context.Update(obj);
           await _context.SaveChangesAsync();
        }
        
        /* update sincrono
         * public void Update(Seller obj)
          {
              if (!_context.Seller.Any(x => x.id == obj.id))
              {
                  throw new NotFoundException("Id Not Found!");
              }
              _context.Update(obj);
              _context.SaveChanges();
          }
          */

    }
}
