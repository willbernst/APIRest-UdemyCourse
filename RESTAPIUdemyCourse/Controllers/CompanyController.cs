using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RESTAPIUdemyCourse.Business;
using RESTAPIUdemyCourse.Data.VO;
using RESTAPIUdemyCourse.Hypermedia.Filters;
using RESTAPIUdemyCourse.Model;
using System.Collections.Generic;

namespace RESTAPIUdemyCourse.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Authorize("Bearer")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class CompanyController : ControllerBase
    {
        private readonly ILogger<CompanyController> _logger;
        private ICompanyBusiness _companyBusiness;

        public CompanyController(ILogger<CompanyController> logger, ICompanyBusiness companyBusiness)
        {
            _logger = logger;
            _companyBusiness = companyBusiness;
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(CompanyVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Create([FromBody] CompanyVO company)
        {
            if (company == null) return BadRequest();
            var createCompany = _companyBusiness.Create(company);
            return Ok(createCompany);
        }

        //[HttpGet]
        //[ProducesResponseType((200), Type = typeof(List<CompanyVO>))]
        //[ProducesResponseType(204)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(401)]
        //[TypeFilter(typeof(HyperMediaFilter))]
        //public IActionResult FindAll()
        //{
        //    return Ok(_companyBusiness.FindAll());
        //}

        [HttpGet("{sortDirection}/{pageSize}/{page}")]
        [ProducesResponseType((200), Type = typeof(CompanyVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult FindWithPagedSearch([FromQuery] string name, string sortDirection, int pageSize, int page)
        {
            return Ok(_companyBusiness.FindWithPagedSearch(name, sortDirection, pageSize, page));
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(CompanyVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult FindById(long id)
        {
            var companyId = _companyBusiness.FindById(id);
            if(companyId == null) return NotFound();
            return Ok(companyId);
        }

        [HttpGet("findCompanyByName")]
        [ProducesResponseType((200), Type = typeof(CompanyVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult FindByName([FromQuery] string stockName)
        {
            var company = _companyBusiness.FindByName(stockName);
            if (company == null) return NotFound();
            return Ok(company);
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(CompanyVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Update([FromBody] CompanyVO company)
        {
            if (company == null) return BadRequest();
            var updateCompany = _companyBusiness.Update(company);
            return Ok(updateCompany);
        }

        [HttpDelete]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(long id)
        {
            _companyBusiness.Delete(id);
            return NoContent();
        }
    }
}
