
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop
{
    class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SupplyId { get; set; }
        public Supply Supply { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public string Name { get; set; }
        public string Description{ get;set;}
        public decimal BuyCost { get; set; }
        public decimal SellCost { get; set; }
        public int Quantity { get; set; }
    }
}
