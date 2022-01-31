using System;
using System.Threading.Tasks;

namespace SongLibrary
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var startup = new Startup();
            await startup.Run();
        }
    }
}
