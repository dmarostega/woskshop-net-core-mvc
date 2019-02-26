using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebApp.Models
{
    public class Seller
    {
        public Seller() { }

        public Seller(int Id, String Name, String Email, DateTime BirthDate, Double BaseSalary, Department Department/*, SalesRecord SalesRecord*/)
        {
            id = Id;
            name = Name;
            email = Email;
            birthDate = BirthDate;
            baseSalary = BaseSalary;
            department = Department;
            
            /*  não inserrir aqui os collections    */
            //salesRecord.Add(SalesRecord);
        }
        public int id { get; set; }
        public String name { get; set; }
        public String email { get; set; }
        public DateTime birthDate { get; set; }
        public Double baseSalary { get; set; }

        public Department department { get; set; }

        public ICollection<SalesRecord> salesRecord { get; set; } = new List<SalesRecord>(); 

        public void AddSales(SalesRecord sr)
        {
            salesRecord.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            salesRecord.Remove(sr);
        }

        public double totalSales(DateTime Initial, DateTime Final)
        {

            return salesRecord.Where(sr => sr.date >= Initial
                                    &&
                                    sr.date <= Final)
                                    .Sum(sr => sr.amount);
        }

    }
}
