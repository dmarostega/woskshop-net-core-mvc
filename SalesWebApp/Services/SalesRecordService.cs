using SalesWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebApp.Services
{
    public class SalesRecordService
    {
        private readonly SalesWebAppContext _context;

        public SalesRecordService(SalesWebAppContext context)
        {
            _context = context;
        }

        public void FindByDate(DateTime minDate, DateTime maxDate)
        {

        }
    }
}
