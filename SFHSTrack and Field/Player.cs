using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
namespace SFHSTrackAndField
{
    public class Player
    {
        public static int UserID;
        public static string firstName;
        public static string lastName;
        public static string email;
        public static string password;
        public static DateTime dateCreated;
        public static int authLevel;

        public static void establishUserIdentity(MySqlDataReader reader)
        {
            UserID = reader.GetInt32("UserID");
            firstName = reader.GetString("FirstName");
            lastName = reader.GetString("LastName");
            email = reader.GetString("Email");
            password = reader.GetString("Pass");
            dateCreated = reader.GetDateTime("DateCreated");
            authLevel = reader.GetInt32("AuthenticationLevel"); 
        }
    }
}