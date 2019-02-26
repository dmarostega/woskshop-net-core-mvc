using SalesWebApp.Models;
using SalesWebApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebApp.Data
{
    public class SeedingService
    {
        private SalesWebAppContext _context;

        public SeedingService(SalesWebAppContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Department.Any()    ||
                _context.Seller.Any()   ||
                _context.SalesRecord.Any()
               )
            {
                return; // já populado
            }

            Department d1 = new Department(1, "Computer");
            Department d2 = new Department(2, "Fashion");
            Department d3 = new Department(3, "Eletronics");
            Department d4 = new Department(4, "Books");
            Department d5 = new Department(5, "Eletric");
            Department d6 = new Department(6, "Store");
            Department d7 = new Department(7, "hydraulic");

            Seller s1 = new Seller(1, "Ricardo Ferreira","rocardp@gmail.com", new DateTime(1988, 3, 4), 1300.0, d1);
            Seller s2 = new Seller(2, "Josiane Obotuleto","josi@gmail.com", new DateTime(1999, 12, 5), 1200.0, d2);
            Seller s3 = new Seller(3, "Juliana Albuquerque","juju@@gmail.com", new DateTime(1989, 5, 14), 7000.0, d2);
            Seller s4 = new Seller(4, "Matheus Krauss","mk@gmail.com", new DateTime(1987, 1, 20), 10500.0, d2);
            Seller s5 = new Seller(5, "Gilmar Mendes","gmendes@gmail.com", new DateTime(1985, 6, 12), 2300.0, d3);
            Seller s6 = new Seller(6, "Bruna Ferrari","bruninha@gmail.com", new DateTime(1992, 11, 20), 2000.0, d2);
            Seller s7 = new Seller(7, "Josemar Carneiro","josemca@gmail.com", new DateTime(1960, 2, 15), 1100.0, d4);
            Seller s8 = new Seller(8, "The Boss","ochefe@gmail.com", new DateTime(1945, 6, 6), 2450.0, d5);

            SalesRecord sr1 = new SalesRecord(1, new DateTime(2011, 3, 1), 50.0, SaleStatus.Billed ,s1);
            SalesRecord sr2 = new SalesRecord(2, new DateTime(2011, 3, 6), 150.0, SaleStatus.Billed ,s4);
            SalesRecord sr3 = new SalesRecord(3, new DateTime(2012, 4, 4), 35.0, SaleStatus.Billed ,s3);
            SalesRecord sr4 = new SalesRecord(4, new DateTime(2012, 6, 10), 145.0, SaleStatus.Cancel ,s4);
            SalesRecord sr5 = new SalesRecord(5, new DateTime(2012, 10, 1), 500.0, SaleStatus.Billed ,s5);
            SalesRecord sr6 = new SalesRecord(6, new DateTime(2013, 3, 1), 50.0, SaleStatus.Billed ,s6);
            SalesRecord sr7 = new SalesRecord(7, new DateTime(2013, 4, 1), 50.0, SaleStatus.Billed ,s6);
            SalesRecord sr8 = new SalesRecord(8, new DateTime(2013, 5, 11), 50.0, SaleStatus.Cancel ,s7);
            SalesRecord sr9 = new SalesRecord(9, new DateTime(2014, 3, 5), 150.0, SaleStatus.Billed ,s8);
            SalesRecord sr10 = new SalesRecord(10, new DateTime(2014, 3, 1), 50.0, SaleStatus.Billed ,s1);
            SalesRecord sr11 = new SalesRecord(11, new DateTime(2015, 3, 1), 50.0, SaleStatus.Billed ,s2);
            SalesRecord sr12 = new SalesRecord(12, new DateTime(2015, 3, 1), 50.0, SaleStatus.Cancel ,s3);
            SalesRecord sr13 = new SalesRecord(13, new DateTime(2015, 3, 1), 50.0, SaleStatus.Billed ,s5);
            SalesRecord sr14 = new SalesRecord(14, new DateTime(2016, 3, 1), 50.0, SaleStatus.Billed ,s8);
            SalesRecord sr15 = new SalesRecord(15, new DateTime(2016, 3, 1), 50.0, SaleStatus.Billed ,s7);
            SalesRecord sr16 = new SalesRecord(16, new DateTime(2016, 3, 1), 50.0, SaleStatus.Billed ,s7);
            SalesRecord sr17 = new SalesRecord(17, new DateTime(2017, 3, 1), 50.0, SaleStatus.Billed ,s1);
            SalesRecord sr18 = new SalesRecord(18, new DateTime(2017, 3, 1), 50.0, SaleStatus.Billed ,s1);
            SalesRecord sr19 = new SalesRecord(19, new DateTime(2017, 3, 1), 50.0, SaleStatus.Billed ,s3);
            SalesRecord sr20 = new SalesRecord(20, new DateTime(2018, 3, 1), 50.0, SaleStatus.Billed ,s5);
            SalesRecord sr21 = new SalesRecord(21, new DateTime(2018, 3, 1), 50.0, SaleStatus.Billed ,s4);
            SalesRecord sr22 = new SalesRecord(22, new DateTime(2019, 3, 1), 50.0, SaleStatus.Pending,s4);
            SalesRecord sr23 = new SalesRecord(23, new DateTime(2019, 3, 1), 50.0, SaleStatus.Billed ,s2);
            SalesRecord sr24 = new SalesRecord(24, new DateTime(2019, 3, 1), 50.0, SaleStatus.Pending,s4);
            SalesRecord sr25 = new SalesRecord(25, new DateTime(2019, 3, 1), 50.0, SaleStatus.Billed ,s4);

            _context.Department.AddRange(d1, d2, d3, d4, d5, d6, d7);

            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6, s7, s8);

            _context.SalesRecord.AddRange(sr1, sr2, sr3, sr4, sr5, sr6, sr7, sr8, sr9, 
                sr10, sr11, sr12, sr13, sr14, sr15, sr16, sr17, sr18, sr19, sr20, sr21,
                sr22, sr23, sr24, sr25);

            _context.SaveChanges();
        }

    }
}
