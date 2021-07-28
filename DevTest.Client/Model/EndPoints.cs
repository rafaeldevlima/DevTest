using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTest.Model
{
    public static class EndPoints
    {
        public static string getUrlAPICalcInterest { get => "http://localhost:58509/Api/calc-interests"; }
        public static string getUrlAPIGitHub { get => "http://localhost:37574/Api/show-me-your-code"; }
        public static string getUrlAPILogin { get => "https://reqres.in/api/login"; }
    }
}
