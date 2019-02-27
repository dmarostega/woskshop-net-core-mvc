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

        [Required(ErrorMessage = "{0} é obrigatório!)")]
        [StringLength(60, MinimumLength = 3,ErrorMessage = "Tamanho do {0} deve ser de {2} a {1}")  ]
        [Display(Name = "Nome")]
        public String name { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório!)")]
        [EmailAddress(ErrorMessage = "{0} possui formato inválido")]
        [Display(Name = "Email")]
        public String email { get; set; }


        [Required(ErrorMessage = "{0} é obrigatório!@)")]
        [Display(Name = "Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime birthDate { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório!@)")]
        [Range(100.0,70000.0,ErrorMessage = " Valor Inválido! Min. {1} Máx {2} ")]
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
