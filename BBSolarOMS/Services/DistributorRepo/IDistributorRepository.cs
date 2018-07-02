using BBSolarOMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBSolarOMS.Services.DistributorRepo
{
    public interface IDistributorRepository
    {
        IEnumerable<Distributor> GetDistributors();
        Distributor GetDistributor(Guid id);
        IEnumerable<Distributor> GetDistributors(IEnumerable<Guid> id);
        void AddDistributor(Distributor distributor);
        void DistributorUpdate(Distributor distributor);
        bool DistributorExists(Guid id);
        void DeleteDistributor(Distributor distributor);
        bool Save();
    }
}
