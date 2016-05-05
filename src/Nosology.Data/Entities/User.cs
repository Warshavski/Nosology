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
        public int Level 
        { 
            get { return _userLevel; } 
        }

        private DateTime _userExpiredDate;
        public DateTime ExpiredDate
        {
            get { return _userExpiredDate; }
        }

        //IEnumerable<Document> _userDocuments;

        public User(string userName, int userLevel, DateTime userExpiredDate)
        {
            _userName = userName;
            _userLevel = userLevel;
            _userExpiredDate = userExpiredDate;
        }
    }
}
