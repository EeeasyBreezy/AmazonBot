using System.Net;
using System.Text;
using System.IO;

namespace AmazonBot
{
    public class BaseBot
    {
        #region DATA
        protected HttpWebRequest request;
        protected HttpWebResponse response;
        protected string responseText;
        protected string requestBody;
        protected Encoding siteEncoding;
        protected CookieContainer container;
        protected CookieCollection cookies;
        #endregion

        #region CONSTRCUTORS
        public BaseBot()
        {
        }
        public BaseBot(Encoding siteEncoding)
        {
            this.siteEncoding = siteEncoding;
        }
        #endregion

        #region PROTECTED METHODS
        protected virtual void InitRequest(string uri, string method)
        {
            request = WebRequest.Create(uri) as HttpWebRequest;
            request.Method = method;
            request.KeepAlive = true;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.90 Safari/537.36";
            request.Accept = "*/*";
            request.Headers.Add(HttpRequestHeader.AcceptLanguage, "ru-RU,ru;q=0.8,en-US;q=0.6,en;q=0.4");
            request.Headers.Add(HttpRequestHeader.CacheControl, "no-cache");
        }
        protected void GetResponse()
        {
            StreamReader reader = null;
            try
            {
                response = request.GetResponse() as HttpWebResponse;
                reader = new StreamReader(response.GetResponseStream());
                responseText = reader.ReadToEnd();
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
        protected virtual void ManageCookies()
        {
            if (container != null)
            {
                request.CookieContainer = container;
                if(cookies != null)
                    request.CookieContainer.Add(cookies);
            }
            else
                request.CookieContainer = new CookieContainer();
        }
        protected virtual void SaveCookies()
        {
            container = request.CookieContainer;
        }
        protected void EncodeRequestBody()
        {
            byte[] requestBytes = siteEncoding.GetBytes(requestBody);
            request.GetRequestStream().Write(requestBytes, 0, requestBytes.Length);
        }
        #endregion
    }
}
