using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Shared.Dtos.Query
{
    public class Student_QueryDto
    {
        public string NamePart {  get; set; } = string.Empty;
        public int BirthYear { get; set; } 
        public int BirthMonth { get; set; }
        public bool isGenderFilleringNeeded { get; set; }
        public bool IsWoman { get; set; }

    }
}
