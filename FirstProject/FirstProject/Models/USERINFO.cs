using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Models
{
     class USERINFO
    {
        private string username;
        private string userImg;
        private int userAge;

        
        public string USERNAME
        {
            get { return username; }
            set { username = value; }
        }
        public string USERIMG
        {
            get { return userImg; }
            set { userImg = value; }
        }

        public int USERAGE
        {
            get { return userAge; }
            set { userAge = value; }
        }


    }
}
