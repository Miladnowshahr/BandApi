using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandApi.Helper
{
    public static class FoundYearsAgo
    {
        public static int GetYearAgo(this DateTime dateTime)
        {
            var currentDateTime = DateTime.Now; 
            var calc = dateTime.Year - currentDateTime.Year;
            return calc;
        }
    }
}
