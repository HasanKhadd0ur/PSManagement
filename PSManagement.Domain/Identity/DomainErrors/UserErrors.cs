using PSManagement.SharedKernel.DomainErrors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Identity.DomainErrors
{
    public class UserErrors
    {
        public static readonly DomainError AlreadyUserExist = new ("The User Email Already Exist.", new DomainError("User email is already exist"));
        public static readonly DomainError InvalidLoginAttempt = new ("The User Email or Password Are Incorrect.",new DomainError( "invalid credentails for login"));

    }
}
