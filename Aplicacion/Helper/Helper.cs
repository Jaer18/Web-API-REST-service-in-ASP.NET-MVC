using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Aplicacion.Helper
{
    public class ClienteAPI
    {
        public HttpClient Inicializa()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:7146");
            return client;
        }
    }
}
