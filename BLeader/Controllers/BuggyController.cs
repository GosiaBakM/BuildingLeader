

using DAL.Data.Entities;
using DAL.Storage.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly BLeaderContext _context;

        public BuggyController(BLeaderContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret text";
        }

        [HttpGet("not-found")]
        public ActionResult<UserViewModel> GetNotFound()
        {
            var user = _context.Users.Find(-1);

            if(user == null)
            {
                return NotFound();
            }

            return new UserViewModel();

        }

        [HttpGet("server-error")]
        public ActionResult<UserViewModel> ServerError()
        {
            string nullString = null;
            nullString.ToLower();

            return new UserViewModel();
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This was not good request");
        }


    }
}
