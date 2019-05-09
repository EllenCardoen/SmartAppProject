using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Project.Repositories
{
    public class ShareRepository : IShareRepository
    {
        public async Task ShareContent(string url)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Uri = url,
                Title = "Share Web Link!"
                });
        }
    }
}
