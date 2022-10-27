using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace P.PHttpClient
{
    //note app life boyunca tek bir static httpclient'i reuse etmek daha iyi kaynak bakimindan diyorlar
    //https://stackoverflow.com/questions/37928543/httpclient-single-instance-with-different-authentication-headers
    //todo bir ara tekrar dusunup uygula istersen


    //p.portal startup'da tokengenaror DI notlarini oku
    public class ApiClient : IHttpClient
    {
        public ApiClient(string token = null)
        {
            HttpClient = new System.Net.Http.HttpClient();
            HttpClient.BaseAddress = new Uri(_apiUrl);
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));//accept icin asagidaki nota bak

            Token = token;
        }

        public const string AccessToken = "AccessToken";
        public const string JSON = "application/json";
        public static string _apiUrl;


        //using ile hemen dispose olmasi sart degil
        //https://stackoverflow.com/questions/15705092/do-httpclient-and-httpclienthandler-have-to-be-disposed
        private System.Net.Http.HttpClient HttpClient { get; }

        public static void Init(string apiUrl)
        {
            _apiUrl = apiUrl;
        }

        //api'ye yapilacak request api'de allowanonymous ise hic de set etmene gerek yok
        //yine de disarda null veya empty set edilse bile headers'lara eklensin cunku bu sefer portal'dan gonderdim sanip api'de o header'i bos da olsa ulasamamak hatanin nerde oldugunu anlamayi guclestirir
        //rule bu token request'ten sonra guncellenmis olabilir ve bu asil client'a iletilmelidir(mesela portal'a request'te bulunmus kisiye)
        //P.Portal.ClientController'daki notlari da oku
        private string _token;
        public string Token
        {
            get
            {
                return _token;
            }
            set
            {
                _token = value;

                if (this.HttpClient.DefaultRequestHeaders.Contains(AccessToken))
                    this.HttpClient.DefaultRequestHeaders.Remove(AccessToken);

                if (!string.IsNullOrEmpty(_token))
                    this.HttpClient.DefaultRequestHeaders.Add(AccessToken, _token);
            }
        }

        #region tokenli
        public virtual void Get<T>(string urlPath, Action<T, string> success, Action<HttpStatusCode, RemoteException> error)
        {
            var response = HttpClient.GetAsync(urlPath).Result;
            var responseData = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                //rule diyelim ki action'da bir kez daha apiclient.x() cagrilacak. bu satir suanki response ile gelen yeni token'i hic developer'i ugrastirmadan atamak icin yazildi
                if (response.Headers.Contains(AccessToken))//icermeyebilir cunku yapilan req allowanonymous'a ugramistir. dolayisiyla client'in portal'da sahip oldugu token'i bozmamak icin bu satir sart
                    this.Token = response.Headers.GetValues(AccessToken).Single();

                OnSuccess(success, responseData, Token);
            }
            else
                OnError(error, response.StatusCode, responseData);
        }

        public virtual void Get(string urlPath, Action<string> success, Action<HttpStatusCode, RemoteException> error)
        {
            var response = HttpClient.GetAsync(urlPath).Result;
            var responseData = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                if (response.Headers.Contains(AccessToken))
                    this.Token = response.Headers.GetValues(AccessToken).Single();

                success(Token);
            }
            else
                OnError(error, response.StatusCode, responseData);
        }

        public virtual void Post<T>(string urlPath, object data, Action<T, string> success, Action<HttpStatusCode, RemoteException> error)
        {
            var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            HttpContent httpContent = new StringContent(jsonContent, Encoding.UTF8, JSON);//note JSON bu 3. prm Content-Type header'ini ayarliyor https://stackoverflow.com/a/10679340

            var response = HttpClient.PostAsync(urlPath, httpContent).Result;
            var responseData = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                if (response.Headers.Contains(AccessToken))
                    this.Token = response.Headers.GetValues(AccessToken).Single();

                OnSuccess(success, responseData, Token);
            }
            else
                OnError(error, response.StatusCode, responseData);
        }

        public virtual void Post(string urlPath, object data, Action<string> success, Action<HttpStatusCode, RemoteException> error)
        {
            var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            HttpContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = HttpClient.PostAsync(urlPath, httpContent).Result;

            var responseData = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                if (response.Headers.Contains(AccessToken))
                    this.Token = response.Headers.GetValues(AccessToken).Single();

                success(Token);
            }
            else
                OnError(error, response.StatusCode, responseData);
        }

        #endregion

        #region tokensiz

        //her seferinde token'i disariya vermek istemediginde (mesela ic ice success'lerde)
        public void Get<T>(string urlPath, Action<T/*,string*/> success, Action<HttpStatusCode, RemoteException> error)
        {
            this.Get<T>(urlPath, (t, newToken) => { success(t); }, error);
        }

        public void Get<T>(string urlPath, Action<T/*,string*/> success)
        {
            this.Get<T>(urlPath, (t, newToken) => { success(t); });
        }

        public void Get(string urlPath, Action success, Action<HttpStatusCode, RemoteException> error)
        {
            this.Get(urlPath, (newToken) => { success(); }, error);
        }

        public void Get(string urlPath, Action success)
        {
            this.Get(urlPath, (newToken) => { success(); });
        }

        public void Post<T>(string urlPath, object data, Action<T> success, Action<HttpStatusCode, RemoteException> error)
        {
            this.Post<T>(urlPath, data, (t, newToken) => { success(t); }, error);
        }

        public void Post<T>(string urlPath, object data, Action<T> success)
        {
            this.Post<T>(urlPath, data, (t, newToken) => { success(t); });
        }

        public void Post(string urlPath, object data, Action success, Action<HttpStatusCode, RemoteException> error)
        {
            this.Post(urlPath, data, (newToken) => { success(); }, error);
        }

        public void Post(string urlPath, object data, Action success)
        {
            this.Post(urlPath, data, (newToken) => { success(); });
        }

        #endregion

        #region Default Error

        public virtual void Get<T>(string urlPath, Action<T, string> success)
        {
            Get(urlPath, success, ApiExceptionThrower.WrapAndThrow);
        }

        public virtual void Get(string urlPath, Action<string> success)
        {
            Get(urlPath, success, ApiExceptionThrower.WrapAndThrow);
        }

        public virtual void Post<T>(string urlPath, object data, Action<T, string> success)
        {
            Post(urlPath, data, success, ApiExceptionThrower.WrapAndThrow);
        }

        public void Post(string urlPath, object data, Action<string> success)
        {
            Post(urlPath, data, success, ApiExceptionThrower.WrapAndThrow);
        }

        #endregion

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
            }
            // free native resources if there are any.

            HttpClient.Dispose();
        }

        private void OnSuccess<T>(Action<T, string> successDelegate, string responseData, string token)
        {
            T obj = default(T);

            if (!string.IsNullOrEmpty(responseData))
                obj = JsonConvert.DeserializeObject<T>(responseData);

            successDelegate(obj, token);
        }

        private void OnError(Action<HttpStatusCode, RemoteException> error, HttpStatusCode statusCode, string exceptionJson)
        {
            RemoteException exp = null;

            if (!string.IsNullOrEmpty(exceptionJson))
                exp = JsonConvert.DeserializeObject<RemoteException>(exceptionJson);

            error(statusCode, exp);
        }
    }
}
