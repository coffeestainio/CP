using System;
using RestSharp;

namespace FacElec.helpers
{
    public static class RestHelper
    {
        private const string apiUrl = "https://coffeestain-api.herokuapp.com/api";

        public static void DoSomething()
        {
            var client = new RestClient(apiUrl);

            var request = new RestRequest("contact/add", Method.POST);
            request.AddHeader("Accept", "application/vnd.twitter-v1+json");
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new {email="pass1asdadda",phone="sdaa1sdasdasasdfssda",}); // replaces matching token in request.Resource

            // execute the request
            IRestResponse response2 = client.Execute<ResponseResultado>(request);
            dynamic name = response2.Content;
            var nombre = name.Result;

            // return content type is sniffed but can be explicitly set via RestClient.AddHandler()

        }
    }

    public class ResponseResultado{
        public string Result;

        public ResponseResultado(string result)
        {
            Result = result;
        }

        public ResponseResultado(){
            
        }
    }
}
