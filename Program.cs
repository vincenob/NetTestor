namespace NetTestor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running...");
            try
            {
                Test().Wait();
            }
            catch {}
            Console.WriteLine("Done");
        }

        private static async Task Test()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            int timeout = 3000;
            cts.CancelAfter(timeout);
            while (await DoSomething(cts.Token))
            {
                timeout = timeout / 2;
                cts.CancelAfter(timeout);
            }
        }

        private static async Task<bool> DoSomething(CancellationToken cancellationToken)
        {
            Console.WriteLine($"{DateTime.Now} ***Doing Something***");
            await Task.Delay(1000, cancellationToken);
            return true;
        }
    }
}