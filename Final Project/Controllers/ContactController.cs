using Final_Project.Services;
using Final_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Controllers
{
    public class Contact : Controller
    {
        private readonly IConfiguration _config;

        public Contact(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ContactVM contactVM)
        {
            var inputemail = contactVM.Email;
            var inputname = contactVM.Name;
            var inputmessage = contactVM.Message;

            EmailService emailService = new EmailService(_config.GetSection("ConfirmationParameter:Email").Value, _config.GetSection("ConfirmationParameter:Password").Value);
            var emailResult = emailService.SendEmail("orxan0100@hotmail.com", inputname, inputmessage + " " + inputemail);



            return View();
        }
    }
}
