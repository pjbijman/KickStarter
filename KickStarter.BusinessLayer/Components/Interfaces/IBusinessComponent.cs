using System;
using System.Collections.Generic;

namespace KickStarter.BusinessLayer.Components.Interfaces
{
    public interface IBusinessComponent : IDisposable
    {
        Guid InstanceGuid { get; }
        HashSet<string> ValidationResults { get; }
        bool IsValid { get; }
    }
}
