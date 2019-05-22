using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Project.Repositories
{
    public class ClientIdSettingsRepository : IClientIdSettingsRepository
    {
        public void SaveClientId(string clientId)
        {
            //indien we testen....
            if (DeviceInfo.Platform == DevicePlatform.Unknown)
                throw new ArgumentException("Device niet herkend");

            Preferences.Set("ClientId", clientId);
        }

        public string GetClientId()
        {
            //indien we testen....
            if (DeviceInfo.Platform == DevicePlatform.Unknown)
                throw new ArgumentException("Device niet herkend");

            var ClientId = Preferences.Get("ClientId", "2938a4c0");
            return ClientId;
        }
    }
}
