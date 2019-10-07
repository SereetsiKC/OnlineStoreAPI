using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Domain.DataObjects
{
    public class tblBrands
    {
        [Key]
        public int Id { get; set; }
        public string Brand_Description { get; set; }
    }
}
