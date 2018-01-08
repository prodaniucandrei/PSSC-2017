using System.Diagnostics.Contracts;

namespace Models
{
    public class Email
    {
        public PlainText Value { get; set; }

        public Email(PlainText value)
        {
            Contract.Requires(value != null, "email");
            Contract.Requires(value.Text.Contains("@"), "email");
            Value = value;
        }

        #region override object
        public override string ToString()
        {
            return Value.Text.ToString();
        }

        public override bool Equals(object obj)
        {
            var email = (Email)obj;

            if(email != null)
            {
                return Value.Equals(email.Value);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
        #endregion
    }
}