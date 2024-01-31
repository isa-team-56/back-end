using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers
{
    [Authorize(Policy = "allRolesPolicy")]
    [Route("api/company")]
    public class CompanyController : BaseApiController
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<PagedResult<CompanyDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _companyService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [Authorize(Policy = "administratorsPolicy")]
        [HttpPost]
        public ActionResult<CompanyDto> Create([FromBody] CompanyDto company)
        {
            var result = _companyService.Create(company);
            return CreateResponse(result);
        }

        [Authorize(Policy = "administratorcPolicy")]
        [HttpPut("{id:int}")]
        public ActionResult<CompanyDto> Update([FromBody] CompanyDto company)
        {
            var result = _companyService.Update(company);
            return CreateResponse(result);
        }
        [Authorize(Policy = "administratorsPolicy")]
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _companyService.Delete(id);
            return CreateResponse(result);
        }

        [HttpPut("getCompaniesByEquipment")]
        public ActionResult<CompanyDto> GetCompaniesByEquipment([FromBody]EquipmentDto equipment)
        {
            return CreateResponse(_companyService.GetCompaniesByEquipment(equipment));
        }
    }
}
