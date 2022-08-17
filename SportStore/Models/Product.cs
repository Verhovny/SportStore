using System.ComponentModel.DataAnnotations;

namespace SportStore.Models
{
    public class Product
    {


        public long Id { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Пожайлуста введите Name")]
        public string Name { get; set; }
        
      
        
        
        [Required(ErrorMessage = "Пожайлуста введите PurchasePrice")]
        public float PurchasePrice { get; set; }
        
        [Required(ErrorMessage = "Пожайлуста введите RetailPrice")]
        public float RetailPrice { get; set; }



        [Required(ErrorMessage = "Пожайлуста введите категорию")]
        public long CategoryId { get; set; }
        public Category Category { get; set; }

            
    }
}
