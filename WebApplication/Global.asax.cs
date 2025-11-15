using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;

namespace WebApplication
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // Runs on application startup
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // ===== BARRY - Global.asax Component =====
            Application["TotalVisitors"] = 0;
            Application["ActiveSessions"] = 0;
            Application["ApplicationStartTime"] = DateTime.Now;

            System.Diagnostics.Debug.WriteLine($"Barry's Application Started at: {DateTime.Now}");
            // ===== END BARRY =====
        }
        // ============================================
        // SESSION START - Track new sessions
        // ============================================
        protected void Session_Start(object sender, EventArgs e)
        {
            // BARRY - Track visitor statistics
            Application.Lock();

            // Initialize counters if they don't exist yet
            if (Application["TotalVisitors"] == null)
                Application["TotalVisitors"] = 0;
            if (Application["ActiveSessions"] == null)
                Application["ActiveSessions"] = 0;

            Application["TotalVisitors"] = (int)Application["TotalVisitors"] + 1;
            Application["ActiveSessions"] = (int)Application["ActiveSessions"] + 1;
            Application.UnLock();

            Session["SessionStartTime"] = DateTime.Now;

            System.Diagnostics.Debug.WriteLine($"Barry's New Session. Total Visitors: {Application["TotalVisitors"]}, Active: {Application["ActiveSessions"]}");
        }
        // ============================================
        // SESSION START - Track new sessions
        // ============================================
        protected void Session_End(object sender, EventArgs e)
        {
            // BARRY - Decrement active session counter
            Application.Lock();
            if (Application["ActiveSessions"] != null)
            {
                Application["ActiveSessions"] = (int)Application["ActiveSessions"] - 1;
            }
            Application.UnLock();

            System.Diagnostics.Debug.WriteLine($"Barry's Session Ended. Active Sessions: {Application["ActiveSessions"]}");
        }

        // ============================================
        // APPLICATION ERROR - Global error handling
        // ============================================
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            System.Diagnostics.Debug.WriteLine($"Application Error: {ex.Message}");

            // You could log to file or redirect to error page here
            // Server.Transfer("~/Error.aspx");
        }

        // ============================================
        // APPLICATION END - Cleanup when app shuts down
        // ============================================
        protected void Application_End(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"Application Ended at: {DateTime.Now}");
        }
    }
}