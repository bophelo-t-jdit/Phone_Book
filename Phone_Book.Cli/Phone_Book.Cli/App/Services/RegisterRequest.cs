using System;
using System.Collections.Generic;
using System.Text;

namespace Phone_Book.Cli.App.Services
{
    public class RegisterRequest
    {
        public string Username { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
