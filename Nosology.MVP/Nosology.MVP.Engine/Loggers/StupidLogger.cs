using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using Escyug.Nosology.MVP.DataAccessLayer.Common;
using Escyug.Nosology.MVP.Engine.Repositories;

namespace Escyug.Nosology.MVP.Engine
{
    public sealed class StupidLogger
    {
        private const int LOGIN_SIZE_THRESHOLD = 20;
        private const int PWD_SIZE_THRESHOLD = 5;

        private readonly string[] _levels = new string[] 
        {
            "Администратор",
            "Орган управления здравоохранением субъекта Российской федерации",
            "Орган управления здравоохранением муниципального образования субъекта Российской федерации",
            "Лечебно-профилактическое учреждение",
            "Аптечное учреждение"
        };

        public StupidLogger()
        {

        }

        public User Logon(string mcod, string inputPwd)
        {
            User user = null;

            if (mcod.Length > LOGIN_SIZE_THRESHOLD || inputPwd.Length > PWD_SIZE_THRESHOLD)
            {
                return null;
            }
            else
            {
                UserRepository userRepo = new UserRepository();

                var userInfo = userRepo.SelectUserData(mcod);

                if (userInfo != null)
                {
                    DateTime currentDate = DateTime.Today;

                    string refPwd = userInfo["pwd"].Trim();
                    DateTime refDate = DateTime.Parse(userInfo["date"]);

                    if (inputPwd.ToLower() == refPwd.ToLower() && currentDate <= refDate)
                    {
                        string userName = userInfo["name"].Trim();
                        string userLevel = _levels[int.Parse(userInfo["level"])];
                        
                        userInfo.Clear();

                        user = new User(userName, userLevel);
                    }
                }
            }

            return user;
        }
    }
}
