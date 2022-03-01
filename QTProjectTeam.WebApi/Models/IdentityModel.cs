//@CodeCopy
//MdStart
using System.ComponentModel.DataAnnotations;

namespace QTProjectTeam.WebApi.Models
{
    public abstract partial class IdentityModel
    {
        /// <summary>
        /// ID of the entity (primary key)
        /// </summary>
        [Key]
        public int Id { get; set; }
    }
}
//MdEnd
