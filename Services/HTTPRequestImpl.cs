using System.Data;
using Internal;
using System.Threading.Tasks.Dataflow;
using ProyectGarantia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace ProyectGarantia.Services
{
    public class HTTPRequestImpl : IHTTPRequest
    {

        public async Task<string> ObtenerMensajeAsync()
        {

            using (HttpClient client = new HttpClient())
            {

                try
                {
                    string apiUrl = "https://190.99.17.152:10887/Api/Datoslotegarantias?Fchdesde=01/08/2023&Fchhasta=31/08/2023&Agencia=0125";

                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    Console.WriteLine(response);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(content);

                        // Deserializar la respuesta en un objeto
                        //DatosLoteGarantiasResponse objeto = JsonConvert.DeserializeObject<DatosLoteGarantiasResponse>(content);

                        // Aquí puedes trabajar con el objeto si es necesarios

                        // Serializar el objeto de nuevo a JSON
                        //string jsonString = JsonConvert.SerializeObject(objeto, Formatting.Indented);
                        return content;

                    }
                    else
                    {
                        throw new HttpRequestException("No se obtuvo correctamente los datos.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en petición.");
                }
            }

        }
    }
}
