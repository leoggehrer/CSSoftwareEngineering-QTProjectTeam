using System.ComponentModel.DataAnnotations;

namespace QTProjectTeam.AspMvc.Models
{
    public class Project : VersionModel
    {
        [Required]
        [MaxLength(10)]
        public string Number { get; set; } = string.Empty;
        [Required]
        [MaxLength(128)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(128)]
        public string? Description { get; set; }
    }
}
