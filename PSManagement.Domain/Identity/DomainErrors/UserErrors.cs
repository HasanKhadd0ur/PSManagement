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
        public static readonly DomainError AlreadyUserExist =  new ("The User Email Already Exist.", "User email is already exist");
        public static readonly DomainError InvalidLoginAttempt = new ("The User Email or Password Are Incorrect.", "invalid credentails for login");
        public static readonly DomainError UnExistUser =new  ("The User Dosn't Exist.","invalid credentails ,the provieded credential doesn't match any record");

    }
}
