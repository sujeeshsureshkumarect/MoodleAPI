using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
namespace MoodleAPI
{
    public partial class Manual_Enrol_Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Enroll_Click(object sender, EventArgs e)
        {
            string contents = enrol_manual_enrol_users(txt_roleid.Text.Trim(), txt_userid.Text.Trim(), txt_Courseid.Text.Trim(), txt_Suspend.Text.Trim());
            // Deserialize
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            if (contents.Contains("exception"))
            {
                // Error
                MoodleException moodleError = serializer.Deserialize<MoodleException>(contents);
                lbl_results.Text = contents;
            }
            else
            {
                // Good
                List<string> newGroups = serializer.Deserialize<List<string>>(contents);
                lbl_results.Text = "User Enrolled Successfuly";
            }
        }
        public string enrol_manual_enrol_users(string roleid, string userid, string courseid, string suspend)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            String token = "1b4cb9114197a84985695b19b1164d0a";

            MoodleManualEnrol enrol = new MoodleManualEnrol();
            enrol.roleid = HttpUtility.UrlEncode(roleid);
            enrol.userid = HttpUtility.UrlEncode(userid);
            enrol.courseid = HttpUtility.UrlEncode(courseid);
            enrol.suspend = HttpUtility.UrlEncode(suspend);

            List<MoodleManualEnrol> groupsList = new List<MoodleManualEnrol>();
            groupsList.Add(enrol);

            Array arrGroups = groupsList.ToArray();

            String postData = String.Format("enrolments[0][roleid]={0}&enrolments[0][userid]={1}&enrolments[0][courseid]={2}&enrolments[0][suspend]={3}", enrol.roleid, enrol.userid, enrol.courseid, enrol.suspend);
            string createRequest = string.Format("https://lms.ectmoodle.ae/webservice/rest/server.php?wstoken={0}&wsfunction={1}&moodlewsrestformat=json", token, "enrol_manual_enrol_users");
            // Call Moodle REST Service
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(createRequest);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";

            // Encode the parameters as form data:
            byte[] formData =
                UTF8Encoding.UTF8.GetBytes(postData);
            req.ContentLength = formData.Length;

            // Write out the form Data to the request:
            using (Stream post = req.GetRequestStream())
            {
                post.Write(formData, 0, formData.Length);
            }

            // Get the Response
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream resStream = resp.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            string contents = reader.ReadToEnd();
            return contents;
        }
        public class MoodleManualEnrol
        {
            public string roleid { get; set; }
            public string userid { get; set; }
            public string courseid { get; set; }
            public string suspend { get; set; }
        }
        public class MoodleException
        {
            public string exception { get; set; }
            public string errorcode { get; set; }
            public string message { get; set; }
            public string debuginfo { get; set; }
        }
    }
}