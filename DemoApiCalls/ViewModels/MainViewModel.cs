using DemoApiCalls.Models;
using DemoApiCalls.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Prism.Commands;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DemoApiCalls.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        #region Properties


        private string _text = "API CALL RESULT";
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        private int _id = 1;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string _urlString = "https://192.168.1.219";
        public string UrlString
        {
            get
            {
                return _urlString;
            }
            set
            {
                _urlString = value;
                OnPropertyChanged(nameof(UrlString));
            }
        }
        #endregion



        #region Commands
        public ICommand PerformAPICallCommand => new DelegateCommand<object>(PerformAPICall);
        #endregion

        #region Constructor

        public MainViewModel()
        {
            
        }

        #endregion

        #region Funcs

        private async void PerformAPICall(object enumObject)
        {
            var requestBody = new APIRequestModel();
            string json = string.Empty;

            if (string.IsNullOrEmpty(UrlString))
            {
                MessageBox.Show("Please enter URL");
                return;
            }

            string url = string.Empty;

            var enumArrived = (ApiCallsEnum)enumObject;
            HttpResponseMessage response = null;
            switch (enumArrived)
            {
                case ApiCallsEnum.Task_5:
                    Text = string.Empty;
                    Text += "Route input 1 to the window 1 of the output 1.\n";
                    url = $"{UrlString}/v1/outputs/0";
                    Text += $"URL: {url}\n";
                    requestBody = new APIRequestModel
                    {
                        Id = 0,
                        Layout = "single",
                        Window1Src = 0
                    };
                    //  Print in the TextBox
                    json = System.Text.Json.JsonSerializer.Serialize(requestBody, new JsonSerializerOptions { WriteIndented = true });
                    Text += $"Sending to API: {json}\n";

                    response = await APICallsService.Post_Payload_To_API(url, requestBody);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        SetHttpClientResultToTextBox(responseBody);
                    }
                    else
                    {
                        string errorContent = await response.Content.ReadAsStringAsync();
                        Text += $"API Error: {errorContent}";
                    }
                    break;

                case ApiCallsEnum.Task_6:
                    Text = string.Empty;
                    Text += "Route input 1,2 to the window 1 and window 2 of the output 1.\n";
                    url = $"{UrlString}/v1/outputs/0";
                    Text += $"URL: {url}\n";
                    requestBody = new APIRequestModel
                    {
                        Id = 0,
                        Layout = "pip",
                        Window1Src = 0,
                        Window2Src = 1
                    };
                    //  Print in the TextBox
                    json = System.Text.Json.JsonSerializer.Serialize(requestBody, new JsonSerializerOptions { WriteIndented = true });
                    Text += $"Sending to API: {json}\n";

                    response = await APICallsService.Post_Payload_To_API(url, requestBody);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        SetHttpClientResultToTextBox(responseBody);
                    }
                    else
                    {
                        string errorContent = await response.Content.ReadAsStringAsync();
                        Text += $"API Error: {errorContent}";
                    }
                    break;
                case ApiCallsEnum.Task_7:
                    Text = string.Empty;
                    Text += "Route input 1,2 to the window 1 and window 2 of the output 1.\n";
                    url = $"{UrlString}/v1/outputs/0";
                    Text += $"URL: {url}\n";
                    requestBody = new APIRequestModel
                    {
                        Id = 0,
                        Layout = "pbp",
                        Window1Src = 0,
                        Window2Src = 1
                    };
                    //  Print in the TextBox
                    json = System.Text.Json.JsonSerializer.Serialize(requestBody, new JsonSerializerOptions { WriteIndented = true });
                    Text += $"Sending to API: {json}\n";

                    response = await APICallsService.Post_Payload_To_API(url, requestBody);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        SetHttpClientResultToTextBox(responseBody);
                    }
                    else
                    {
                        string errorContent = await response.Content.ReadAsStringAsync();
                        Text += $"API Error: {errorContent}";
                    }
                    break;
                case ApiCallsEnum.Task_8:
                    Text = string.Empty;
                    Text += "Route input 1,2,3,4 to the window 1,2,3,4 of the output 1.\n";
                    url = $"{UrlString}/v1/outputs/0";
                    Text += $"URL: {url}\n";
                    requestBody = new APIRequestModel
                    {
                        Id = 0,
                        Layout = "quad",
                        Window1Src = 0,
                        Window2Src = 1,
                        Window3Src = 2,
                        Window4Src = 3,
                    };
                    //  Print in the TextBox
                    json = System.Text.Json.JsonSerializer.Serialize(requestBody, new JsonSerializerOptions { WriteIndented = true });
                    Text += $"Sending to API: {json}\n";

                    response = await APICallsService.Post_Payload_To_API(url, requestBody);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        SetHttpClientResultToTextBox(responseBody);
                    }
                    else
                    {
                        string errorContent = await response.Content.ReadAsStringAsync();
                        Text += $"API Error: {errorContent}";
                    }
                    break;

                case ApiCallsEnum.ChangeLayout:
                    Text = string.Empty;
                    Text += "Change Layout.\n";
                    url = $"{UrlString}/v1/outputs/0";
                    Text += $"URL: {url}\n";

                    App.DataContext.CurrentLayout = GetNextLayout(App.DataContext.CurrentLayout);

                    requestBody = new APIRequestModel
                    {
                        Id = 0,
                        Layout = App.DataContext.CurrentLayout.ToString(),
                        Window1Src = 0,
                        Window2Src = 1,
                        Window3Src = 0,
                        Window4Src = 1
                    };
                    //  Print in the TextBox
                    json = System.Text.Json.JsonSerializer.Serialize(requestBody, new JsonSerializerOptions { WriteIndented = true });
                    Text += $"Sending to API: {json}\n";

                    response = await APICallsService.Post_Payload_To_API(url, requestBody);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        SetHttpClientResultToTextBox(responseBody);
                    }
                    else
                    {
                        string errorContent = await response.Content.ReadAsStringAsync();
                        Text += $"API Error: {errorContent}";
                    }
                    break;
                case ApiCallsEnum.ChangeLayoutPlus:
                    Text = string.Empty;
                    Text += "Change Layout.\n";
                    url = $"{UrlString}/v1/outputs/0";
                    Text += $"URL: {url}\n";

                    App.DataContext.CurrentLayout = await GetCurrentLayoutFromAPI(url);

                    App.DataContext.CurrentLayout = GetNextLayout(App.DataContext.CurrentLayout);

                    requestBody = new APIRequestModel
                    {
                        Id = 0,
                        Layout = App.DataContext.CurrentLayout.ToString(),
                        Window1Src = 0,
                        Window2Src = 1,
                        Window3Src = 0,
                        Window4Src = 1
                    };
                    //  Print in the TextBox
                    json = System.Text.Json.JsonSerializer.Serialize(requestBody, new JsonSerializerOptions { WriteIndented = true });
                    Text += $"Layout Sending to API: {App.DataContext.CurrentLayout}\n";

                    response = await APICallsService.Post_Payload_To_API(url, requestBody);
                    if (response.IsSuccessStatusCode)
                    {
                        Text += $"New layout: {App.DataContext.CurrentLayout}\n";
                        string responseBody = await response.Content.ReadAsStringAsync();
                        SetHttpClientResultToTextBox(responseBody);
                    }
                    else
                    {
                        string errorContent = await response.Content.ReadAsStringAsync();
                        Text += $"API Error: {errorContent}";
                    }
                    break;


                ////OLD
                //case ApiCallsEnum.GetAllInputs:
                //    Text = string.Empty;
                //    Text += "Request for all inputs initiated.\n";
                //    url = $"{UrlString}/v1/outputs/0";
                //    Text += $"URL: {url}\n";
                //    response = await APICallsService.TryRoutingAPI_1(url);
                //    SetResultToTextBox(response);
                //    break;
                //case ApiCallsEnum.GetSpecificInput:
                //    Text = string.Empty;
                //    Text += "Request for specific input initiated.\n";
                //    url = $"{UrlString}/v1/outputs/0";
                //    Text += $"URL: {url}\n";
                //    response = await APICallsService.TryRoutingAPI_2(url);
                //    SetResultToTextBox(response);
                //    break;
                //case ApiCallsEnum.GetInputsForSlot1:
                //    Text = string.Empty;
                //    Text += "Request for input for slot 1 initiated.\n";
                //    url = $"{UrlString}/v1/outputs/0";
                //    Text += $"URL: {url}\n";
                //    response = await APICallsService.TryRoutingAPI_3(url);
                //    SetResultToTextBox(response);
                //    break;

                ////Set Colors API Calls
                //case ApiCallsEnum.SetColors:
                //    Text = string.Empty;
                //    Text += "Request for input for slot 1 initiated.\n";
                //    url = $"{UrlString}/v1/outputs/0";
                //    Text += $"URL: {url}\n";
                //    response = await APICallsService.TryRoutingAPI_4(url);
                //    SetResultToTextBox(response);
                //    break;
                //    //Text = string.Empty;
                //    //Text += "Request for colors setting initiated.\n";
                //    //Text += "Sending:\n";
                //    //Text += $"{APICallsService.PrepareJsonForPost(Id)}.\n\n";
                //    //url = $"{UrlString}/v1/inputs";
                //    ////Text += $"URL: {url}\n";
                //    //Text += $"ID Sending: {Id}\n";
                //    //await SetColorsOnAPI(url, Id);
                //    ////SetResultToTextBox(response);
                //    //break;
                //case ApiCallsEnum.SetColors1:
                //    Text = string.Empty;
                //    Text += "Request for colors setting 1 initiated.\n";
                //    Text += "Sending:\n";
                //    Text += $"{APICallsService.PrepareJsonForPost(Id)}.\n\n";
                //    url = $"{UrlString}";
                //    Text += $"ID Sending: {Id}\n";
                //    await SetColorsOnAPI1(url, Id);
                //    //SetHttpClientResultToTextBox(await response1.Content.ReadAsStringAsync());
                //    break;
                //case ApiCallsEnum.SetColors2:
                //    Text = string.Empty;
                //    Text += "Request for colors setting 2 initiated.\n";
                //    Text += "Sending:\n";
                //    Text += $"{APICallsService.PrepareJsonForPost(Id)}.\n\n";
                //    url = $"{UrlString}/v1/inputs";
                //    //Text += $"URL: {url}\n";
                //    Text += $"ID Sending: {Id}\n";
                //    await SetColorsOnAPI2(url, Id);
                //    //SetHttpClientResultToTextBox(await response2.Content.ReadAsStringAsync());
                //    break;
                default:
                    break;
            }


            //SetResultToTextBox(response);

            Text += "Request completed.\n";

        }

        private async Task<Layouts> GetCurrentLayoutFromAPI(string url)
        {
            Text = string.Empty;
            Text += "GetCurrentLayoutFromAPI.\n";
            url = $"{UrlString}/v1/outputs/0";
            Text += $"URL: {url}\n";

            HttpResponseMessage response = await APICallsService.Get_Response_From_API(url);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();

                using (JsonDocument doc = JsonDocument.Parse(jsonResponse))
                {
                    if (doc.RootElement.TryGetProperty("layout", out JsonElement layoutElement))
                    {
                        string layoutString = layoutElement.GetString();
                        if (Enum.TryParse(layoutString, true, out Layouts layoutEnum)) // ✅ Case-insensitive conversion
                        {
                            Text += $"Former Layout: {layoutEnum}\n";
                            return layoutEnum;

                        }
                        else
                        {
                            Text += $"\"Invalid layout value received from API\n";
                        }
                    }
                    else
                    {
                        Text += $"Layout property not found in API response.\n";
                    }
                }
            }
            else
            {
                Console.WriteLine($"API Call Failed: {response.StatusCode} - {response.ReasonPhrase}");
            }
            return Layouts.single;
        }

        private Layouts GetNextLayout(Layouts current)
        {
            Layouts[] values = (Layouts[])Enum.GetValues(typeof(Layouts));
            int currentIndex = Array.IndexOf(values, current);
            int nextIndex = (currentIndex + 1) % values.Length;
            return values[nextIndex];
        }
        public async Task SetColorsOnAPI(string url, int Id)
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

            Text += $"URL: {url}\n";

            // Prepare REST service communication

            RestClient serviceClient = new RestClient(apiCallUri);
            RestRequest request = new RestRequest(Method.PUT);

            // Prepare request header
            request.AddHeader(@"Accept", @"application/json");
            var stringJson = "{\"id\":1,\"red\":80,\"green\":85,\"blue\":70}";

            try
            {
                request.AddParameter("application/json", stringJson, ParameterType.RequestBody);

                response = await ExecuteAsync<object>(serviceClient, request);

                if (response != null)
                {
                    Text += "response != null\n";

                
                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    Text += "response != null && response.StatusCode == HttpStatusCode.OK\n";
                    
                }
                else if (response != null && response.StatusCode != HttpStatusCode.OK)
                    {
                        Text += "response != null && response.StatusCode != HttpStatusCode.OK\n";
                        Text += $"response.StatusCode : {response.StatusCode}\n";


                    }
                }
                if (response.Content != null)
                {

                    Text += "response.Content != null\n";
                    Text += $"response.Content: {response.Content}\n";
                    var deserializedresponse = JsonConvert.DeserializeObject(response.Content);

                    if (deserializedresponse != null)
                    {
                        Text += $"deserializedresponse != null\n";
                        Text += $"deserializedresponse: {deserializedresponse} \n";
                    }

                }
                if (response != null && response.ErrorMessage != null)
                {

                    Text += $"Error: {response.ErrorMessage}\n";
                }
                

                else {

                    Text += "response.Content == null\n";
                }

            }
            catch (Exception ex)
            {
                Text += $"Exception happend; ex: {ex}, message: {ex.Message}\n";
            }

        }

        public async Task SetColorsOnAPI2(string url, int Id)
        {
            using var client = new HttpClient();

            var jsonContent = "{\"id\":1,\"red\":80,\"green\":85,\"blue\":70}";
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json") { CharSet = "utf-8" };

            Text += $"URL: {url}\n";
            try
            {
                HttpResponseMessage response = await client.PutAsync(url, content);

                if (response != null)
                {
                    Text += "response != null\n";


                    if (response != null && response.StatusCode == HttpStatusCode.OK)
                    {
                        Text += "response != null && response.StatusCode == HttpStatusCode.OK\n";

                    }
                    else if (response != null && response.StatusCode != HttpStatusCode.OK)
                    {
                        Text += "response != null && response.StatusCode != HttpStatusCode.OK\n";
                        Text += $"response.StatusCode : {response.StatusCode}\n";


                    }
                }
                if (response.Content != null)
                {

                    Text += "response.Content != null\n";
                    Text += $"response.Content: {response.Content}\n";

                    var res = response.Content.ReadAsStringAsync();
                    Text += $"res: {res}\n";

                    var deserializedresponse = JsonConvert.DeserializeObject(res.Result);

                    if (deserializedresponse != null)
                    {
                        Text += $"deserializedresponse != null\n";
                        Text += $"deserializedresponse: {deserializedresponse} \n";
                    }

                }
         


                else
                {

                    Text += "response.Content == null\n";
                }

            }
            catch (Exception ex)
            {
                Text += $"Exception happend; ex: {ex}, message: {ex.Message}\n";
            }

        }

        public static async Task<IRestResponse<T>> ExecuteAsync<T>(RestClient serviceClient, RestRequest request) where T : class, new()
        {
            var taskCompletionSource = new TaskCompletionSource<IRestResponse<T>>();
            serviceClient.ExecuteAsync<T>(request, (responseTask) => taskCompletionSource.SetResult(responseTask));

            var response = await taskCompletionSource.Task;
            return response;
        }

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


        //  Second Color call
        public async Task SetColorsOnAPI1(string url, int Id)
        {
            using var client = new HttpClient();

            //url = "http://192.168.200.170:8080/v1/presets/9";
            var jsonContent = "{\"action\":\"load\"}";
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json") { CharSet = "utf-8" };

            Text += $"URL: {url}\n";
            try
            {
                var response = await client.PutAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    Text += "Request succeeded!\n";
                }
                else
                {
                    Text += $"Request failed with status code: {response.StatusCode}\n";

                }
            }
            catch (Exception ex)
            {

                Text += $"Exception: {ex}, message: {ex.Message}\n";
            }

            
        }

        private void SetResultToTextBox(IRestResponse<object> result)
        {
            if (result == null)
            {
                Text += "No answer received from API.\n";
                return;
            }
            if (result != null && result.Content != null)
            {
                //Text += "Answer received from API; ";

                if (result.StatusCode == System.Net.HttpStatusCode.OK) 
                {
                    Text += "Status Code OK.\n";
                    try
                    {
                        var deserializedresponse = JsonConvert.DeserializeObject(result.Content);
                        Text += $"Response from API: {deserializedresponse}\n";
                    }
                    catch (Exception ex)
                    {

                        Text += $"Error receiving data from API. Error: {ex.Message}\n";
                    }
                }
                else
                {
                    Text += "Status Code NOT OK.\n";
                }
            }
        }

        private void SetHttpClientResultToTextBox(string result)
        {
            if (string.IsNullOrEmpty(result))
            {
                Text += "No answer received from API.\n";
                return;
            }
            if (!string.IsNullOrEmpty(result))
            {
                //Text += "Answer received from API; ";

                if (!string.IsNullOrEmpty(result))
                {
                    Text += "Status Code OK.\n";
                    try
                    {
                        var deserializedresponse = JsonConvert.DeserializeObject(result);
                        Text += $"Response from API: {deserializedresponse}\n";
                    }
                    catch (Exception ex)
                    {

                        Text += $"Error receiving data from API. Error: {ex.Message}\n";
                    }
                }
                else
                {
                    Text += "Status Code NOT OK.\n";
                }
            }
        }

        public static async Task<string> AuthenticateAndGetToken(string url, string password)
        {
            var client = new HttpClient();
            var requestUrl = $"{url}/v1/auth";

            var payload = new { pass = password };
            var jsonPayload = JsonConvert.SerializeObject(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync(requestUrl, content);
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Authentication failed: {response.StatusCode}");
                    return null;
                }

                var responseContent = await response.Content.ReadAsStringAsync();
                var tokenResponse = JsonConvert.DeserializeObject<AuthResponse>(responseContent);
                return tokenResponse?.Token;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during authentication: {ex.Message}");
                return null;
            }
        }
        #endregion
    }
}
