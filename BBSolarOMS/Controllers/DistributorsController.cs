using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BBSolarOMS.Entities;
using BBSolarOMS.Model.DistributorModels;
using BBSolarOMS.Services.DistributorRepo;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BBSolarOMS.Controllers
{
    [Route("api/distributor")]
    public class DistributorsController : Controller
    {
        private IDistributorRepository _distributor;
        public DistributorsController(IDistributorRepository distributor)
        {
            _distributor = distributor;
        }
        // GET: api/<controller>
        [HttpGet]
        public IActionResult GetDistributors()
        {
            var distributorFromRepo = _distributor.GetDistributors();
            var distributor = Mapper.Map<IEnumerable<DistributorDto>>(distributorFromRepo);

            return Ok(distributor);
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name ="GetDistributor")]
        public IActionResult GetDistributor(Guid id)
        {
            var DistributorFromRepo = _distributor.GetDistributor(id);
            if (DistributorFromRepo == null)
            {
                return NotFound();
            }
            var distributor = Mapper.Map<DistributorDto>(DistributorFromRepo);
            return Ok(distributor);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult CreateDistributor([FromBody]DistributorForCreationDto distributor)
        {
            if(distributor==null)
            {
                return BadRequest();
            }

            var distributorForEntity = Mapper.Map<Distributor>(distributor);
            _distributor.AddDistributor(distributorForEntity);
            if(!_distributor.Save())
            {
                throw new Exception("Distributor Creation failed on save");
            }

            var DistributorToReturn = Mapper.Map<DistributorDto>(distributorForEntity);
            return CreatedAtRoute("GetDistributor", new { id = DistributorToReturn.Id }, DistributorToReturn);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult UpdateDistributor(Guid id, [FromBody]DistributorForUpdateDto distributor)
        {
            if (distributor == null)
            {
                return BadRequest();
            }
            var distributorFromRepo = _distributor.GetDistributor(id);
            if (distributorFromRepo == null)
            {
                return NotFound();
            }
            Mapper.Map(distributor, distributorFromRepo);
            _distributor.DistributorUpdate(distributorFromRepo);
            if (!_distributor.Save())
            {
                throw new Exception($"Deleting Installer with id {id} failed to Delete");
            }

            var InstallerToReturn = Mapper.Map<DistributorDto>(distributorFromRepo);
            //return CreatedAtRoute("GetInstaller", new { id = InstallerToReturn.Id }, InstallerToReturn);

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateDistributorDetails(Guid id,[FromBody]JsonPatchDocument<DistributorForUpdateDto> PatchDis)
        {
            if(PatchDis==null)
            {
                return BadRequest();
            }

            var disFromRepo = _distributor.GetDistributor(id);
            if(disFromRepo==null)
            {
                return NotFound();
            }

            var disTOPatch = Mapper.Map<DistributorForUpdateDto>(disFromRepo);
            PatchDis.ApplyTo(disTOPatch);

            Mapper.Map(disTOPatch, disFromRepo);
            _distributor.DistributorUpdate(disFromRepo);
            if(!_distributor.Save())
            {
                throw new Exception($"Updating distributor with if {id} faied on save");
            }
            return NoContent();
        }
        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDistributor(Guid id)
        {
            var DistributorFromRepo = _distributor.GetDistributor(id);
            if (DistributorFromRepo == null)
            {
                return NotFound();
            }
            _distributor.DeleteDistributor(DistributorFromRepo);
            if (!_distributor.Save())
            {
                throw new Exception($"Deleting Installer with id {id} failed, Please retry");
            }
            return NoContent();
        }
    }
}
