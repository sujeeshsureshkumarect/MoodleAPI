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
using System.Data;
using Newtonsoft.Json;

namespace MoodleAPI
{
    public partial class Create_Group : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_CreateGroup_Click(object sender, EventArgs e)
        {
            string idimportcourse = "";
            string contentsimport = core_course_get_courses_by_field("idnumber", txt_courseid.Text.Trim());
            JavaScriptSerializer serializer1 = new JavaScriptSerializer();
            if (contentsimport.Contains("exception"))
            {
                // Error
                MoodleException moodleError = serializer1.Deserialize<MoodleException>(contentsimport);
                lbl_results.Text = contentsimport;
            }
            else
            {
                // Good
                //List<MoodleCourses_Get> newCourses1 = serializer.Deserialize<List<MoodleCourses_Get>>(contents1);                   
                //string fullname1 = "";
                //foreach (var value in newCourses1)
                //{
                //    idimportcourse = value.id;
                //    fullname1 = value.fullname;
                //}

                //object yourOjbect = new JavaScriptSerializer().DeserializeObject(contentsimport);
                DataSet importobject = JsonConvert.DeserializeObject<DataSet>(contentsimport);
                idimportcourse = importobject.Tables[0].Rows[0]["id"].ToString();
            }


            string contents = core_group_create_groups(idimportcourse, txt_groupname.Text.Trim(), txt_groupdesc.Text.Trim(), txt_descformat.Text.Trim(), txt_enrolkey.Text.Trim(), txt_idnumber.Text.Trim());
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
                List<MoodleCreateGroupResponse> newGroups = serializer.Deserialize<List<MoodleCreateGroupResponse>>(contents);
                string id = "";
                string name = "";
                foreach (var value in newGroups)
                {
                    id = value.id;
                    name = value.name;
                }
                lbl_results.Text = "Group Created Successfully-" + id + "/" + name + "";
            }
        }
        public string core_group_create_groups(string courseid, string name, string description, string descriptionformat, string enrolmentkey, string idnumber)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            String token = "1b4cb9114197a84985695b19b1164d0a";

            MoodleGroups groups = new MoodleGroups();
            groups.courseid = HttpUtility.UrlEncode(courseid);
            groups.name = HttpUtility.UrlEncode(name);
            groups.description = HttpUtility.UrlEncode(description);
            groups.descriptionformat = HttpUtility.UrlEncode(descriptionformat);
            groups.enrolmentkey = HttpUtility.UrlEncode(enrolmentkey);
            groups.idnumber = HttpUtility.UrlEncode(idnumber);

            List<MoodleGroups> groupsList = new List<MoodleGroups>();
            groupsList.Add(groups);

            Array arrGroups = groupsList.ToArray();

            String postData = String.Format("groups[0][courseid]={0}&groups[0][name]={1}&groups[0][description]={2}&groups[0][descriptionformat]={3}&groups[0][enrolmentkey]={4}&groups[0][idnumber]={5}", groups.courseid, groups.name, groups.description, groups.descriptionformat, groups.enrolmentkey, groups.idnumber);
            string createRequest = string.Format("https://lms.ectmoodle.ae/webservice/rest/server.php?wstoken={0}&wsfunction={1}&moodlewsrestformat=json", token, "core_group_create_groups");
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

        public string core_course_get_courses_by_field(string field, string value)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            String token = "1b4cb9114197a84985695b19b1164d0a";


            course_get_courses courses = new course_get_courses();
            courses.field = HttpUtility.UrlEncode(field);
            courses.value = HttpUtility.UrlEncode(value);

            List<course_get_courses> coursesList = new List<course_get_courses>();
            coursesList.Add(courses);

            Array arrCourses = coursesList.ToArray();

            String postData = String.Format("field={0}&value={1}", courses.field, courses.value);

            string createRequest = string.Format("https://lms.ectmoodle.ae/webservice/rest/server.php?wstoken={0}&wsfunction={1}&moodlewsrestformat=json", token, "core_course_get_courses_by_field");

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

        public class course_get_courses
        {
            public string field { get; set; }
            public string value { get; set; }
        }
        public class MoodleGroups
        {
            public string courseid { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string descriptionformat { get; set; }
            public string enrolmentkey { get; set; }
            public string idnumber { get; set; }
        }

        public class MoodleException
        {
            public string exception { get; set; }
            public string errorcode { get; set; }
            public string message { get; set; }
            public string debuginfo { get; set; }
        }

        public class MoodleCreateGroupResponse
        {
            public string id { get; set; }
            public string courseid { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string descriptionformat { get; set; }
            public string enrolmentkey { get; set; }
            public string idnumber { get; set; }
        }
    }
}