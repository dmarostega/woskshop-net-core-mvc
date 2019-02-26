using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebApp.Models
{
    public class Department
    {
        public Department() { }
        public Department(int _Id, String _Name)
        {
            Id = Id;
            Name = _Name;
        }

        public int Id { get; set; }
        public String  Name { get; set; }

        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public void addSeller(Seller Seller)
        {
            Sellers.Add(Seller);
        }

        public double totalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(
                            seller => seller.totalSales(initial,final)
                        );
        }
    }
}
