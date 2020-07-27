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
using Microsoft.SqlServer.Server;

namespace MoodleAPI
{
    public partial class Create_Courses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                
            }
        }

        public class MoodleCourses
        {
            public string fullname { get; set; }
            public string shortname { get; set; }
            public string categoryid { get; set; }
            public string idnumber { get; set; }
            public string summary { get; set; }
            public string summaryformat { get; set; }
            public string format { get; set; }
            public string showgrades { get; set; }
            public string newsitems { get; set; }

            public string startdate { get; set; }
            public string enddate { get; set; }
            public string numsections { get; set; }
            public string maxbytes { get; set; }


            public string showreports { get; set; }
            public string visible { get; set; }
            public string groupmode { get; set; }
            public string groupmodeforce { get; set; }
            public string defaultgroupingid { get; set; }

            public string enablecompletion { get; set; }
            public string completionnotify { get; set; }
            public string lang { get; set; }

        }

        public class MoodleException
        {
            public string exception { get; set; }
            public string errorcode { get; set; }
            public string message { get; set; }
            public string debuginfo { get; set; }
        }

        public class MoodleCreateCourseResponse
        {
            public string id { get; set; }
            public string shortname { get; set; }
        }
        public static long ToUnixTimestamp(DateTime target)
        {
            var date = new DateTime(1970, 1, 1, 0, 0, 0, target.Kind);
            var unixTimestamp = System.Convert.ToInt64((target - date).TotalSeconds);

            return unixTimestamp;
        }
        public string core_course_create_courses(string fullname,string shortname,string categoryid,string idnumbber,string summary,string summaryformat,string format,string showgrades,string newsitems,string startdate,string enddate,string numsections,string maxbytes,string showreports,string visible,string groupmode,string groupmodeforce,string defaultgroupingid,string enablecompletion,string completionnotify,string lang)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            String token = "1b4cb9114197a84985695b19b1164d0a";

            long start = ToUnixTimestamp(Convert.ToDateTime(txt_StatrtDate.Text));
            long end = ToUnixTimestamp(Convert.ToDateTime(txt_EndDate.Text));

            MoodleCourses courses = new MoodleCourses();
            courses.fullname = HttpUtility.UrlEncode(fullname);
            courses.shortname = HttpUtility.UrlEncode(shortname);
            courses.categoryid = HttpUtility.UrlEncode(categoryid);
            courses.idnumber = HttpUtility.UrlEncode(idnumbber);
            courses.summary = HttpUtility.UrlEncode(summary);
            courses.summaryformat = HttpUtility.UrlEncode(summaryformat);
            courses.format = HttpUtility.UrlEncode(format);
            courses.showgrades = HttpUtility.UrlEncode(showgrades);
            courses.newsitems = HttpUtility.UrlEncode(newsitems);

            courses.startdate = HttpUtility.UrlEncode(start.ToString());
            courses.enddate = HttpUtility.UrlEncode(end.ToString());
            courses.numsections = HttpUtility.UrlEncode(numsections);
            courses.maxbytes = HttpUtility.UrlEncode(maxbytes);

            courses.showreports = HttpUtility.UrlEncode(showreports);
            courses.visible = HttpUtility.UrlEncode(visible);
            courses.groupmode = HttpUtility.UrlEncode(groupmode);
            courses.groupmodeforce = HttpUtility.UrlEncode(groupmodeforce);
            courses.defaultgroupingid = HttpUtility.UrlEncode(defaultgroupingid);

            courses.enablecompletion = HttpUtility.UrlEncode(enablecompletion);
            courses.completionnotify = HttpUtility.UrlEncode(completionnotify);
            courses.lang = HttpUtility.UrlEncode(lang);

            List<MoodleCourses> coursesList = new List<MoodleCourses>();
            coursesList.Add(courses);

            Array arrCourses = coursesList.ToArray();

            String postData = String.Format("courses[0][fullname]={0}&courses[0][shortname]={1}&courses[0][categoryid]={2}&courses[0][idnumber]={3}&courses[0][summary]={4}&courses[0][summaryformat]={5}&courses[0][format]={6}&courses[0][showgrades]={7}&courses[0][newsitems]={8}&courses[0][startdate]={9}&courses[0][enddate]={10}&courses[0][numsections]={11}&courses[0][maxbytes]={12}&courses[0][showreports]={13}&courses[0][visible]={14}&courses[0][groupmode]={15}&courses[0][groupmodeforce]={16}&courses[0][defaultgroupingid]={17}&courses[0][enablecompletion]={18}&courses[0][completionnotify]={19}&courses[0][lang]={20}", courses.fullname, courses.shortname, courses.categoryid, courses.idnumber, courses.summary, courses.summaryformat, courses.format, courses.showgrades, courses.newsitems,courses.startdate,courses.enddate,courses.numsections,courses.maxbytes, courses.showreports, courses.visible, courses.groupmode, courses.groupmodeforce, courses.defaultgroupingid,courses.enablecompletion,courses.completionnotify,courses.lang);



            string createRequest = string.Format("https://lms.ectmoodle.ae/webservice/rest/server.php?wstoken={0}&wsfunction={1}&moodlewsrestformat=json", token, "core_course_create_courses");

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
        protected void btn_CreateCourse_Click(object sender, EventArgs e)
        {

            string contents = core_course_create_courses(txt_fullname.Text.Trim(), txt_shortname.Text.Trim(), txt_categoryid.Text.Trim(), txt_Idnumber.Text.Trim(), txt_Summary.Text.Trim(), txt_summaryformat.Text.Trim(), txt_format.Text.Trim(), txt_showgrades.Text.Trim(), txt_NewsItems.Text.Trim(), txt_StatrtDate.Text.Trim(), txt_EndDate.Text.Trim(), txt_numsections.Text.Trim(), txt_maxbytes.Text.Trim(), txt_ShowReports.Text.Trim(), txt_visible.Text.Trim(), txt_groupmode.Text.Trim(), txt_groupmodeforce.Text.Trim(), txt_defaultgroupingid.Text.Trim(), txt_enablecompletion.Text.Trim(), txt_completionnotify.Text.Trim(), txt_lang.Text.Trim());
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
                List<MoodleCreateCourseResponse> newCourses = serializer.Deserialize<List<MoodleCreateCourseResponse>>(contents);
                string id = "";
                string shortname = "";
                foreach (var value in newCourses)
                {
                    id= value.id;
                    shortname = value.shortname;                    
                }
                lbl_results.Text = "Course Created Successfuly-"+id+"/"+shortname+"";
            }
        }
    }
}