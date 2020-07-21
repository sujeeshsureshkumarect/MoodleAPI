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
    public partial class Add_Group_Members : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_AddMember_Click(object sender, EventArgs e)
        {
            string contents = core_group_add_group_members(txt_groupid.Text.Trim(), txt_userid.Text.Trim());
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
                lbl_results.Text = "Member Added Successfuly";
            }
        }
        public string core_group_add_group_members(string groupid, string userid)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            String token = "1b4cb9114197a84985695b19b1164d0a";

            MoodleGroupsAddMember groups = new MoodleGroupsAddMember();
            groups.groupid = HttpUtility.UrlEncode(groupid);
            groups.userid = HttpUtility.UrlEncode(userid);           

            List<MoodleGroupsAddMember> groupsList = new List<MoodleGroupsAddMember>();
            groupsList.Add(groups);

            Array arrGroups = groupsList.ToArray();

            String postData = String.Format("members[0][groupid]={0}&members[0][userid]={1}", groups.groupid, groups.userid);
            string createRequest = string.Format("https://lms.ectmoodle.ae/webservice/rest/server.php?wstoken={0}&wsfunction={1}&moodlewsrestformat=json", token, "core_group_add_group_members");
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
        public class MoodleGroupsAddMember
        {
            public string groupid { get; set; }
            public string userid { get; set; }
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