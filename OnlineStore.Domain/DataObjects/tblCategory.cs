using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Domain.DataObjects
{
    public class tblCategory
    {
        [Key]
        public int Id { get; set; }
        public string CategoryDescription { get; set; }
    }
}
