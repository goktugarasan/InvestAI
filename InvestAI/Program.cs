namespace InvestAI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            //Test
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.Run(new Form1());
            Console.WriteLine("Hello, InvestAI!");
        }
    }
}