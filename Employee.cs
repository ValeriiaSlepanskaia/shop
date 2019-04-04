using System;

using System.ComponentModel.DataAnnotations.Schema;


namespace Shop
{
    class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public DateTime Birth { get; set; }
        public decimal Salary { get; set; }
    }
}
