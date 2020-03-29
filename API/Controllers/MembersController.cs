using SudaneseProgComLibrary;
using SudaneseProgComLibrary.Models;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace API.Controllers
{
    public class MembersController : ApiController
    {
        // GET api/members
        public IEnumerable<Member> Get()
        {
            return GlobalConfig.Connection.Get<Member>("spMembers_GetAll", CommandType.StoredProcedure);
        }

        // GET api/members/{id}
        [Route("members/{id}")]
        [HttpGet]
        public Member LoadMemberProfile(int Id)
        {
            return GlobalConfig.Connection.GetById<Member>("spMembers_GetById", Id, CommandType.StoredProcedure);
        }

        // POST: api/Members
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Members/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Members/5
        public void Delete(int id)
        {
        }
    }
}