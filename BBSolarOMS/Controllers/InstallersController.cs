using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BBSolarOMS.Entities;
using BBSolarOMS.Model.InstallerModels;
using BBSolarOMS.Services.InstallerRepo;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BBSolarOMS.Controllers
{
    [Route("api/installers")]
    public class InstallersController : Controller
    {
        private I_InstallerRepository _installerRepo;

        public InstallersController(I_InstallerRepository installerRepo)
        {
            _installerRepo = installerRepo;
        }
        
        [HttpGet]
        public IActionResult GetInstallers()
        {
            var installerFromRepo = _installerRepo.GetInstallers();
            var installers = Mapper.Map<IEnumerable<InstallerDto>>(installerFromRepo);

            return Ok(installers);
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name ="GetInstaller")]
        public IActionResult GetInstaller(Guid id)
        {
            var installerFromRepo = _installerRepo.GetInstaller(id);
            if(installerFromRepo==null)
            {
                return NotFound();
            }
            var installer = Mapper.Map<InstallerDto>(installerFromRepo);
            return Ok(installer);
        }

        // POST api/<controller>
        /// <summary>
        /// This Method crates an installer.
        /// </summary>
        /// <param name="instaler"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateInstaller([FromBody]InstallerForCreationDto instaler)
        {
            if(instaler==null)//
            {
                return BadRequest();
            }

            var installerForEntity = Mapper.Map<Installers>(instaler);
            _installerRepo.AddInstaller(installerForEntity);

            if(!_installerRepo.Save())
            {
                throw new Exception("Installer Creation failed on save");
            }

            var InstallerToReturn = Mapper.Map<Installers>(installerForEntity);
            return CreatedAtRoute("GetInstaller", new { id = InstallerToReturn.Id }, InstallerToReturn);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateInstallerDetails(Guid id, [FromBody]JsonPatchDocument<InstallerForUpdateDto> PatchIns)
        {
            if (PatchIns == null)
            {
                return BadRequest();
            }

            var InsFromRepo = _installerRepo.GetInstaller(id);
            if (InsFromRepo == null)
            {
                return NotFound();
            }

            var insTOPatch = Mapper.Map<InstallerForUpdateDto>(InsFromRepo);
            PatchIns.ApplyTo(insTOPatch);

            Mapper.Map(insTOPatch, InsFromRepo);
            _installerRepo.InstallerUpdate(InsFromRepo);
            if (!_installerRepo.Save())
            {
                throw new Exception($"Updating distributor with if {id} faied on save");
            }
            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteInstaller(Guid id)
        {
            var installerFromRepo = _installerRepo.GetInstaller(id);
            if(installerFromRepo==null)
            {
                return NotFound();
            }
            _installerRepo.DeleteInsataller(installerFromRepo);
            if(!_installerRepo.Save())
            {
                throw new Exception($"Deleting Installer with id {id} failed, Please retry");
            }
            return NoContent();
        }


        [HttpPut("{id}")]
        public IActionResult UpdateInstaller([FromBody]InstallerForUpdateDto installer, Guid id)
        {
            if(installer==null)
            {
                return BadRequest();
            }
            var installerFromRepo = _installerRepo.GetInstaller(id);
            if(installerFromRepo==null)
            {
                return NotFound();
            }
            Mapper.Map(installer, installerFromRepo);
            _installerRepo.InstallerUpdate(installerFromRepo);
            if(!_installerRepo.Save())
            {
                throw new Exception($"Deleting Installer with id {id} failed to Delete");
            }

            var InstallerToReturn = Mapper.Map<InstallerDto>(installerFromRepo);

            //return CreatedAtRoute("GetInstaller", new { id = InstallerToReturn.Id }, InstallerToReturn);

            return NoContent();
        }
    }
}
