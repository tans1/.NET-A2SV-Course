using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.IdentityDTO.Validations
{
    public class AuthRequestValidation : AbstractValidator<AuthRequestDTO>
    {

        public AuthRequestValidation()
        {
            Include(new IGenericIdentityValidation());
        }
    }
}
