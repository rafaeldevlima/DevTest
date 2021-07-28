using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTest.Shared.DTOs
{
    public class ResultDTO
    {
        public bool Success { get; set; }
        public string token { get; set; }
        public List<string> Messages { get; set; }
    }
}
