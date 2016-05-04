using System;

namespace Escyug.Nosology.Models
{
    public sealed class User
    {
        private string _userName;
        public string Name
        {
            get { return _userName; }
        }

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

        //private IEnumerable<Document> _userDocuments;

        public User(string userName, string userLevel, DateTime expiredDate)
        {
            _userName = userName;
            _userLevel = userLevel;
            _expiredDate = expiredDate;
        }
    }
}
