using RestSharp;

namespace WPFSample.Services
{
    public abstract class BaseService
    {
        private static readonly string DOMAIN = "http://localhost";
        private static readonly int PORT = 55173;
        private static readonly string MAIN_URL = DOMAIN + ':' + PORT.ToString() + '/';

        protected readonly RestClient restClient;

        public BaseService()
        {
            this.restClient = new RestClient(MAIN_URL);
        }
    }
}