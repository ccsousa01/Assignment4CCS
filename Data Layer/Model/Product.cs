
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Model
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(40, ErrorMessage = "Product Name must not be longer than 40 characters.")]
        public string Name { get; set; } = null;
        public double UnitPrice { get; set; }
        [MaxLength(20, ErrorMessage = "Product Quantity-Per-Unit must not be longer than 20 characters.")]
        public string QuantityPerUnit { get; set; } = null;
        public int UnitsInStock { get; set; }

        /// <summary> foreign key </summary>
        public int CategoryID { get; set; }
        /// <summary> foreign key navigation property </summary>
        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
        /// <summary> foreign key navigation property </summary>
        public virtual ICollection<OrderDetails> Details { get; set; }
    }
}
