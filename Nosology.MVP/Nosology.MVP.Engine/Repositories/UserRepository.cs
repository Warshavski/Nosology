using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
//using Escyug.Nosology.MVP.DataAccessLayer.Xml;
using Escyug.Nosology.MVP.DataAccessLayer.Sql;
using System.Data;

namespace Escyug.Nosology.MVP.Engine.Repositories
{
    internal sealed class UserRepository
    {
        public UserRepository()
        {

        }

        //public Dictionary<string, string> SelectUserData(string login)
        //{
        //    Dictionary<string, string> usrDataList = null;

        //    var usrService = new UserService();
        //    var usrData = usrService.GetUserData(login);

        //    if (usrData != null && usrData.Rows.Count != 0)
        //    {
        //        usrDataList = new Dictionary<string, string>();

        //        usrDataList.Add("pwd", usrData.Rows[0]["PAROL"].ToString());
        //        usrDataList.Add("date", usrData.Rows[0]["DATE_E"].ToString());
        //        usrDataList.Add("name", usrData.Rows[0]["NIC"].ToString());
        //        usrDataList.Add("level", usrData.Rows[0]["KAT"].ToString());

        //        usrData.Dispose();
        //    }

        //    return usrDataList;
        //}


        public Dictionary<string, string> SelectUserData(string login)
        {
            Dictionary<string, string> usrDataList = null;

            var usrService = new UserService();
            var usrData = usrService.GetUserData(login);

            if (usrData != null && usrData.Rows.Count != 0)
            {
                usrDataList = new Dictionary<string, string>();

                usrDataList.Add("pwd", usrData.Rows[0]["PAROL"].ToString());
                usrDataList.Add("date", usrData.Rows[0]["DATE_E"].ToString());
                usrDataList.Add("name", usrData.Rows[0]["NIC"].ToString());
                usrDataList.Add("level", usrData.Rows[0]["KAT"].ToString());

                usrData.Dispose();
            }

            return usrDataList;
        }
    }
}
