using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace BulanikMantik.Models
{
    public class GenelModel
    {
        public Chart c;
        public List<String> rezidansAnlamDegerleri;

        public GenelModel()
        {
            rezidansAnlamDegerleri = new List<string>();
            c = new Chart(500,500);
        }
        
    }
}