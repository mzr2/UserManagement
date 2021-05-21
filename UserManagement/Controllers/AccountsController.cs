using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using UserManagement.Base;
using UserManagement.Context;
using UserManagement.Models;
using UserManagement.Repository.Data;
using UserManagement.Service;
using UserManagement.ViewModel;
using UserManagement.Encryptions;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.AspNetCore.Cors;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    [Consumes("application/json")]
    public class AccountsController : BaseController<Account, AccountRepository, string>
    {
        private readonly AccountRepository accountRepository;
        private readonly MyContext myContext;
        private readonly IEmailService _emailService;
        public IConfiguration _configuration;
        public AccountsController(AccountRepository accountRepository, MyContext myContext, IEmailService emailService, IConfiguration configuration) : base(accountRepository)
        {
            this.accountRepository = accountRepository;
            this.myContext = myContext;
            _emailService = emailService;
            _configuration = configuration;
        }

        [EnableCors("AllowOrigin")]
        [HttpPost("Register")]
        [Produces("application/json")]
        public IActionResult Register(RegisterVM registerVM)
        {
            try
            {
                Person person = new Person();
                person.NIK = registerVM.NIK;
                person.FirstName = registerVM.FirstName;
                person.LastName = registerVM.LastName;
                person.Phone = registerVM.Phone;
                person.BirthDate = registerVM.BirthDate;
                person.Salary = registerVM.Salary;
                person.Email = registerVM.Email;
                myContext.Persons.Add(person);
                myContext.SaveChanges();

                try
                {
                    Account account = new Account();
                    account.NIK = registerVM.NIK;
                    account.Password = Hashing.HashPassword(registerVM.Password);
                    myContext.Accounts.Add(account);
                    myContext.SaveChanges();
                    try
                    {
                        RoleAccount roleAccount = new RoleAccount();
                        Role role = myContext.Roles.Where(r => r.RoleName == "User").FirstOrDefault();
                        roleAccount.NIK = registerVM.NIK;
                        roleAccount.RoleId = role.RoleId;
                        myContext.RoleAccounts.Add(roleAccount);
                        myContext.SaveChanges();

                        try
                        {
                            Education education = new Education();
                            education.Degree = registerVM.Degree;
                            education.GPA = registerVM.GPA;
                            education.UniversityId = registerVM.UniversityId;
                            myContext.Educations.Add(education);
                            myContext.SaveChanges();

                            Profiling profiling = new Profiling();
                            profiling.NIK = registerVM.NIK;
                            profiling.EducationId = education.EducationId;
                            myContext.Profilings.Add(profiling);
                            myContext.SaveChanges();

                            return Ok($"Register Atas Nama {registerVM.FirstName} {registerVM.LastName} Berhasil");
                        }
                        catch (Exception)
                        {
                            var delPerson = myContext.Persons.Find(registerVM.NIK);
                            myContext.Persons.Remove(delPerson);
                            myContext.SaveChanges();
                            var delAccount = myContext.Accounts.Find(registerVM.NIK);
                            myContext.Accounts.Remove(delAccount);
                            myContext.SaveChanges();
                            return StatusCode(405, new { status = HttpStatusCode.MethodNotAllowed, message = "Education's Attribute Data Type Not Allowed" });
                        }
                    }
                    catch (Exception)
                    {
                        return StatusCode(404, new { status = HttpStatusCode.NotFound, message = "Role Not Found" });
                    }
                }
                catch (Exception)
                {
                    var delPerson = myContext.Persons.Find(registerVM.NIK);
                    myContext.Persons.Remove(delPerson);
                    var result = myContext.SaveChanges();
                    return StatusCode(405, new { status = HttpStatusCode.MethodNotAllowed, message = "Password Data Type Not Allowed" });
                }
            }
            catch (Exception)
            {
                return StatusCode(403, new { status = HttpStatusCode.Forbidden, message = "Duplicate NIK" });
            }
            
        }

        //[Authorize]
        [EnableCors("AllowOrigin")]
        [HttpGet("UserData")]
        public async Task<IActionResult> Account()
        {
            var data = await (
                from person in myContext.Persons
                join account in myContext.Accounts
                on person.NIK equals account.NIK
                join profiling in myContext.Profilings
                on account.NIK equals profiling.NIK
                join education in myContext.Educations
                on profiling.EducationId equals education.EducationId
                join university in myContext.Universities
                on education.UniversityId equals university.UniversityId
                join roleAccount in myContext.RoleAccounts
                on account.NIK equals roleAccount.NIK
                join role in myContext.Roles
                on roleAccount.RoleId equals role.RoleId
                select new
                {
                    NIK = person.NIK,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Phone = person.Phone,
                    BirthDate = person.BirthDate,
                    Salary = person.Salary,
                    Email = person.Email,
                    EducationId = profiling.EducationId,
                    Degree = education.Degree,
                    GPA = education.GPA,
                    UniversityId = education.UniversityId,
                    UniversityName = university.Name,
                    RoleId = roleAccount.RoleId,
                    Role = role.RoleName
                }
                ).ToListAsync();
            return Ok(data);
        }

        //[Authorize(Roles = "Admin")]
        [EnableCors("AllowOrigin")]
        [HttpGet("Profile/{NIK}")]
        public IActionResult Account(string NIK)
        {
            var data = (
                from person in myContext.Persons
                join account in myContext.Accounts
                on person.NIK equals account.NIK
                join profiling in myContext.Profilings
                on account.NIK equals profiling.NIK
                join education in myContext.Educations
                on profiling.EducationId equals education.EducationId
                join university in myContext.Universities
                on education.UniversityId equals university.UniversityId
                join roleAccount in myContext.RoleAccounts
                on account.NIK equals roleAccount.NIK
                join role in myContext.Roles
                on roleAccount.RoleId equals role.RoleId
                where person.NIK == NIK
                select new
                {
                    NIK = person.NIK,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Phone = person.Phone,
                    BirthDate = person.BirthDate,
                    Salary = person.Salary,
                    Email = person.Email,
                    EducationId = profiling.EducationId,
                    Degree = education.Degree,
                    GPA = education.GPA,
                    UniversityId = education.UniversityId,
                    UniversityName = university.Name,
                    RoleId = roleAccount.RoleId,
                    Role = role.RoleName
                }
                ).FirstOrDefault();
            return Ok(data);
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginVM loginVM)
        {
            var person = myContext.Persons.Where(p => p.Email == loginVM.Email).FirstOrDefault();
            if (person != null)
            {
                var account = myContext.Accounts.Where(a => a.NIK == person.NIK).FirstOrDefault();
                if (account != null && Hashing.VerifyPassword(loginVM.Password, account.Password))
                {
                    var roleAccount = myContext.RoleAccounts.Where(ra => ra.NIK == account.NIK).ToList();
                    var claims = new List<Claim> {
                    new Claim("NIK", person.NIK),
                    new Claim("FirstName", person.FirstName),
                    new Claim("LastName", person.LastName),
                    new Claim("Email", person.Email)
                    };
                    foreach (var item in roleAccount)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, myContext.Roles.Where(r => r.RoleId == item.RoleId).FirstOrDefault().RoleName));
                    }

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddMinutes(10), signingCredentials: signIn);

                    return StatusCode(200, new { status = HttpStatusCode.OK, message = "", person.Email, token = new JwtSecurityTokenHandler().WriteToken(token) });
                }
                else
                {
                    return StatusCode(404, new { status = HttpStatusCode.NotFound, message = "Wrong Password" });
                }
            }
            else
            {
                return StatusCode(404, new { status = HttpStatusCode.NotFound, message = "Email Not Found" });
            }
        }

        [HttpGet("Login")]
        public IActionResult Login(string email, string password)
        {
            var person = myContext.Persons.Where(p => p.Email == email).FirstOrDefault();
            if (person != null)
            {
                var account = myContext.Accounts.Where(a => a.NIK == person.NIK).FirstOrDefault();
                if (account != null && Hashing.VerifyPassword(password, account.Password))
                {
                    return Account(person.NIK);
                }
                else
                {
                    return StatusCode(404, new { status = HttpStatusCode.NotFound, message = "Wrong Password" });
                }
            }
            else
            {
                return StatusCode(404, new { status = HttpStatusCode.NotFound, message = "Email Not Found" });
            }
        }
        
        [HttpPost("Update")]
        public IActionResult Update(RegisterVM registerVM)
        {
            Person person = new Person();
            person.NIK = registerVM.NIK;
            person.FirstName = registerVM.FirstName;
            person.LastName = registerVM.LastName;
            person.Phone = registerVM.Phone;
            person.BirthDate = registerVM.BirthDate;
            person.Salary = registerVM.Salary;
            person.Email = registerVM.Email;
            myContext.Entry(person).State = EntityState.Modified;
            myContext.SaveChanges();

            Account account = new Account();
            account.NIK = registerVM.NIK;
            account.Password = Hashing.HashPassword(registerVM.Password);
            myContext.Entry(account).State = EntityState.Modified;
            myContext.SaveChanges();

            Profiling profiling = new Profiling();
            profiling.NIK = registerVM.NIK;
            profiling.EducationId = myContext.Profilings.Where(p => p.NIK == registerVM.NIK).FirstOrDefault().EducationId;
            myContext.Entry(profiling).State = EntityState.Modified;
            myContext.SaveChanges();

            Education education = new Education();
            education.EducationId = profiling.EducationId;
            education.Degree = registerVM.Degree;
            education.GPA = registerVM.GPA;
            education.UniversityId = registerVM.UniversityId;
            myContext.Entry(education).State = EntityState.Modified;
            myContext.SaveChanges();

            return Ok();
        }
        [Authorize]
        [HttpPost("UpdatePassword")]
        public IActionResult UpdatePassword(ChangePasswordVM changePasswordVM)
        {
            var person = myContext.Persons.Where(p => p.Email == changePasswordVM.Email).FirstOrDefault();
            if (person != null)
            {
                var account = myContext.Accounts.Where(a => a.NIK == person.NIK).FirstOrDefault();
                if (account != null && Hashing.VerifyPassword(changePasswordVM.OldPassword, account.Password))
                {
                    Account newAccount = new Account();
                    newAccount = myContext.Accounts.Find(person.NIK);
                    newAccount.NIK = person.NIK;
                    newAccount.Password = Hashing.HashPassword(changePasswordVM.NewPassword);
                    myContext.Accounts.Update(newAccount);
                    myContext.SaveChanges();
                    return Ok("Password Updated");
                }
                else
                {
                    return StatusCode(404, new { status = HttpStatusCode.NotFound, message = "Wrong Password" });
                }
            }
            else
            {
                return StatusCode(404, new { status = HttpStatusCode.NotFound, message = "Email Not Found" });
            }
        }

        [HttpGet("SendEmail")]
        public async Task<IActionResult> SendMail()
        {
            UserEmailOptions options = new UserEmailOptions
            {
                ToEmails = new List<string>() { "test@gmail.com" }
            };

            await _emailService.SendTestEmail(options);
            return Ok("Email Sent");
        }

        public string RandomString()
        {
            Random r = new Random();
            string[] ran = new string[8];
            string alphaNumeric = "abcdefghijklmnopqrstuvwxyz1234567890";
            char[] ch = new char[alphaNumeric.Length];

            
            for (int i = 0; i < alphaNumeric.Length; i++)
            {
                ch[i] = alphaNumeric[i];
            }

            for (int i = 0; i < 8; i++)
            {
                int rInt = r.Next(0, alphaNumeric.Length - 1);
                ran[i] = Convert.ToString(ch[rInt]);
            }

            return $"{ran[0]}{ran[1]}{ran[2]}{ran[3]}{ran[4]}{ran[5]}{ran[6]}{ran[7]}";
        }

        [HttpPost("SendEmail2")]
        public IActionResult SendMail2(ForgotPasswordVM forgotPasswordVM)
        {
            var newPass = RandomString();
            Person person = myContext.Persons.Where(p => p.Email == forgotPasswordVM.Email).FirstOrDefault();
            if (person!=null)
            {
                Account newAccount = myContext.Accounts.Find(person.NIK);
                newAccount.NIK = newAccount.NIK;
                newAccount.Password = Hashing.HashPassword(newPass);
                myContext.Accounts.Update(newAccount);
                myContext.SaveChanges();
                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("hidgastg@gmail.com", "inayah71"),
                    EnableSsl = true
                };
                client.Send("hidgastg@gmail.com", forgotPasswordVM.Email, "RESET PASSWORD REQUEST", $"Hello {person.FirstName} {person.LastName} \nHere is Your New Password : {newPass}");
                return Ok("Request Sent");
            }
            else
            {
                return NotFound("Email Not Found");
            }

        }
    }
}
