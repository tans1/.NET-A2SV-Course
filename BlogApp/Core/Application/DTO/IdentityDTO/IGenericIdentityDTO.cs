﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.IdentityDTO
{
    public interface IGenericIdentityDTO
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
