using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.User.Human
{
    public class Human1 : UserInfo, IUserInfo
    {
        private static Human1 instance;
        public void SetUserInfo(string userName)
        {
            this.UserName = userName;
        }

        public void SetInitialHealtPoint()
        {
            this.HealtPoint = 3;
        }

        public void SubstractHealthPoint()
        {
            this.HealtPoint = this.HealtPoint - 1;
        }

        public int CountHealthPoint()
        {
            return this.HealtPoint;
        }

        public static Human1 GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new Human1();
                return instance;

            }

        }
    }
}
