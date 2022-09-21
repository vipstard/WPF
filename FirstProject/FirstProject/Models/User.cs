using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Models
{
     class User
    {
        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private String userImg;

        public String UserImg
        {
            get { return userImg; }
            set { userImg = value; }
        }

        private int userAge;

        public int UserAge
        {
            get { return userAge; }
            set { userAge = value; }
        }



    }
}
