using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AspNet.Security.OAuth.Validation;
using Carnival.Bll.Interfaces;
using Carnival.Data.Models;
using Carnival.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Carnival.Web.Api{
    [Authorize(AuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
    [Route("api/sampleData")]
    public class SampleDataController : Controller
    {
        private IPostService _sampleDataService;
        private readonly UserManager<User> _userManager;

        public SampleDataController(IPostService sampleDataService, UserManager<User> userManager)
        {
            _sampleDataService = sampleDataService;
            _userManager = userManager;
        }

        /// <summary>
        /// Returns a single TestData record with matching Id
        /// </summary>
        /// <remarks>This method will return an IActionResult containing the TestData record and StatusCode 200 if successful. 
        /// If there is a an error, you will get a status message and StatusCode which will indicate what was the error.</remarks>
        /// <param name="id">the ID of the record to retrieve</param>
        /// <returns>an IActionResult</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var testData = await _sampleDataService.GetById(id);
            if (testData == null)
            {
                return Json(NoContent());
            }

            return Json(Ok(testData));
        }

        // GET: api/sampleData
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = User;
            var testData = _sampleDataService.Get();

            if (!testData.Any())
            {
                return Json(NoContent());
            }

            return Json(Ok(await testData.ToListAsync()));
        }

        // POST api/sampleData
        [HttpPost]
        public IActionResult Post([FromBody]TestData value)
        {
            ICollection<ValidationResult> results = new List<ValidationResult>();

            if (!value.IsModelValid(out results))
            {
                return Json(BadRequest(results));
            }
            value.Username = User.Identity.Name;
            var newTestData = _sampleDataService.Save(value);
            if (newTestData == null)
                return Json(NotFound("An error occurred; new record not saved"));
            return Json(Ok(newTestData.Result.Entity as TestData));
        }

        // PUT api/sampleData/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]TestData value)
        {
            ICollection<ValidationResult> results = new List<ValidationResult>();

            if (!value.IsModelValid(out results))
            {
                return Json(BadRequest(results));
            }

            bool result = await _sampleDataService.Update(value);
            if(result == true)
                return Json(Ok(value));
            return Json(NotFound("Record not found"));



        }

        // DELETE api/sampleData/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            bool IsDeleted = await _sampleDataService.Delete(id);
            if (IsDeleted == false)
            {
                return Json(NotFound("Record not found; not deleted"));
            }
            return Json(Ok("deleted"));
        }
    }
}
