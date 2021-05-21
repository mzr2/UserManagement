using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Base;
using UserManagement.Context;
using UserManagement.Models;
using UserManagement.Repository.Data;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    [EnableCors("AllowOrigin")]
    public class RoleAccountsController : BaseController<RoleAccount, RoleAccountRepository, string>
    {
        private readonly MyContext myContext;
        public RoleAccountsController(RoleAccountRepository roleAccountRepository, MyContext myContext) : base(roleAccountRepository)
        {
            this.myContext = myContext;
        }

        //[HttpPost("PostRolesAccount")]
        //public IActionResult PostRolesAccount(RoleAccount roleAccount)
        //{
        //    myContext.RolesAccounts.Add(roleAccount);
        //    myContext.SaveChanges();
        //    return Ok("Data Role Account Tersimpan");
        //}
    }
}
