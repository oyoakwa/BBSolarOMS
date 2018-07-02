using BBSolarOMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBSolarOMS.Services.InstallerRepo
{
    public interface I_InstallerRepository
    {
        IEnumerable<Installers> GetInstallers();
        Installers GetInstaller(Guid id);
        IEnumerable<Installers> GetInstallers(IEnumerable<Guid> installerId);
        void AddInstaller(Installers instaler);
        void InstallerUpdate(Installers installer);
        bool InstallerExists(Guid installerId);
        void DeleteInsataller(Installers installer);
        bool Save();
    }
}
