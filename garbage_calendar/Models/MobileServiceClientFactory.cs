using System;
using System.Net.Http;
using Microsoft.WindowsAzure.MobileServices;

namespace garbage_calendar.Logic
{
    public class MobileServiceClientFactory
    {
        public static MobileServiceClient create()
        {
            try
            {
                return new MobileServiceClient(new Uri("https://garbage-calendar.azurewebsites.net"),
                    new HttpMessageHandler[] { });
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                throw e;
            }
        }
    }
}