using DemoApiCalls.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using System.Text.Json;

namespace DemoApiCalls.Services
{
    public class APICallsService
    {
        //private static readonly string baseURL = "https://127.0.0.1/v1/inputs";
        //private static readonly string baseURL = "https://localhost:44308/v1/inputs";

        public static string AuthToken;
        #region Using HttpClient
        public static async Task<HttpResponseMessage> GetAllInputsFromAPI(string url)
        {
            #region SSL Addendum
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            ServicePointManager.ServerCertificateValidationCallback =
                delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };
            #endregion


            if (string.IsNullOrEmpty(AuthToken))
            {
                Console.WriteLine("Authentication required. Please log in.");
                return null;
            }

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthToken);

            try
            {
                return await client.GetAsync(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in API Call. Message: {ex.Message}");
                return null;
            }
        }
        #endregion

        #region Using RestSharp - GetAllInputsFromAPI
        /*
        
        public static async Task<IRestResponse<object>> GetAllInputsFromAPI(string url)
        {
            #region SSL Addendum
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            ServicePointManager.ServerCertificateValidationCallback =
                delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };
            #endregion


            IRestResponse<object> response;

            Uri apiCallUri = new Uri($"{url}");

            //Prepare REST service communication

            RestClient serviceClient = new RestClient(apiCallUri);
            RestRequest request = new RestRequest(Method.GET);

            //Prepare request header
            //No information on header?
            try
            {
                response = await ExecuteAsync<object>(serviceClient, request);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in API Call. Message: {ex.Message}");
                return null;
            }

            return response;
        }
        */
        #endregion

        public static async Task<IRestResponse<object>> GetSpecificInputFromAPI(string url)
        {
            #region SSL Addendum
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            ServicePointManager.ServerCertificateValidationCallback =
                delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };
            #endregion

            IRestResponse<object> response;

            Uri apiCallUri = new Uri($"{url}");

            // Prepare REST service communication

            RestClient serviceClient = new RestClient(apiCallUri);
            RestRequest request = new RestRequest(Method.GET);

            // Prepare request header
            // No information on header?
            try
            {
                response = await ExecuteAsync<object>(serviceClient, request);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in API Call. Message: {ex.Message}");
                return null;
            }

