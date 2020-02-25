using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.User
{
    public interface IUserInfo
    {
        void SetUserInfo(string userName);
        void SetInitialHealtPoint();
        void SubstractHealthPoint();
        int CountHealthPoint();
    }
    public  class UserInfo
    {
        public int HealtPoint { get; set; }
        public string UserName { get; set; }
    }
}
