using OnlineStore.Domain.DataObjects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.SharedClasses
{
    public class CategoryBrand
    {
        [Key]
        public int Id { get; set; }
        public string CategoryDescription { get; set; }
        public List<tblBrands> tblBrands { get; set; }
    }
}
