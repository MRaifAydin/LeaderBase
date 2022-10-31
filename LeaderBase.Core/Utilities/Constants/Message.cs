using LeaderBase.Core.Entities.PostgreSQL.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.Core.Utilities.Constants
{
    public static class Message
    {
        public static string EntityAdded = "Entity added.";
        public static string EntityUpdated = "Entity updated.";
        public static string EntityUpserted = "Entity upserted.";
        public static string EntityDeleted = "Entity deleted.";
        public static string EntityNotFound = "Entity not found.";
        public static string EntityError = "Error with entity.";

        public static string UserNotFound = "User not found";
        public static string PasswordError = "Password error.";
        public static string LoginSuccessful = "Login successful.";
        public static string RegisterSuccessful = "Register successful.";
        public static string AccessTokenGranted = "Access token granted.";

    }

}
