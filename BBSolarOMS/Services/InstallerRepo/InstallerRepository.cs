using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBSolarOMS.Entities;

namespace BBSolarOMS.Services.InstallerRepo
{
    public class InstallerRepository : I_InstallerRepository
    {
        private BBSolarOMSContext _context;
        public InstallerRepository(BBSolarOMSContext context)
        {
            _context = context;
        }
        public void AddInstaller(Installers instaler)
        {
            instaler.Id = Guid.NewGuid();
            _context.Installers.Add(instaler);
        }

        public void DeleteInsataller(Installers installer)
        {
            _context.Installers.Remove(installer);
        }

        public Installers GetInstaller(Guid id)
        {
            return _context.Installers.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Installers> GetInstallers()
        {
            return _context.Installers
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .ToList();
        }

        public IEnumerable<Installers> GetInstallers(IEnumerable<Guid> installerId)
        {
            return _context.Installers.Where(a => installerId.Contains(a.Id))
            .OrderBy(a => a.FirstName)
            .ThenBy(a => a.LastName)
            .ToList();
        }

        public bool InstallerExists(Guid installerId)
        {
            return _context.Installers.Any(a => a.Id == installerId);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void InstallerUpdate(Installers installer)
        {
            //throw new NotImplementedException();
        }
    }
}
