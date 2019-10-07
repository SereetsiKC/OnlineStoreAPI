using System.ComponentModel.DataAnnotations;

namespace OnlineStore.SharedClasses
{
    public class BrandsProducts
    {
        [Key]
        public int Id { get; set; }
        public string Brand_Description { get; set; }
        public int NumberOfProduct { get; set; }
    }
}
