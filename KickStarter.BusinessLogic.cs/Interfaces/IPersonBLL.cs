using KickStarter.Library.Entities;
using System;
using System.ServiceModel;

namespace KickStarter.BusinessLogic.Interfaces
{
    [ServiceContract(Name = "IPersonBLL")]
    public interface IPersonBLL
    {
        [OperationContract]
        Person GetById(Guid PersonId);
    }
}
