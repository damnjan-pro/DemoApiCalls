using DemoApiCalls.Models;
using DemoApiCalls.Services;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DemoApiCalls.ViewModels
{
    public class TestViewModel: ObservableObject
    {
        private string UrlString = "https://192.168.1.219/v1/outputs/0";
        private string _text = "API CALLS";
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
        private bool _isButton1On;
        public bool IsButton1On
        {
            get
            {
                return _isButton1On;
            }
            set
            {
                _isButton1On = value;
                OnPropertyChanged(nameof(IsButton1On));
            }
        }
        private bool _isButton2On;
        public bool IsButton2On
        {
            get
            {
                return _isButton2On;
            }
            set
            {
                _isButton2On = value;
                OnPropertyChanged(nameof(IsButton2On));
            }
        }

        private bool _isButton3On;
        public bool IsButton3On
        {
            get
            {
                return _isButton3On;
            }
            set
            {
                _isButton3On = value;
                OnPropertyChanged(nameof(IsButton3On));
            }
        }

        private bool _isButton4On;
        public bool IsButton4On
        {
            get
            {
                return _isButton4On;
            }
            set
            {
                _isButton4On = value;
                OnPropertyChanged(nameof(IsButton4On));
            }
        }

        public  ICommand SendCommand => new DelegateCommand<object>(SendToAPI);

        private readonly string[] _layouts = { "single", "pip1", "pbp", "quad1" };
        private int _layoutIndex = 0;  // Start from "single"
        public string CurrentLayout => _layouts[_layoutIndex]; // Expose current layout
        private async void SendToAPI(object obj)
        {
            Text = string.Empty;
            // Cycle the layout on each click
            string currentLayout = _layouts[_layoutIndex];
            var requestBody = new APIRequestModel();
            string json = string.Empty;

            if (string.IsNullOrEmpty(UrlString))
            {
                MessageBox.Show("Please enter URL");
                return;
            }

            
            HttpResponseMessage response = null;
            int activeCount = (IsButton1On ? 1 : 0) +
                          (IsButton2On ? 1 : 0) +
                          (IsButton3On ? 1 : 0) +
                          (IsButton4On ? 1 : 0);

            // If no buttons are active, send minimal request

            if (activeCount == 0)
            {
                _layoutIndex = (_layoutIndex + 1) % _layouts.Length;
                currentLayout = _layouts[_layoutIndex];
                requestBody = new APIRequestModel
                {
                    Id = 0,
                    Layout = currentLayout // Minimal request body
                };
            }
            else
            {
                currentLayout = activeCount switch
                {
                    1 => "single",
                    2 => "pip1",
                    3 => "pbp",
                    4 => "quad1",
                    _ => "none" // This shouldn't happen, but just in case
                };
                requestBody = new APIRequestModel
                {
                    Id = 0,
                    Layout = currentLayout, // Use cycling layout
                    Window1Src = IsButton1On ? 1 : 0,
                    Window2Src = IsButton2On ? 1 : 0,
                    Window3Src = IsButton3On ? 1 : 0,
                    Window4Src = IsButton4On ? 1 : 0
                };
            }

            Text += $"Sending: Layout: {requestBody.Layout}.\n";
            //  Print in the TextBox
            json = System.Text.Json.JsonSerializer.Serialize(requestBody, new JsonSerializerOptions { WriteIndented = true });
            Text += $"Sending to API: {json}\n";

            response = await APICallsService.Post_Payload_To_API(UrlString, requestBody);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
            }
            else
            {
                string errorContent = await response.Content.ReadAsStringAsync();
            }
        }

        public TestViewModel()
        {

        }
    }
}
