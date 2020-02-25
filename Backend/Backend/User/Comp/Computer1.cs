using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.User.Comp
{
    public  class Computer1 : UserInfo, IUserInfo
    {
        private static Computer1 instance;
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
        public static Computer1 GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new Computer1();
                return instance;

            }

        }
    }
}
