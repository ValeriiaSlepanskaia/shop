using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop
{
    class Supply
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
        public DateTime deliveryDate { get; set; }
    }
}
