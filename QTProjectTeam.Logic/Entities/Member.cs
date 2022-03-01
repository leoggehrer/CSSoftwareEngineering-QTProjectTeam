namespace QTProjectTeam.Logic.Entities
{
    [Table("Members", Schema = "App")]
    public class Member : VersionEntity
    {
        public int ProjectId { get; set; }
        [Required]
        [MaxLength(64)]
        public string Firstname { get; set; } = string.Empty;
        [Required]
        [MaxLength(64)]
        public string Lastname { get; set; } = string.Empty;
        [MaxLength(2048)]
        public string? Note { get; set; }

        // Navigation properties
        public Project? Project { get; set; }
    }
}
