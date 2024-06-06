using DIadocHttp;
using System.Text;
using System.Text.Json;

namespace DiadocHttp
{
    public class Program
    {
        static void Main(string[] args)
        {
            string diadocToken = "";
            string login = "";
            string password = "";
            string authToken;

            HttpMethods httpMethods = new();
            authToken = httpMethods.DiadocAuth(diadocToken, login, password);
        }
    }
}