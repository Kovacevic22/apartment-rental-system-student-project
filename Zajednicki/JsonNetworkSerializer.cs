using System.Net.Sockets;
using System.Text.Json;

namespace Zajednicki
{
    public class JsonNetworkSerializer
    {
        private readonly Socket socket;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;
        public JsonNetworkSerializer(Socket socket)
        {
            this.socket = socket;
            this.stream = new NetworkStream(socket);
            this.reader = new StreamReader(stream);
            this.writer = new StreamWriter(stream) { AutoFlush=true};
        }
        public void Send<T>(T data){
            writer.WriteLine(JsonSerializer.Serialize(data));
        }
        public T Recieve<T>()
        {
            string json = reader.ReadLine();
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
