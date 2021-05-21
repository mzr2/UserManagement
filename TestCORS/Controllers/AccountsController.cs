using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCORS.Base;
using TestCORS.Repository.Data;
using UserManagement.Models;

namespace TestCORS.Controllers
{
    public class AccountsController : BaseController<Account, AccountRepository, string>
    {
        private readonly AccountRepository repository;

        public AccountsController(AccountRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetUserData()
        {
            var result = await repository.GetUserData();
            return Json(result);
        }

        public async Task<JsonResult> GetUserDataDetail(string Nik)
        {
            var result = await repository.GetUserDataDetail(Nik);
            return Json(result);
        }
    }
}
