using SalesWebApp.Models.Enums;
using System;

namespace SalesWebApp.Models
{
    public class SalesRecord
    {

        public SalesRecord()
        {
        }

        public SalesRecord(int Id,DateTime Date, double Amount, SaleStatus Status,Seller Seller)
        {
            /*id = Id;*/
            date = Date;
            amount = Amount;
            status = Status;
            seller = Seller;
        }

        public int id { get; set; }
        public DateTime date { get; set; }

        public double amount { get; set; }

        public SaleStatus status { get; set; }

        public Seller seller { get; set; }
    }
}
