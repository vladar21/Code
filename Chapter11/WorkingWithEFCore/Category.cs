using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Packt.CS7
{
    public class Category
    {
        // эти свойства соотносятся со столбцами в БД
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        // определяет свойство navigation для связанных строк
        public virtual ICollection<Product> Products { get; set; }
        public Category()
        {
            // чтобы позволить разработчикам добавлять товары в Category,
            // мы должны инициализировать свойства navigation пустым списком
            this.Products = new List<Product>();
        }
    }
}
