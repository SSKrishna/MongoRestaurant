using Mongo.Web.Models;
using Mongo.Web.Services.IServices;
using Newtonsoft.Json;

namespace Mongo.Web.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDto responseModel { get; set; }

        public IHttpClientFactory httpClient { get; set; }

        public BaseService(IHttpClientFactory httpClient) 
        { 
            this.responseModel= new ResponseDto();
            this.httpClient = httpClient;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

        public Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = httpClient.CreateClient("MangoAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                client.DefaultRequestHeaders.Clear();
                if(apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert)
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
