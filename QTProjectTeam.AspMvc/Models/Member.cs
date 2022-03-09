﻿using System.ComponentModel.DataAnnotations;

namespace QTProjectTeam.AspMvc.Models
{
    public class Member : VersionModel
    {
        public int ProjectId { get; set; }
        [Required]
        [MaxLength(64)]
        [MinLength(3)]
        public string Firstname { get; set; } = string.Empty;
        [Required]
        [MaxLength(64)]
        [MinLength(3)]
        public string Lastname { get; set; } = string.Empty;
        [MaxLength(2048)]
        public string? Note { get; set; }
    }
}
