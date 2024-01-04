namespace DevCodeChallenge.Models
{
    public class PurchaseDto
    {
        public virtual int Id { get; set; }
        public virtual int Quantity { get; set; }
        public virtual decimal TotalCost { get; set; }
        public virtual string Date { get; set; }
    }
}
