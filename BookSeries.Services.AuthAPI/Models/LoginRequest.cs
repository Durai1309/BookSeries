﻿using System.ComponentModel.DataAnnotations;

namespace Bookservie.Services.AuthAPI.Models
{
    public class LoginRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
