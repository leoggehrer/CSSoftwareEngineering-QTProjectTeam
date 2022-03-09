namespace QTProjectTeam.WebApi.Models
{
    public class Project : VersionModel
    {
        public string? Number { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
