﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AccountManager.DataAccess.Entities
{
    public class User : IdentityUser
    {
        public string DisplayName { get; set; }
    }
}
