using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop
{
    class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int EmployeeId { get; set;}
        public Employee Employee { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public DateTime DateOfEnd { get; set; }
        public DateTime DateOfExecute { get; set; }
    }
}
