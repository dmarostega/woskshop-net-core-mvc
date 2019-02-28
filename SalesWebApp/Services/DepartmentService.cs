using SalesWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebApp.Services
{
    public class DepartmentService
    {
        private readonly SalesWebAppContext _context;

        public DepartmentService(SalesWebAppContext context) {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();  
        }

        /*  METODO SINCRONO: A OPERAÇÃO BLOQUEIA A APLICAÇÃO ATÉ SUA CONCLUSÃO
         * 
         * public List<Department> FindAll()
        {   
            //return _context.Department.ToList();

            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    */

 
    }

}
