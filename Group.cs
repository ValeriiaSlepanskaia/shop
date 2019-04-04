using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop
{
    class Group
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
