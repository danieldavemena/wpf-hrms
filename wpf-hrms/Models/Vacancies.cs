using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_hrms.Models
{
    public class Vacancies
    {
        public string RoleName { get; set; }
        public int Vacant { get; set; }
        public int Filled {  get; set; }    

        public Vacancies() { }
    }
}
