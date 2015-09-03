using System;
using System.Collections.Generic;
using System.Linq;
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
            if (!integratedAuth)
            {
                var nameParts = username.Split('\\', '/');
                if (nameParts.Length > 2)
                {
                    throw new Exception(Resources.Incorrect_destination_user_name);
                }
                ReportingService.Credentials = nameParts.Length == 2
                    ? new System.Net.NetworkCredential(nameParts[1], password, nameParts[0])
                    : new System.Net.NetworkCredential(username, password);
            }
            else
            {
                ReportingService.Credentials = System.Net.CredentialCache.DefaultCredentials;
            }
        }
    }
}
