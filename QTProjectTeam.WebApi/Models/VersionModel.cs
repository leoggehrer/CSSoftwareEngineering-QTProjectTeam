//@CodeCopy
//MdStart
using System.ComponentModel.DataAnnotations;

namespace QTProjectTeam.WebApi.Models
{
    public abstract partial class VersionModel : IdentityModel
    {
        /// <summary>
        /// Row version of the entity.
        /// </summary>
        [Timestamp]
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}
//MdEnd
