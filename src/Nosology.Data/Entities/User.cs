using System;

namespace Escyug.Nosology.Data.Entities
{
    public sealed class User
    {
        private string _userName;
        public string Name
        {
            get { return _userName; }
        }

        private int _userLevel;
        public  int Level
        {
            get { return _userLevel; }
        }

        private DateTime _expiredDate;
        public DateTime ExpiredDate
        {
            get { return _expiredDate; }
        }

        public User(string userName, int userLevel, DateTime expiredDate)
        {
            _userName = userName;
            _userLevel = userLevel;
            _expiredDate = expiredDate;
        }
    }
}
