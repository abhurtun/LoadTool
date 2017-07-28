using System;

namespace SimpleLoadTester {
    class Program {
        public static void Main(string[] args) {
            var test = new Loadtest();
            test.Run();
            Console.WriteLine("Test Finished!");
            Console.ReadKey();
        }
    }
}
