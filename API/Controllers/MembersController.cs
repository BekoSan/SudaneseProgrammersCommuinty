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
            IEnumerable<Member> output = new List<Member>();

            if (GlobalConfig.NoSqlConnection != null)
            {
                output = GlobalConfig.NoSqlConnection.LoadRecords<Member>("Members");
            }
            if (GlobalConfig.Connection != null)
            {
                output = GlobalConfig.Connection.Get<Member>("spMembers_GetAll", CommandType.StoredProcedure);
            }
            return output;
        }

        // GET api/members/{id}
        [HttpGet]
        public Member LoadMemberProfile(int Id)
        {
            Member output = new Member();

            if (GlobalConfig.NoSqlConnection != null)
            {
                output = GlobalConfig.NoSqlConnection.LoadRecordById<Member>("Members", Id);
            }
            if (GlobalConfig.Connection != null)
            {
                output = GlobalConfig.Connection.GetById<Member>("spMembers_GetById", Id, CommandType.StoredProcedure);
            }
            return output;
        }

        // POST: api/Members

        public void Post(Member member)
        {
            if (GlobalConfig.NoSqlConnection != null)
            {
                GlobalConfig.NoSqlConnection.InsertRecord("Members", member);
            }
            if (GlobalConfig.Connection != null)
            {
                GlobalConfig.Connection.Create(member, "spMembers_Insert", CommandType.StoredProcedure);
            }
        }

        // PUT: api/Members/5
        public void Put(int id, Member member)
        {
            GlobalConfig.Connection.Update(member, "spMembers_Update", CommandType.StoredProcedure);
        }

        // DELETE: api/Members/5
        public void Delete(int id)
        {
            GlobalConfig.Connection.Delete<Member>(id, "spMembers_Delete", CommandType.StoredProcedure);
        }
    }
}