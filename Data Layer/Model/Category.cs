
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Model
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(15, ErrorMessage = "Category Name must not be longer than 15 characters.")]       
        public string Name { get; set; } = null;
        [MaxLength(300, ErrorMessage = "Category Description must not be longer than 300 characters.")]
        public string Description { get; set; } = null;

        /// <summary> foreign key navigation property </summary>
        public virtual ICollection<Product> Product { get; set; }
    }
}
