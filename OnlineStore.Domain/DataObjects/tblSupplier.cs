using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Domain.DataObjects
{
    public class tblSupplier
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
