using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace  AggriPortal.API.Extensions
{
    public static class HttpExtensions
    {
        private static readonly JsonWriterOptions jOptions = new JsonWriterOptions
        {
            Indented = true
        };

        public async static Task WriteJson<T>(this HttpResponse response, T obj, string contentType = null)
        {
            response.ContentType = contentType ?? "application/json";

            using (var stream = new StreamWriter(response.Body, Encoding.UTF8))
            {
                using (var writer = new Utf8JsonWriter(response.Body, jOptions))
                {
                    JsonSerializer.Serialize(writer, obj);
                    await writer.FlushAsync().ConfigureAwait(false);
                }
            }
        }
    }
}
