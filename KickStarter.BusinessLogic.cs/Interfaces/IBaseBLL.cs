using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace KickStarter.BusinessLogic.Interfaces
{
    [ServiceContract(Name = "IBaseBLL")]
    public interface IBaseBLL : IDisposable
    {

    }
}
