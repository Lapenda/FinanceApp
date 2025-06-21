using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp.Managers
{
    public static class SessionManager
    {
        public static int currentUserId {  get; private set; }
        public static string currentUsername { get; private set; }
        public static string currentUserRole { get; private set; }
        public static bool isLoggedIn { get; private set; }

        public static void StartSession(ClaimsPrincipal claimsPrincipal)
        {
            currentUserId = int.Parse(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value);
            currentUsername = claimsPrincipal.FindFirst(ClaimTypes.Name).Value;
            currentUserRole = claimsPrincipal.FindFirst(ClaimTypes.Role).Value;
            isLoggedIn = true;
        }

        public static void EndSession()
        {
            currentUserId = -1;
            currentUsername = null;
            currentUserRole = null;
            isLoggedIn = false;
            Properties.Settings.Default.JwtToken = null;
            Properties.Settings.Default.Save();
        }
    }
}
