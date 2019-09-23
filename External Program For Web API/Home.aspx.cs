using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Web.Http;
using System.Net.Http.Headers;
using System.Collections;
using System.Configuration;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace ExtProgramForWebAPI
{
    public partial class Home : System.Web.UI.Page
    {
        // Link to your API project.
        static string apiLink = "http://localhost:24497/api/";

        // This triggers the DELETE function in the API.
        public void deleteDataRequest()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(apiLink);
            var responseTask = client.DeleteAsync("values");
            responseTask.Wait();
            var result = responseTask.Result;
            if(string.Equals(result, "OK"))
            {
                lbl_Delete.Text = "Delete Successful;";
            }else
            {
                lbl_Delete.Text = "Delete Failed.";
            }
        }

        protected void btn_Post_Click(object sender, EventArgs e)
        {
            PostData();
        }

        // This triggers the POST function in the API.
        private void PostData()
        {
            string dataToBeSent = tb_PostEntry.Text.Trim();
            var client = new HttpClient();
            client.BaseAddress = new Uri(apiLink);
            var postTask = client.PostAsJsonAsync<string>("values?data=" + dataToBeSent, "PostAuth");
            postTask.Wait();
            var result = postTask.Result;
            string resultStr = postTask.Result.ReasonPhrase.ToString();
            if (resultStr == "OK")
            {
                var readTask = result.Content.ReadAsAsync<string>();
                readTask.Wait();
                string retStr = readTask.Result.ToString();
                lbl_PostResult.Text = retStr;
            }
        }
        
        protected void btn_GetData_Click(object sender, EventArgs e)
        {
            string data = "";

            data = getDataRequest();
            if (string.Equals(data, ""))
            {
                lbl_RetrievedData.Text = "No data has been retrieved.";
            }
            else
            {
                lbl_RetrievedData.Text = data;
            }
        }

        // This triggers the GET function in the API.
        public string getDataRequest()
        {
            var data = "";
            var client = new HttpClient();
            client.BaseAddress = new Uri(apiLink);
            var responseTask = client.GetAsync("values");
            responseTask.Wait();
            string resultStr = responseTask.Result.ReasonPhrase.ToString();
            if (resultStr == "OK")
            {
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<string>();
                    readTask.Wait();

                    data = readTask.Result;
                    return data;
                }
            }
            else
            {
                return "";
            }

            return data;
        }

        protected void btn_DeleteData_Click(object sender, EventArgs e)
        {
            deleteDataRequest();
        }
    }
}