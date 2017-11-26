using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carnival.Bll.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Carnival.Web.Api
{
    [Produces("application/json")]
    [Route("api/Profile")]
    public class ProfileController : Controller
    {
        private IPostService _postService;
        private IProfileService _profileService;

        public ProfileController(IProfileService profileService, IPostService postService)
        {
            _profileService = profileService;
            _postService = postService;
        }
        // GET: api/Profile
        [HttpGet]
        public IActionResult Get()
        {
            string yourId = User.Claims.FirstOrDefault(c => c.Type == "sub").Value;
            var yourprofile = _profileService.GetOrCreateProfile(yourId);
             
            return Json(Ok(yourprofile));
        }

        // GET: api/Profile/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Profile
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Profile/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
