using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Student
{
    class Student
    {
       public string Name { get; set; }

        public string Region { get; set; }
        public string Class { get; set; }

        public string Section{ get; set; }

        public Student(string name, string reg, string @class, string section)
        {
            Name = name;
            Region = reg;
            Class = @class;
            Section = section;
        }
    }
}
