using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace MessagesClient.Models
{
    public class Message
    {

        public int MessageId { get; set; }
        public string UserName { get; set; }

        public string MessageText { get; set; }

        public int MessageNumber { get; set; }

        public string MessageNote { get; set; }

        public static List<Message> GetMessages()
        {
            var client = new RestClient("https://messageboard100.azurewebsites.net/");
            var request = new RestRequest("messages/get", Method.GET);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            Console.WriteLine(response.Content);

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
            Console.WriteLine(jsonResponse);
            var messageList = JsonConvert.DeserializeObject<List<Message>>(jsonResponse.ToString());
            return messageList;
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response =>
            {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
        public static void PostMessage(Message message)
        {
            var client = new RestClient("https://messageboard100.azurewebsites.net/");

            var request = new RestRequest("messages/post", Method.POST);

            // Json to post.
            string jsonToSend = JsonConvert.SerializeObject(message);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(jsonToSend);
            }

            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            try
            {
                client.ExecuteAsync(request, response =>
                {
                    //             if (response.StatusCode == HttpStatusCode.OK)
                    //             {
                    //     // OK
                    // }
                    //             else
                    //             {
                    //     // NOK
                    // }
                });
            }
            catch (Exception error)
            {
                // Log
            }


        }
    }
}