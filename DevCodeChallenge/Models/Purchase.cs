using System;

namespace DevCodeChallenge.Models
{
    public class Purchase
    {
        public virtual int Id { get; set; }
        public virtual int Quantity { get; set; }
        public virtual decimal TotalCost { get; set; }
        public virtual DateTime Date { get; set; }
    }
}