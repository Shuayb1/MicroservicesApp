using AspnetRunBasics.ApiCollection.Infrastructure;
using AspnetRunBasics.ApiCollection.Interfaces;
using AspnetRunBasics.Models;
using AspnetRunBasics.Settings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRunBasics.ApiCollection
{
    public class BasketApi : BaseHttpClientWithFactory, IBasketApi
    {
        private readonly IApiSettings _settings;

        public BasketApi(IHttpClientFactory factory, IApiSettings settings)
             : base(factory)
        {
            _settings = settings;
        }

        public async Task BasketCheckout(BasketCheckoutModel basketModel)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                                                    .SetPath(_settings.BasketPath)
                                                    .AddToPath("Checkout")
                                                    .HttpMethod(HttpMethod.Post)
                                                    .GetHttpMessage();

            var json = JsonConvert.SerializeObject(basketModel);
            message.Content = new StringContent(json, Encoding.UTF8, "application/json");
            await SendRequest<BasketCheckoutModel>(message);
        }

        public async Task<BasketModel> GetBasket(string userName)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                                        .SetPath(_settings.BasketPath)
                                        .AddQueryString("username", userName)
                                        .HttpMethod(HttpMethod.Get)
                                        .GetHttpMessage();

            return await SendRequest<BasketModel>(message);
        }

        public override HttpRequestBuilder GetHttpRequestBuilder(string path)
        {
            throw new NotImplementedException();
        }

        public async Task<BasketModel> UpdateBasket(BasketModel basketModel)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                                                    .SetPath(_settings.BasketPath)
                                                    .HttpMethod(HttpMethod.Post)
                                                    .GetHttpMessage();

            var json = JsonConvert.SerializeObject(basketModel);
            message.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return await SendRequest<BasketModel>(message);
        }

        Task<BasketCheckoutModel> IBasketApi.BasketCheckout(BasketCheckoutModel basketModel)
        {
            throw new NotImplementedException();
        }
    }
}
