using ContactsApplication.Application.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactsApplication.API.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PeopleController
        (IPersonRepository personRepository)
        : ControllerBase
    {

        /// <summary>
        /// Get all people from database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllPeople()
        {
            var result = await personRepository.GetAll();
            return Ok(result);
        }
    }
}
