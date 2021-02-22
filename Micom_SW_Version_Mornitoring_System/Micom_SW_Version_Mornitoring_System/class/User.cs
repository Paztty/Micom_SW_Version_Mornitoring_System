using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Micom_SW_Version_Mornitoring_System
{
    static class Global
    {
        public static User user = new User();
    }
    public class User
    {
        public enum Permission
        {
            [EnumMember(Value = "0")]
            Watch = 0,
            [EnumMember(Value = "1")]
            Add = 1,
            [EnumMember(Value = "2")]
            Edit = 2,
            [EnumMember(Value = "3")]
            Clear = 3,
            [EnumMember(Value = "4")]
            Export = 4,
        }
        public string userID = "0000000";
        public string userName = "Guest";
        public string userPermission = "Watch";
    }
}
