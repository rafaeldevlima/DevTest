using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTest.Shared.DTOs
{
    public class InterestCalcResultDTO
    {
        public bool Success { get;set;} 
        public decimal FinalValue { get; set; }

        public List<string> Messages { get; set; }
    }
}
