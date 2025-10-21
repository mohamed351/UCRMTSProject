using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCRMTS.dll.DTOS
{
    public class AuthicationResponseDTO
    {

        public string AccessToken { get; set; } = string.Empty;

        public string TokenType { get; set; } = string.Empty;


        public int ExpiresIn { get; set; }

        public string Scope { get; set; }

    }
}
