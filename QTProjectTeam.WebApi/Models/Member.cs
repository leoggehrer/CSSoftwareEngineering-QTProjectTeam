﻿namespace QTProjectTeam.WebApi.Models
{
    public class Member : VersionModel
    {
        public int ProjectId { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Note { get; set; }
    }
}
