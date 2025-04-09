using System.ComponentModel.DataAnnotations.Schema;

namespace BackendHectorDeLeon.Models
{
    public class Beer
    {
        public int BeerId { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }

        [Column (TypeName ="decimal(18,2)")]
        public decimal Alcohol { get; set; }

        [ForeignKey("BrandId")] 

        public virtual Brand Brand { get; set; }
    }
}
