using System.Collections.Generic;
using TDDPOC.DAL.Entities;

namespace TDDPOC.DAL.Contracts
{
    public interface IClientInfoRepository
    {
        void Seed(IList<ClientInfoEntity> mockClients);
        IList<ClientInfoEntity> GetAll();
        ClientInfoEntity GetByID(int id);
    }
}
