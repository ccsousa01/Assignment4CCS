using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataLayer.Model
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("OrderDate", TypeName = "date")]
        public DateTime? Date { get; set; } = new DateTime();
        [Column("RequireDate", TypeName = "date")]
        public DateTime? Require { get; set; } = new DateTime();
        [Column("ShippedDate", TypeName = "date")]
        public DateTime? Shipped { get; set; }
        public double Freight { get; set; }
        [MaxLength(40, ErrorMessage = "ShipName must not be longer than 40 characters.")]
        public string ShipName { get; set; } = null;
        [MaxLength(10, ErrorMessage = "ShipCity must not be longer than 10 characters.")]
        public string ShipCity { get; set; } = null;

        /// <summary> foreign key navigation property </summary>
        public virtual ICollection<OrderDetails> Details { get; set; } = null;
    }
}
