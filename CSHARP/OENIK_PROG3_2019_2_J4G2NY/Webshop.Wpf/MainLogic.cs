using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.Wpf
{
    class MainLogic
    {
        string url = "http://localhost:63263/api/LocationsApi/";
        HttpClient client = new HttpClient();

        void SendMessage(bool success)
        {
            string msg = success ? "Operation successed" : "Operation failed";
            Messenger.Default.Send(msg, "LocationResult");
        }

        public List<LocationVM> ApiGetLocations()
        {
            string json = client.GetStringAsync(url + "all").Result;
            var list = JsonConvert.DeserializeObject<List<LocationVM>>(json);
            //SendMessage(true);
            return list;
        }

        public void ApiDelLocation(LocationVM location)
        {
            bool success = false;
            if (location != null)
            {
                string json = client.GetStringAsync(url + "del/" + location.ID).Result;
                JObject obj = JObject.Parse(json);
                success = (bool)obj["OperationResult"];
            }
            SendMessage(success);
        }

        bool ApiEditLocation(LocationVM location, bool isEditing)
        {
            if (location == null) return false;
            string myUrl = isEditing ? url + "mod" : url + "add";

            Dictionary<string, string> postData = new Dictionary<string, string>();
            if (isEditing) postData.Add(nameof(LocationVM.ID), location.ID.ToString());
            postData.Add(nameof(LocationVM.Country), location.Country);
            postData.Add(nameof(LocationVM.Street), location.Street);
            postData.Add(nameof(LocationVM.Zip_Code), location.Zip_Code.ToString());
            postData.Add(nameof(LocationVM.House_Number), location.House_Number.ToString());

            string json = client.PostAsync(myUrl, new FormUrlEncodedContent(postData))
                .Result.Content.ReadAsStringAsync().Result;
            JObject obj = JObject.Parse(json);
            return (bool)obj["OperationResult"];
        }

        public void EditLocation(LocationVM location, Func<LocationVM, bool> editor)
        {
            LocationVM clone = new LocationVM();
            if (location != null) clone.CopyFrom(location);
            bool? success = editor?.Invoke(clone);
            if (success == true)
            {
                if (location != null) success = ApiEditLocation(clone, true);
                else success = ApiEditLocation(clone, false);
            }
            SendMessage(success == true);
        }
    }
}
