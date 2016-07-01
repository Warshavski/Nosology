using System;

namespace Escyug.Nosology.Data.Entities
{
    public sealed class User
    {
        public string Name { get; private set; }

        public int Level { get; private set; }

        public DateTime ExpiredDate { get; private set; }

        public User(string userName, int userLevel, DateTime expiredDate)
        {
            Name = userName;
            Level = userLevel;
            ExpiredDate = expiredDate;
        }  
    }
}
