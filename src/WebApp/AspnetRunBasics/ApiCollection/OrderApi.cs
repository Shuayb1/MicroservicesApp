using AspnetRunBasics.ApiCollection.Infrastructure;
using AspnetRunBasics.ApiCollection.Interfaces;
using AspnetRunBasics.Models;
using AspnetRunBasics.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspnetRunBasics.ApiCollection
{
    public class OrderApi : BaseHttpClientWithFactory, IOrderApi
    {
        private readonly IApiSettings _settings;
        public OrderApi(IHttpClientFactory factory, IApiSettings settings)
            : base(factory)
        {
            _settings = settings;
        }

        public override HttpRequestBuilder GetHttpRequestBuilder(string path)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderResponseModel>> GetOrdersByUsername(string userNmae)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                                                    .SetPath(_settings.OrderPath)
                                                    .AddQueryString("username", userNmae)
                                                    .HttpMethod(HttpMethod.Get)
                                                    .GetHttpMessage();

            return await SendRequest<IEnumerable<OrderResponseModel>>(message);
        }
    }
}
