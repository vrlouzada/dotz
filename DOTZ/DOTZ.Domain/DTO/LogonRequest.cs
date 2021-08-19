using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace DOTZ.Domain.DTO
{
    public class LogonRequest
    {
        public string Login { get; set; }
        public string Pass { get; set; }
        public string PassRepeat { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public void Validate()
        {
            if (this.Pass != this.PassRepeat)
                throw new Exception("The pass is not similar to each other.");

            if (string.IsNullOrEmpty(this.FirstName))
                throw new Exception("The first name is required.");

            if (string.IsNullOrEmpty(this.LastName))
                throw new Exception("The last name is required.");

            try
            {
                var mail = new MailAddress(this.Login);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
