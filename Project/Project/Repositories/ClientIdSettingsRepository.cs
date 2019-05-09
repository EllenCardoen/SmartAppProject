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
            Preferences.Set("ClientId", clientId);
        }

        public string GetClientId()
        {
            var ClientId = Preferences.Get("ClientId", "2938a4c0");
            return ClientId;
        }
    }
}
