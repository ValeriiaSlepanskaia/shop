using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop
{
    class Provider
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Representative { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
    }
}
