using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalSystem.Exceptions
{
    public class JobPortalSystemException:ApplicationException
    {
        public JobPortalSystemException()
            : base()
        {
        }

        public JobPortalSystemException(string message)
            : base(message)
        {
        }
        public JobPortalSystemException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
