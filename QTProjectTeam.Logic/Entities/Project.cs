namespace QTProjectTeam.Logic.Entities
{
    [Table("Projects", Schema = "App")]
    [Index(nameof(Number), IsUnique = true)]
    public class Project : VersionEntity
    {
        [Required]
        [MaxLength(10)]
        public string Number { get; set; } = string.Empty;
        [Required]
        [MaxLength(128)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(128)]
        public string? Description { get; set; }

        // Navigation properties
        public List<Member> Members { get; set; } = new();
    }
}
