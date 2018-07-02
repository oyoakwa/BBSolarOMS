using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBSolarOMS.Entities;

namespace BBSolarOMS.Services.DistributorRepo
{
    public class DistributorRepository : IDistributorRepository
    {
        private BBSolarOMSContext _context;

        public DistributorRepository(BBSolarOMSContext context)
        {
            _context = context;
        }

        public void AddDistributor(Distributor distributor)
        {
            distributor.Id = Guid.NewGuid();
            _context.Distributors.Add(distributor);
        }

        public void DeleteDistributor(Distributor distributor)
        {
            _context.Distributors.Remove(distributor);
        }

        public bool DistributorExists(Guid id)
        {
            return _context.Distributors.Any(a => a.Id == id);
        }

        public void DistributorUpdate(Distributor distributor)
        {
            //throw new NotImplementedException();
        }

        public Distributor GetDistributor(Guid id)
        {
            return _context.Distributors.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Distributor> GetDistributors()
        {
            return _context.Distributors
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .ToList();
        }

        public IEnumerable<Distributor> GetDistributors(IEnumerable<Guid> id)
        {
            return _context.Distributors.Where(a => id.Contains(a.Id))
             .OrderBy(a => a.FirstName)
             .ThenBy(a => a.LastName)
             .ToList();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
