using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleServer
{
    class Student
    {
        string name, surname, group;

        public Student(string name, string surname, string group)
        {
            this.name = name;
            this.surname = surname;
            this.group = group;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Group { get; set; }
    }
}
