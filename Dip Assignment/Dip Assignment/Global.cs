using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dip_Assignment
{
    static class Global
    {
        private static string professor = "";
        public static string Professor
        {
            get
            {
                return professor;
            }

            set
            {
                professor = value;
            }
        }

        private static string professorid = "";
        public static string Professorid
        {
            get
            {
                return professorid;
            }

            set
            {
                professorid = value;
            }
        }

        private static string courseid = "";
        public static string Courseid
        {
            get
            {
                return courseid;
            }

            set
            {
                courseid = value;
            }
        }
    }
}
