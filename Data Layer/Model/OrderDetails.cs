
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Model
{
    public class OrderDetails
    {        
        public int OrderId { get; set; }       
        public int ProductId { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }

        /// <summary> foreign key navigation property </summary>  
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        /// <summary> foreign key navigation property </summary>      
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
