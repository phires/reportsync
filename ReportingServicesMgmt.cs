using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ReportSync.Properties;
using ReportSync.ReportService;

namespace ReportSync
{
    public class ReportingServicesMgmt
    {
        private const string ServicesUrl = @"/ReportService2005.asmx";
        public ReportingService2005 ReportingService { get; private set; }
        public Dictionary<string, string> DataSources { get; set; }
        public ReportingServicesMgmt(string url, string username, string password, bool integratedAuth)
        {
            var reportServerUrl = url.TrimEnd('/') + ServicesUrl;
            DataSources = new Dictionary<string, string>();

            ReportingService = new ReportingService2005 {Url = reportServerUrl};
            if (!integratedAuth) // uses the checkbox, these weren't actively being used befare
            {
                var nameParts = username.Split('\\', '/');
                if (nameParts.Length > 2)
                {
                    throw new Exception(Resources.Incorrect_destination_user_name);
                }
                try { ReportingService.Credentials = nameParts.Length == 2
                    ? new System.Net.NetworkCredential(nameParts[1], password, nameParts[0]) // Auth with a domain
                    : new System.Net.NetworkCredential(username, password); // Username/Password Only Auth
                }
                catch(Exception ex){
                    MessageBox.Show("Could not connect to server: " + ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else // Use the system credentials
            {
                try
                {
                    ReportingService.Credentials = System.Net.CredentialCache.DefaultCredentials;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Could not use integrated auth:" + ex.Message, Resources.Error, MessageBoxButtons.OK);
                    return;
                }
            }
        }
    }
}
