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
    public partial class Create_ImportCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_CreateCourse_Click(object sender, EventArgs e)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            String token = "1b4cb9114197a84985695b19b1164d0a";

            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            //Start Create New Course
            MoodleCourses courses = new MoodleCourses();
            courses.fullname = HttpUtility.UrlEncode(txt_fullname.Text.Trim());
            courses.shortname = HttpUtility.UrlEncode(txt_shortname.Text.Trim());
            courses.categoryid = HttpUtility.UrlEncode(txt_categoryid.Text.Trim());
            courses.idnumber = HttpUtility.UrlEncode(txt_Idnumber.Text.Trim());
            courses.summary = HttpUtility.UrlEncode(txt_Summary.Text.Trim());
            courses.summaryformat = HttpUtility.UrlEncode(txt_summaryformat.Text.Trim());
            courses.format = HttpUtility.UrlEncode(txt_format.Text.Trim());
            courses.showgrades = HttpUtility.UrlEncode(txt_showgrades.Text.Trim());
            courses.newsitems = HttpUtility.UrlEncode(txt_NewsItems.Text.Trim());
            courses.showreports = HttpUtility.UrlEncode(txt_ShowReports.Text.Trim());
            courses.visible = HttpUtility.UrlEncode(txt_visible.Text.Trim());
            courses.groupmode = HttpUtility.UrlEncode(txt_groupmode.Text.Trim());
            courses.groupmodeforce = HttpUtility.UrlEncode(txt_groupmodeforce.Text.Trim());
            courses.defaultgroupingid = HttpUtility.UrlEncode(txt_defaultgroupingid.Text.Trim());

            List<MoodleCourses> coursesList = new List<MoodleCourses>();
            coursesList.Add(courses);

            Array arrCourses = coursesList.ToArray();

            String postData = String.Format("courses[0][fullname]={0}&courses[0][shortname]={1}&courses[0][categoryid]={2}&courses[0][idnumber]={3}&courses[0][summary]={4}&courses[0][summaryformat]={5}&courses[0][format]={6}&courses[0][showgrades]={7}&courses[0][newsitems]={8}&courses[0][showreports]={9}&courses[0][visible]={10}&courses[0][groupmode]={11}&courses[0][groupmodeforce]={12}&courses[0][defaultgroupingid]={13}", courses.fullname, courses.shortname, courses.categoryid, courses.idnumber, courses.summary, courses.summaryformat, courses.format, courses.showgrades, courses.newsitems, courses.showreports, courses.visible, courses.groupmode, courses.groupmodeforce, courses.defaultgroupingid);

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
                    id = value.id;
                    shortname = value.shortname;
                }
                //End Create New Course

                //Start Import Previous Course Contents to the Created Course Now
                MoodleImportCourse import = new MoodleImportCourse();
                import.importfrom = HttpUtility.UrlEncode(txt_ImportCourseID.Text.Trim());
                import.importto = HttpUtility.UrlEncode(id);
                import.deletecontent = HttpUtility.UrlEncode("0");
                import.name = HttpUtility.UrlEncode("activities");
                import.value = HttpUtility.UrlEncode("1");
                import.name1 = HttpUtility.UrlEncode("blocks");
                import.value1 = HttpUtility.UrlEncode("1");
                import.name2 = HttpUtility.UrlEncode("filters");
                import.value2 = HttpUtility.UrlEncode("1");

                List<MoodleImportCourse> importList = new List<MoodleImportCourse>();
                importList.Add(import);

                Array arrImport = importList.ToArray();
                String postImportData = String.Format("importfrom={0}&importto={1}&deletecontent={2}&options[0][name]={3}&options[0][value]={4}&options[0][name]={5}&options[0][value]={6}&options[0][name]={7}&options[0][value]={8}", import.importfrom, import.importto, import.deletecontent, import.name, import.value, import.name1, import.value1, import.name2, import.value2);
                string createRequestImport = string.Format("https://lms.ectmoodle.ae/webservice/rest/server.php?wstoken={0}&wsfunction={1}&moodlewsrestformat=json", token, "core_course_import_course");
                // Call Moodle REST Service
                HttpWebRequest reqImport = (HttpWebRequest)WebRequest.Create(createRequestImport);
                reqImport.Method = "POST";
                reqImport.ContentType = "application/x-www-form-urlencoded";
                // Encode the parameters as form data:
                byte[] formDataImport =
                    UTF8Encoding.UTF8.GetBytes(postImportData);
                reqImport.ContentLength = formDataImport.Length;

                // Write out the form Data to the request:
                using (Stream postImport = reqImport.GetRequestStream())
                {
                    postImport.Write(formDataImport, 0, formDataImport.Length);
                }
                // Get the Response
                HttpWebResponse respImport = (HttpWebResponse)reqImport.GetResponse();
                Stream resStreamImport = respImport.GetResponseStream();
                StreamReader readerImport = new StreamReader(resStreamImport);
                string contentsImport = readerImport.ReadToEnd();
                // Deserialize
                JavaScriptSerializer serializerImport = new JavaScriptSerializer();
                if (contentsImport.Contains("exception"))
                {
                    // Error
                    MoodleException moodleError = serializerImport.Deserialize<MoodleException>(contentsImport);
                    lbl_results.Text = contents;
                }
                else
                {
                    // Good
                    //End Import Previous Course Contents to the Created Course Now
                    List<string> newImport = serializerImport.Deserialize<List<string>>(contentsImport);

                    //Start Check if any groups were present in the imported course or not; if yes delete all existing groups
                    MoodleGetCourseGroup GetCourse = new MoodleGetCourseGroup();
                    GetCourse.courseid = HttpUtility.UrlEncode(id);
                    List<MoodleGetCourseGroup> CourseGroupList = new List<MoodleGetCourseGroup>();
                    CourseGroupList.Add(GetCourse);
                    Array arrCourseGroup = CourseGroupList.ToArray();
                    String postCourseGroup = String.Format("courseid={0}", GetCourse.courseid);
                    string createRequestCourseGroup = string.Format("https://lms.ectmoodle.ae/webservice/rest/server.php?wstoken={0}&wsfunction={1}&moodlewsrestformat=json", token, "core_group_get_course_groups");
                    // Call Moodle REST Service
                    HttpWebRequest reqCourseGroup = (HttpWebRequest)WebRequest.Create(createRequestCourseGroup);
                    reqCourseGroup.Method = "POST";
                    reqCourseGroup.ContentType = "application/x-www-form-urlencoded";
                    // Encode the parameters as form data:
                    byte[] formCourseGroup =
                        UTF8Encoding.UTF8.GetBytes(postCourseGroup);
                    reqCourseGroup.ContentLength = formCourseGroup.Length;
                    // Write out the form Data to the request:
                    using (Stream postImportCourseGroup = reqCourseGroup.GetRequestStream())
                    {
                        postImportCourseGroup.Write(formCourseGroup, 0, formCourseGroup.Length);
                    }
                    // Get the Response
                    HttpWebResponse respImportCourseGroup = (HttpWebResponse)reqCourseGroup.GetResponse();
                    Stream resStreamImportCourseGroup = respImportCourseGroup.GetResponseStream();
                    StreamReader readerImportCourseGroup = new StreamReader(resStreamImportCourseGroup);
                    string contentsImportCourseGroup = readerImportCourseGroup.ReadToEnd();
                    JavaScriptSerializer serializerImportCourseGroup = new JavaScriptSerializer();
                    if (contentsImportCourseGroup.Contains("exception"))
                    {
                        // Error
                        MoodleException moodleError = serializerImportCourseGroup.Deserialize<MoodleException>(contentsImportCourseGroup);
                        lbl_results.Text = contents;
                    }
                    else
                    {
                        // Good
                        List<MoodleGetCourseGroupResponse> newCourseGroup = serializer.Deserialize<List<MoodleGetCourseGroupResponse>>(contentsImportCourseGroup);
                        string groupid = "";
                        foreach (var value in newCourseGroup)
                        {
                            groupid = value.id;
                            //Start Delete Groups
                            MoodleDeleteGroup DeleteGroup = new MoodleDeleteGroup();
                            DeleteGroup.groupids = HttpUtility.UrlEncode(groupid);
                            List<MoodleDeleteGroup> DeleteGroupList = new List<MoodleDeleteGroup>();
                            DeleteGroupList.Add(DeleteGroup);
                            Array arrDeleteGroup = DeleteGroupList.ToArray();
                            String postDeleteGroup = String.Format("groupids[0]={0}", DeleteGroup.groupids);
                            string createRequestDeleteGroup = string.Format("https://lms.ectmoodle.ae/webservice/rest/server.php?wstoken={0}&wsfunction={1}&moodlewsrestformat=json", token, "core_group_delete_groups");
                            // Call Moodle REST Service
                            HttpWebRequest reqDeleteGroup = (HttpWebRequest)WebRequest.Create(createRequestDeleteGroup);
                            reqDeleteGroup.Method = "POST";
                            reqDeleteGroup.ContentType = "application/x-www-form-urlencoded";
                            // Encode the parameters as form data:
                            byte[] formDeleteGroup =
                                UTF8Encoding.UTF8.GetBytes(postDeleteGroup);
                            reqDeleteGroup.ContentLength = formDeleteGroup.Length;
                            // Write out the form Data to the request:
                            using (Stream postImportDeleteGroup = reqDeleteGroup.GetRequestStream())
                            {
                                postImportDeleteGroup.Write(formDeleteGroup, 0, formDeleteGroup.Length);
                            }
                            // Get the Response
                            HttpWebResponse respImportDeleteGroup = (HttpWebResponse)reqDeleteGroup.GetResponse();
                            Stream resStreamImportDeleteGroup = respImportDeleteGroup.GetResponseStream();
                            StreamReader readerImportDeleteGroup = new StreamReader(resStreamImportDeleteGroup);
                            string contentsImportDeleteGroup = readerImportDeleteGroup.ReadToEnd();
                            JavaScriptSerializer serializerImportDeleteGroup = new JavaScriptSerializer();
                            if (contentsImportDeleteGroup.Contains("exception"))
                            {
                                // Error
                                MoodleException moodleError = serializerImportDeleteGroup.Deserialize<MoodleException>(contentsImportDeleteGroup);
                                lbl_results.Text = contents;
                            }
                            else
                            {
                                // Good
                                lbl_results.Text = "Course Created & Imported Successfuly-" + id + "/" + shortname + "";
                            }
                            //End Delete Groups
                        }
                    }
                }
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
            public string showreports { get; set; }
            public string visible { get; set; }
            public string groupmode { get; set; }
            public string groupmodeforce { get; set; }
            public string defaultgroupingid { get; set; }
        }

        public class MoodleException
        {
            public string exception { get; set; }
            public string errorcode { get; set; }
            public string message { get; set; }
            public string debuginfo { get; set; }
        }

        public class MoodleImportCourse
        {
            public string importfrom { get; set; }
            public string importto { get; set; }
            public string deletecontent { get; set; }
            //public string options { get; set; }
            public string name { get; set; }
            public string value { get; set; }
            public string name1 { get; set; }
            public string value1 { get; set; }
            public string name2 { get; set; }
            public string value2 { get; set; }
        }
        public class MoodleGetCourseGroup
        {
            public string courseid { get; set; }
        }
        public class MoodleDeleteGroup
        {
            public string groupids { get; set; }
        }
        public class MoodleCreateCourseResponse
        {
            public string id { get; set; }
            public string shortname { get; set; }
        }
        public class MoodleGetCourseGroupResponse
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