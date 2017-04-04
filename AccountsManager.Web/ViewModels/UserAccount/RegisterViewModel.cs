﻿using System.ComponentModel.DataAnnotations;

namespace AccountsManager.Web.ViewModels.UserAccount
{
    public class RegisterViewModel
    {
        [Required, MaxLength(256)]
        public string DisplayName { get; set; }

        [Required, MaxLength(256)]
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
