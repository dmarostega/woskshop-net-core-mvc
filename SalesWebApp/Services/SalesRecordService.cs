using Microsoft.AspNetCore.Mvc;
using SalesWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SalesWebApp.Services
{
    public class SalesRecordService : Controller
    {
        private readonly SalesWebAppContext _context;

        public SalesRecordService(SalesWebAppContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.date >= minDate.Value);
            }

            if(maxDate.HasValue)
            {
                result = result.Where(x => x.date <= maxDate.Value);
            }

            //return result.ToList();

            return await result
                                .Include(x => x.seller)
                                .Include(x => x.seller.department)
                                .OrderByDescending(x=> x.date)
                                .ToListAsync();
        }

        public async Task<List<IGrouping<Department,SalesRecord>   >> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.date >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                result = result.Where(x => x.date <= maxDate.Value);
            }

            //return result.ToList();

            return await result
                                .Include(x => x.seller)
                                .Include(x => x.seller.department)
                                .OrderByDescending(x => x.date)
                                .GroupBy(x => x.seller.department)
                                .ToListAsync();
        }
    }
}
