using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.Configuration;
using System.Web;
//using System.Web.Configuration;

namespace SatOrbit
{
    /// <summary>
    /// 该类摘自Space-Track网站
    /// 网址https://www.space-track.org/documentation#api_csharp
    /// </summary>
    class SpaceTrack
    {
        public class WebClientEx : WebClient
        {
            // Create the container to hold all Cookie objects
            private CookieContainer _cookieContainer = new CookieContainer();

            // Override the WebRequest method so we can store the cookie 
            // container as an attribute of the Web Request object
            protected override WebRequest GetWebRequest(Uri address)
            {
                WebRequest request = base.GetWebRequest(address);

                if (request is HttpWebRequest)
                    (request as HttpWebRequest).CookieContainer = _cookieContainer;

                return request;
            }
        }   // END WebClient Class
        // Get the TLEs based of an array of NORAD CAT IDs, start date, and end date
        public string GetSpaceTrack(string myName, string myCode)
        {
            string uriBase = "https://www.space-track.org";
            string requestController = "/basicspacedata";
            string requestAction = "/query";
            // URL to retrieve all the latest tle's for the provided NORAD CAT 
            // IDs for the provided Dates
            string predicateValues = "/class/tle_latest/ORDINAL/1/orderby/NORAD_CAT_ID%20ASC/format/tle";
            // URL to retrieve all the latest 3le's for the provided NORAD CAT 
            // IDs for the provided Dates
            //string predicateValues   = "/class/tle/EPOCH/" + dtstart.ToString("yyyy-MM-dd--") + dtend.ToString("yyyy-MM-dd")+"/NORAD_CAT_ID/" +string.Join(",", norad) + "/orderby/NORAD_CAT_ID%20ASC/format/3le";
            string request = uriBase + requestController + requestAction + predicateValues;

            // Create new WebClient object to communicate with the service
            using (var client = new WebClientEx())
            {
                // Store the user authentication information
                var data = new NameValueCollection
                {
                    { "identity", myName },
                    { "password", myCode },
                };

                // Generate the URL for the API Query and return the response
                var response2 = client.UploadValues(uriBase + "/auth/login", data);
                var response4 = client.DownloadData(request);

                return (System.Text.Encoding.Default.GetString(response4));
            }
            //HttpClient client = new HttpClient();
            //var data = new NameValueCollection
            //    {
            //        { "identity", myName },
            //        { "password", myCode },
            //    };
            //var response2 = client.PostData(uriBase + "/auth/login", data);
            //var response4 = client.GetData(request);
            //return response4;

        }   // END GetSpaceTrack()
        // Get the TLEs based of an array of NORAD CAT IDs, start date, and end date
        public string GetSpaceTrack(string[] norad, string myName, string myCode)
        {
            string uriBase = "https://www.space-track.org";
            string requestController = "/basicspacedata";
            string requestAction = "/query";
            // URL to retrieve all the latest tle's for the provided NORAD CAT 
            // IDs for the provided Dates
            string predicateValues = "/class/tle_latest/ORDINAL/1/NORAD_CAT_ID/" + string.Join(",", norad) + "/orderby/NORAD_CAT_ID%20ASC/format/tle";
            // URL to retrieve all the latest 3le's for the provided NORAD CAT 
            // IDs for the provided Dates
            //string predicateValues   = "/class/tle/EPOCH/" + dtstart.ToString("yyyy-MM-dd--") + dtend.ToString("yyyy-MM-dd")+"/NORAD_CAT_ID/" +string.Join(",", norad) + "/orderby/NORAD_CAT_ID%20ASC/format/3le";
            string request = uriBase + requestController + requestAction + predicateValues;

            // Create new WebClient object to communicate with the service
            using (var client = new WebClientEx())
            {
                // Store the user authentication information
                var data = new NameValueCollection
                {
                    { "identity", myName },
                    { "password", myCode },
                };

                // Generate the URL for the API Query and return the response
                var response2 = client.UploadValues(uriBase + "/auth/login", data);
                var response4 = client.DownloadData(request);

                return (System.Text.Encoding.Default.GetString(response4));
            }
            //HttpClient client = new HttpClient();
            //var data = new NameValueCollection
            //    {
            //        { "identity", myName },
            //        { "password", myCode },
            //    };
            //var response2 = client.PostData(uriBase + "/auth/login", data);
            //var response4 = client.GetData(request);
            //return response4;

        }   // END GetSpaceTrack()

        public string GetSpaceTrack(string[] norad, DateTime dtstart, DateTime dtend, string myName, string myCode)
        {
            string uriBase = "https://www.space-track.org";
            string requestController = "/basicspacedata";
            string requestAction = "/query";
            // URL to retrieve all the latest tle's for the provided NORAD CAT 
            // IDs for the provided Dates
            //string predicateValues = "/class/tle_latest/ORDINAL/1/NORAD_CAT_ID/" + string.Join(",", norad) + "/orderby/NORAD_CAT_ID%20ASC/format/tle";
            // URL to retrieve all the latest 3le's for the provided NORAD CAT 
            // IDs for the provided Dates
            string predicateValues = "/class/tle/EPOCH/" + dtstart.ToString("yyyy-MM-dd--") + dtend.ToString("yyyy-MM-dd") + "/NORAD_CAT_ID/" + string.Join(",", norad) + "/orderby/NORAD_CAT_ID%20ASC/format/tle";
            string request = uriBase + requestController + requestAction + predicateValues;

            // Create new WebClient object to communicate with the service
            using (var client = new WebClientEx())
            {
                // Store the user authentication information
                var data = new NameValueCollection
                {
                    { "identity", myName },
                    { "password", myCode },
                };

                // Generate the URL for the API Query and return the response
                var response2 = client.UploadValues(uriBase + "/auth/login", data);
                var response4 = client.DownloadData(request);

                return (System.Text.Encoding.Default.GetString(response4));
            }
        }   // END GetSpaceTrack()

    }
}
