using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UCRMTS.dll
{
    public class UCRException :Exception
    {
        public HttpStatusCode HttpStatusCode { get;  }
        public UCRException(string jsonMessage ,HttpStatusCode httpStatusCode)
            :base(jsonMessage)
        {
            this.HttpStatusCode = httpStatusCode;
        }
    }
}
