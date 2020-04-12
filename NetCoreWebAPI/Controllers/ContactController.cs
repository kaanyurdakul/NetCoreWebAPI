using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreWebAPI.Models;

namespace NetCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class Contact : Controller
    {
        [HttpGet("")]
        public List<ContactModel> Get()
        {
            return new List<ContactModel>
            {
                new ContactModel
                {
                    Id = 1,
                    Firstname = "Kaan",
                    Lastname = "Yurdakul"
                }
            };
        }
    }
}