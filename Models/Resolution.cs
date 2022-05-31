using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ipcam.Models
{
    public class Resolution
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, int.MaxValue, ErrorMessage = "Display Order be greater than 0")]
        public int DisplayOrder { get; set; }
    }
}
