//@CodeCopy
//MdStart

using QTProjectTeam.Logic.Controllers;

namespace QTProjectTeam.Logic.Facades
{
    public abstract class FacadeObject
    {
        internal ControllerObject ControllerObject { get; private set; }

        protected FacadeObject(ControllerObject controllerObject)
        {
            ControllerObject = controllerObject;
        }
    }
}

//MdEnd
