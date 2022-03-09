//@CodeCopy
//MdStart

namespace QTProjectTeam.Logic
{
    public interface IVersionable : IIdentifyable
    {
        byte[]? RowVersion { get; }
    }
}
//MdEnd
