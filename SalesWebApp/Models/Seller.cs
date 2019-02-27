using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebApp.Models
{
    public class Seller
    {
        public Seller() { }

        public Seller(int Id, String Name, String Email, DateTime BirthDate, Double BaseSalary, Department Department/*, SalesRecord SalesRecord*/)
        {
           /*id = Id;*/
            name = Name;
            email = Email;
            birthDate = BirthDate;
            baseSalary = BaseSalary;
            department = Department;
            
            /*  não inserrir aqui os collections    */
            //salesRecord.Add(SalesRecord);
        }
        public int id { get; set; }
        [Display(Name = "Nome")]
        public String name { get; set; }

        [Display(Name = "Email")]
        public String email { get; set; }

        [Display(Name = "Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime birthDate { get; set; }

        [Display(Name = "Remuneração")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public Double baseSalary { get; set; }

        [Display(Name = "Departamento")]
        public Department department { get; set; }

        /*  int departmentId -> serve para obrigar o framework Entity a setar no banco de dados a coluna departmentId como NOT NULL*/
        public int departmentId { get; set; }
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
