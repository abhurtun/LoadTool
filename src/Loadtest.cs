using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleLoadTester {
    public class Loadtest {
        private static readonly ReaderWriterLockSlim Lock = new ReaderWriterLockSlim();

        public void Run() {
            const string INPUT_FILE = @"url_data.txt";

            Console.WriteLine($"Load Test Satrted! {DateTime.Now}");
            var urls = File.ReadAllLines(INPUT_FILE);
            foreach (var url in urls) {
                var responseMessage = _GetAsyncTiming(url);
                try {
                    Console.WriteLine($"Get {url} {responseMessage.Result.Item1.StatusCode}: {responseMessage.Result.Item2.TotalMilliseconds}ms");
                } catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static async Task<Tuple<HttpResponseMessage, TimeSpan>> _GetAsyncTiming(string url) {
            var stopWatch = Stopwatch.StartNew();
            using (var client = new HttpClient()) {
                var result = await client.GetAsync(url);
                return new Tuple<HttpResponseMessage, TimeSpan>(result, stopWatch.Elapsed);
            }
        }
    }
}
