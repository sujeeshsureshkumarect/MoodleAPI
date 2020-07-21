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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MoodleAPI
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Create_Click(object sender, EventArgs e)
        {
            //Start Check if user exists or not
            string get_users = core_user_get_users("firstname", txt_Username.Text.Trim());
            // Deserialize
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            if (get_users.Contains("exception"))
            {
                // Error
                MoodleException moodleError = serializer.Deserialize<MoodleException>(get_users);
                lbl_results.Text = get_users;
            }
            else
            {
                // Good
                Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(get_users);
                if (myDeserializedClass.users.Count > 0)
                {
                    string firstname = myDeserializedClass.users[0].firstname;
                    if (txt_Username.Text.Trim() == firstname)
                    {
                        lbl_results.Text = "User Exists Already";
                    }
                    else
                    {
                        //If user not exists then create a new user with below parameters;
                        string created_user = core_user_create_users(txt_Username.Text.Trim(), txt_Password.Text.Trim(), txt_FirstName.Text.Trim(), txt_LastName.Text.Trim(), txt_Email.Text.Trim(), txt_Mailformat.Text.Trim(), txt_Description.Text.Trim(), txt_City.Text.Trim(), txt_firstnamephonetic.Text.Trim(), txt_lastnamephonetic.Text.Trim(), txt_middlename.Text.Trim(), txt_alternatename.Text.Trim());
                        // Deserialize
                        JavaScriptSerializer serializercreated_user = new JavaScriptSerializer();
                        if (created_user.Contains("exception"))
                        {
                            // Error
                            MoodleException moodleError = serializercreated_user.Deserialize<MoodleException>(created_user);
                            lbl_results.Text = created_user;
                        }
                        else
                        {
                            List<MoodleCreatedUSer> newImport = serializercreated_user.Deserialize<List<MoodleCreatedUSer>>(created_user);
                            lbl_results.Text = "User Created Successfully";
                        }
                    }
                }
                else
                {
                    //If user not exists then create a new user with below parameters;
                    string created_user = core_user_create_users(txt_Username.Text.Trim(), txt_Password.Text.Trim(), txt_FirstName.Text.Trim(), txt_LastName.Text.Trim(), txt_Email.Text.Trim(), txt_Mailformat.Text.Trim(), txt_Description.Text.Trim(), txt_City.Text.Trim(), txt_firstnamephonetic.Text.Trim(), txt_lastnamephonetic.Text.Trim(), txt_middlename.Text.Trim(), txt_alternatename.Text.Trim());
                    // Deserialize
                    JavaScriptSerializer serializercreated_user = new JavaScriptSerializer();
                    if (created_user.Contains("exception"))
                    {
                        // Error
                        MoodleException moodleError = serializercreated_user.Deserialize<MoodleException>(created_user);
                        lbl_results.Text = created_user;
                    }
                    else
                    {
                        List<MoodleCreatedUSer> newImport = serializercreated_user.Deserialize<List<MoodleCreatedUSer>>(created_user);
                        lbl_results.Text = "User Created Successfully";
                    }
                }


            }
        }

        public string core_user_get_users(string key, string value)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            String token = "1b4cb9114197a84985695b19b1164d0a";

            MoodleGetUSer getusers = new MoodleGetUSer();
            getusers.key = HttpUtility.UrlEncode(key);
            getusers.value = HttpUtility.UrlEncode(value);

            List<MoodleGetUSer> groupsList = new List<MoodleGetUSer>();
            groupsList.Add(getusers);

            Array arrGroups = groupsList.ToArray();

            String postData = String.Format("criteria[0][key]={0}&criteria[0][value]={1}", getusers.key, getusers.value);
            string createRequest = string.Format("https://lms.ectmoodle.ae/webservice/rest/server.php?wstoken={0}&wsfunction={1}&moodlewsrestformat=json", token, "core_user_get_users");
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

        public string core_user_create_users(string username, string password, string firstname, string lastname, string email, string mailformat, string description, string city, string firstnamephonetic, string lastnamephonetic, string middlename, string alternatename)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            String token = "1b4cb9114197a84985695b19b1164d0a";

            MoodleCreateUser CreateUser = new MoodleCreateUser();
            CreateUser.username = HttpUtility.UrlEncode(username);
            CreateUser.password = HttpUtility.UrlEncode(password);
            //CreateUser.createpassword = HttpUtility.UrlEncode(createpassword);
            CreateUser.firstname = HttpUtility.UrlEncode(firstname);
            CreateUser.lastname = HttpUtility.UrlEncode(lastname);
            CreateUser.email = HttpUtility.UrlEncode(email);
            //CreateUser.auth = HttpUtility.UrlEncode(auth);
            //CreateUser.idnumber = HttpUtility.UrlEncode(idnumber);
            //CreateUser.lang = HttpUtility.UrlEncode(lang);
            //CreateUser.calendartype = HttpUtility.UrlEncode(calendartype);
            //CreateUser.theme = HttpUtility.UrlEncode(theme);
            //CreateUser.timezone = HttpUtility.UrlEncode(timezone);
            CreateUser.mailformat = HttpUtility.UrlEncode(mailformat);
            CreateUser.description = HttpUtility.UrlEncode(description);
            CreateUser.city = HttpUtility.UrlEncode(city);
            //CreateUser.country = HttpUtility.UrlEncode(country);
            CreateUser.firstnamephonetic = HttpUtility.UrlEncode(firstnamephonetic);
            CreateUser.lastnamephonetic = HttpUtility.UrlEncode(lastnamephonetic);
            CreateUser.middlename = HttpUtility.UrlEncode(middlename);
            CreateUser.alternatename = HttpUtility.UrlEncode(alternatename);

            List<MoodleCreateUser> groupsList = new List<MoodleCreateUser>();
            groupsList.Add(CreateUser);

            Array arrGroups = groupsList.ToArray();

            String postData = String.Format("users[0][username]={0}&users[0][password]={1}&users[0][firstname]={2}&users[0][lastname]={3}&users[0][email]={4}&users[0][mailformat]={5}&users[0][description]={6}&users[0][city]={7}&users[0][firstnamephonetic]={8}&users[0][lastnamephonetic]={9}&users[0][middlename]={10}&users[0][alternatename]={11}", CreateUser.username, CreateUser.password, CreateUser.firstname, CreateUser.lastname, CreateUser.email, CreateUser.mailformat, CreateUser.description, CreateUser.city, CreateUser.firstnamephonetic, CreateUser.lastnamephonetic, CreateUser.middlename, CreateUser.alternatename);
            string createRequest = string.Format("https://lms.ectmoodle.ae/webservice/rest/server.php?wstoken={0}&wsfunction={1}&moodlewsrestformat=json", token, "core_user_create_users");
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

        public class MoodleGetUSer
        {
            public string key { get; set; }
            public string value { get; set; }
        }
        public class MoodleException
        {
            public string exception { get; set; }
            public string errorcode { get; set; }
            public string message { get; set; }
            public string debuginfo { get; set; }
        }
        public class MoodleCreatedUSer
        {
            public string id { get; set; }
            public string username { get; set; }
        }

        public class Userss
        {
            public int id { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }
            public string fullname { get; set; }
            public int firstaccess { get; set; }
            public int lastaccess { get; set; }
            public bool suspended { get; set; }
            public string description { get; set; }
            public int descriptionformat { get; set; }
            public string city { get; set; }
            public string country { get; set; }
            public string profileimageurlsmall { get; set; }
            public string profileimageurl { get; set; }

        }
        public class MoodleCreateUser
        {
            public string username { get; set; }
            public string password { get; set; }
            //public string createpassword { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }
            public string email { get; set; }
            //public string auth { get; set; }
            //public string idnumber { get; set; }
            //public string lang { get; set; }
            //public string calendartype { get; set; }
            //public string theme { get; set; }
            //public string timezone { get; set; }
            public string mailformat { get; set; }
            public string description { get; set; }
            public string city { get; set; }
            //public string country { get; set; }
            public string firstnamephonetic { get; set; }
            public string lastnamephonetic { get; set; }
            public string middlename { get; set; }
            public string alternatename { get; set; }
        }
        public class Root
        {
            public List<Userss> users { get; set; }
            public List<object> warnings { get; set; }

        }
    }
}