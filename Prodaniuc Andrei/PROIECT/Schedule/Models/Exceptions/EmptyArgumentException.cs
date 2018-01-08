using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Exceptions
{
    public class EmptyArgumentException : ArgumentException
    {
        public ArgumentCannotBeEmptyStringException(string parameterName)
            : base(string.Format("Argument {0} cannot be empty string.", parameterName), parameterName)
        {

        }
    }
}
