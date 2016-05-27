using System;

using Microsoft.AspNet.Identity;

namespace Escyug.Nosology.Models
{
    public sealed class User : IUser
    {
        private string _userName;

        #region IUser members

        public string Id
        {
            get { return _userName; }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        #endregion

        private string _userLevel;
        public string Level
        {
            get { return _userLevel; }
        }

        private DateTime _expiredDate;
        public DateTime ExpiredDate
        {
            get { return _expiredDate; }
        }

        public User(string userName, string userLevel, DateTime expiredDate)
        {
            _userName = userName;
            _userLevel = userLevel;
            _expiredDate = expiredDate;
        }
    }
}
