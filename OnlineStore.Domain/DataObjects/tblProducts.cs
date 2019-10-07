using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Domain.DataObjects
{
    public class tblProducts
    {
        [Key]
        public int Id { get; set; }
        public int Brand_Id { get; set; }
        public int Category_Id { get; set; }
        public int Supplier_Id { get; set; }
        public string Product_Code { get; set; }
        public byte[] Badge { get; set; }
        public int Stock_Count { get; set; }
        public string Condition { get; set; }
        public string Product_Description { get; set; }
        public decimal? Price { get; set; }
        public DateTime? Update_Date { get; set; }
        public string User_Id { get; set; }
    }
}
