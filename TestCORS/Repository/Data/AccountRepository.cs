using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TestCORS.Base;
using UserManagement.Models;
using UserManagement.ViewModel;

namespace TestCORS.Repository.Data
{
    public class AccountRepository : GeneralRepository<Account, string>
    {
        private readonly Address address;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpClient httpClient;
        public AccountRepository(Address address, string request = "Accounts/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", _contextAccessor.HttpContext.Session.GetString("JWToken"));
        }

        public async Task<List<AccountUserDataVM>> GetUserData()
        {
            List<AccountUserDataVM> entities = new List<AccountUserDataVM>();

            using (var response = await httpClient.GetAsync(request+"userdata"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<AccountUserDataVM>>(apiResponse);
            }
            return entities;
        }
        
        public async Task<AccountUserDataVM> GetUserDataDetail(string Nik)
        {
            AccountUserDataVM entities = new AccountUserDataVM();

            using (var response = await httpClient.GetAsync(request+ "Profile/" + Nik))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<AccountUserDataVM>(apiResponse);
            }
            return entities;
        }
    }
}
