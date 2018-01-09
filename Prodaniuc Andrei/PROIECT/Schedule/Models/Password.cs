using System;
using System.Diagnostics.Contracts;

namespace Models
{
    public class Password
    {
        public PlainText Value { get; set; }

        public Password(PlainText value)
        {
            //Contract.Requires(value != null, "password");
            Value = new PlainText(EncryptPassword(value));
        }

        private string EncryptPassword(PlainText value)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(value.Text);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}