            return response;
        }

        public static async Task<IRestResponse<object>> GetInputForSlot1FromAPI(string url)
        {
            #region SSL Addendum
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            ServicePointManager.ServerCertificateValidationCallback =
                delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };
            #endregion

            IRestResponse<object> response;

            Uri apiCallUri = new Uri($"{url}");

            // Prepare REST service communication

            RestClient serviceClient = new RestClient(apiCallUri);
            RestRequest request = new RestRequest(Method.GET);

            // Prepare request header
            // No information on header?
            try
            {
                response = await ExecuteAsync<object>(serviceClient, request);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in API Call. Message: {ex.Message}");
                return null;
            }

            return response;
        }

        //public static async Task<IRestResponse<object>> SetColorsOnAPI(string url, int Id)
        //{
        //    #region SSL Addendum
        //    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
        //    ServicePointManager.ServerCertificateValidationCallback =
        //        delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        //        {
        //            return true;
        //        };
        //    #endregion

        //    IRestResponse<object> response;

        //    Uri apiCallUri = new Uri($"{url}");



        //    // Prepare REST service communication

        //    RestClient serviceClient = new RestClient(apiCallUri);
        //    RestRequest request = new RestRequest(Method.PUT);

        //    // Prepare request header
        //    request.AddHeader(@"Accept", @"application/json");
        //    try
        //    {
        //        request.AddParameter("application/json", PrepareJsonForPost(Id), ParameterType.RequestBody);

        //        response = await ExecuteAsync<object>(serviceClient, request);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error in API Call. Message: {ex.Message}");
        //        return null;
        //    }

        //    return response;
        //}

        //public static async Task<HttpResponseMessage> SetColorsOnAPI1(string url, int Id)
        //{
        //    using var httpClient = new HttpClient();

        //    // create a JSON payload
        //    //var payload = new { Name = "John", Age = 30 };
        //    ColorsUpdateModel message = new ColorsUpdateModel()
        //    {
        //        InputId = Id,
        //        InputRedGain = 80,
        //        InputGreenGain = 85,
        //        InputBlueGain = 70
        //    };
        //    // serialize the payload to JSON string
        //    string jsonPayload = System.Text.Json.JsonSerializer.Serialize(message);

        //    // create a request message with the JSON payload
        //    var request = new HttpRequestMessage(HttpMethod.Put, url)
        //    {
        //        Content = new StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json")
        //    };

        //    // send the request and get the response
        //    HttpResponseMessage response; 
            
        //    try
        //    {
        //        response = await httpClient.SendAsync(request);
                
        //        if (response.IsSuccessStatusCode)
        //        {
        //            Console.WriteLine("PUT request was successful.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error in API Call. Message: {ex.Message}");
        //        return null;
        //    }

        //    return response;
        //}
        //public static async Task<HttpResponseMessage> SetColorsOnAPI2(string url, int Id)
        //{
        //    HttpResponseMessage response = null;
        //    ColorsUpdateModel message = new ColorsUpdateModel()
        //    {
        //        InputId = Id,
        //        InputRedGain = 80,
        //        InputGreenGain = 85,
        //        InputBlueGain = 70
        //    };

        //    string jsonData = System.Text.Json.JsonSerializer.Serialize(message);

        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(url);
        //        client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
        //        client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
        //        response = await client.PutAsync(url, new StringContent(jsonData, Encoding.UTF8, "application/json"));
        //    }


        //    return response;
        //}
        public static string PrepareJsonForPost(int Id)
        {
            string result = string.Empty;
            ColorsUpdateModel message = new ColorsUpdateModel()
            {
                InputId = Id,
                InputRedGain = 80,
                InputGreenGain = 85,
                InputBlueGain = 70
            };

            return JsonConvert.SerializeObject(message);
        }

        public static async Task<IRestResponse<T>> ExecuteAsync<T>(RestClient serviceClient, RestRequest request) where T : class, new()
        {
            var taskCompletionSource = new TaskCompletionSource<IRestResponse<T>>();
            serviceClient.ExecuteAsync<T>(request, (responseTask) => taskCompletionSource.SetResult(responseTask));

            var response = await taskCompletionSource.Task;
            return response;
        }



        public static async Task<IRestResponse<object>> TryRoutingAPI_1(string url)
        {
            #region SSL Addendum
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            ServicePointManager.ServerCertificateValidationCallback =
                delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };
            #endregion

            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Put, url);

                // 🔥 Exact JSON as a raw string (Mimics Postman)
                //string jsonBody1 = "{\r\n    \"id\": 0,\r\n    \"layout\": \"quad4\"\r\n}";
                var requestBody = new APIRequestModel
                {
                    Id = 0,
                    Layout = "quad4",
                    Window1Src = 0,
                    Window2Src = 1,
                    Window3Src = 1,
                    Window4Src = 0
                };

                // ✅ Serialize the object to JSON (camelCase by default)
                string jsonBody = System.Text.Json.JsonSerializer.Serialize(requestBody, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = null, // Ensures the names stay exactly as defined
                    WriteIndented = false // Minifies JSON for API compatibility
                });

                // ✅ Use `StringContent` with UTF-8 encoding
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                request.Content = content;

                try
                {
                    using (var response = await client.SendAsync(request))
                    {
                        response.EnsureSuccessStatusCode(); // Throws exception if not 2xx

                        // ✅ Print response
                        Console.WriteLine(await response.Content.ReadAsStringAsync());
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error in API Call: {ex.Message}");
                }
            }
            ////////////////////////////////////////////////


            IRestResponse<object> responseF=null;
            return responseF;
        }
        public static async Task<IRestResponse<object>> TryRoutingAPI_2(string url)
        {
            #region SSL Addendum
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            ServicePointManager.ServerCertificateValidationCallback =
                delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };
            #endregion

            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Put, url);

                var requestBody = new APIRequestModel
                {
                    Id = 0,
                    Layout = "quad1",
                    Window1Src = 1,
                    Window2Src = 0,
                    Window3Src = 0,
                    Window4Src = 1
                };

                // ✅ Serialize the object to JSON (camelCase by default)
                string jsonBody = System.Text.Json.JsonSerializer.Serialize(requestBody, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = null, // Ensures the names stay exactly as defined
                    WriteIndented = false // Minifies JSON for API compatibility
                });

                // ✅ Use `StringContent` with UTF-8 encoding
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                request.Content = content;

                try
                {
                    using (var response = await client.SendAsync(request))
                    {
                        response.EnsureSuccessStatusCode(); // Throws exception if not 2xx

                        // ✅ Print response
                        Console.WriteLine(await response.Content.ReadAsStringAsync());
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error in API Call: {ex.Message}");
                }
            }








            IRestResponse<object> responseF = null;
            return responseF;
        }
    }
}
