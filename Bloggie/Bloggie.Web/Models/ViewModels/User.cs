﻿using System.ComponentModel.DataAnnotations;

namespace Bloggie.Web.Models.ViewModels
{
    public class User
    {
        public Guid Id { get; set; }
        public string UseerName { get; set; }
        public string Email { get; set; }
    }
}
