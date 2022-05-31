using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ipcam.Models
{
    public class Tariff
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Range(1, int.MaxValue)]
        public double Price { get; set; }
        public string? Image { get; set; }

        
        [Display(Name = "Resolution Type")]
        public int ResolutionId { get; set; }
        [ForeignKey("ResolutionId")]
        public virtual Resolution Resolution { get; set; }


        [Display(Name = "Period Type")]
        public int PeriodId { get; set; }
        [ForeignKey("PeriodId")]
        public virtual Period Period { get; set; }
    }
}
