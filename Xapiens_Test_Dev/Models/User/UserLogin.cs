using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5RealWorld.Models.User
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Please enter your Email", AllowEmptyStrings = false)]
        [Display(Name = "Enter Email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Please enter your password.")]
        [Display(Name = "Enter password")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        
    }

    public class Result
    {
        public string token { get; set; }

        public Result()
        {

        }

        public static Result GetToken(UserLogin u)
        {
            Result r = new Result();
            var httpWebRequest = (System.Net.WebRequest)System.Net.WebRequest.Create(new Uri_().url_Login);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new System.IO.StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(u);
                streamWriter.Write(json);
            }

            try
            {
                var httpResponse = (System.Net.HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new System.IO.StreamReader(httpResponse.GetResponseStream()))
                {
                    r = Newtonsoft.Json.JsonConvert.DeserializeObject<Result>(streamReader.ReadToEnd());
                }
            }
            catch (Exception er)
            {
                r.token = "error";
            }
          
           
            return r;
        }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class data
    {
        public int id { get; set; }
        public string name { get; set; }
        public int year { get; set; }
        public string color { get; set; }
        public string pantone_value { get; set; }
    }

    public class ListUsers
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<data> data { get; set; }
        public Support support { get; set; }

        public ListUsers()
        {

        }

        public static ListUsers GetList_User(string token)
        {
            ListUsers return_ = new ListUsers();
            var httpWebRequest = (System.Net.WebRequest)System.Net.WebRequest.Create(new Uri_().url_ListUser);
            httpWebRequest.Headers.Add("Authorization", "Bearer " + token);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            try
            {
                var httpResponse = (System.Net.HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new System.IO.StreamReader(httpResponse.GetResponseStream()))
                {
                    return_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ListUsers>(streamReader.ReadToEnd());
                }
            }
            catch (Exception er)
            {
                return_=null;
            }
            return return_;
        }

        public static string GetList_Data(string token,string u) {
            var httpWebRequest = (System.Net.WebRequest)System.Net.WebRequest.Create(u);
            httpWebRequest.Headers.Add("Authorization", "Bearer " + token);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            try
            {
                var httpResponse = (System.Net.HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new System.IO.StreamReader(httpResponse.GetResponseStream()))
                {
                    return streamReader.ReadToEnd();
                  // System.Diagnostics.Debug.WriteLine(streamReader.ReadToEnd());
                  //l = Newtonsoft.Json.JsonConvert.DeserializeObject<ListUsers>(streamReader.ReadToEnd());

                }
            }
            catch (Exception er)
            {
               return string.Empty;
            }
            return string.Empty;
        }

       
    }

    public class Support
    {
        public string url { get; set; }
        public string text { get; set; }
    }


}

namespace Xapiens
{

    public class Datum
    {
        public int id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string avatar { get; set; }
    }

    public class Ls
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<Datum> data { get; set; }
        public Support support { get; set; }
        public Ls()
        {

        }

        public static Ls GetList_Data(string token, string u)
        {
            Ls l = new Ls();
            var httpWebRequest = (System.Net.WebRequest)System.Net.WebRequest.Create(u);
            httpWebRequest.Headers.Add("Authorization", "Bearer " + token);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            try
            {
                var httpResponse = (System.Net.HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new System.IO.StreamReader(httpResponse.GetResponseStream()))
                {
                    l = Newtonsoft.Json.JsonConvert.DeserializeObject<Ls>(streamReader.ReadToEnd());

                }
            }
            catch (Exception er)
            {
                l = null;
            }
            return l;
        }
    }

    public class Support
    {
        public string url { get; set; }
        public string text { get; set; }
    }
}