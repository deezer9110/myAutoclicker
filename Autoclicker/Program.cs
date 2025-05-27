namespace Autoclicker
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());

            Autoclicker autoclicker = new Autoclicker(100000);
            autoclicker.startClicking();
            Thread.Sleep(20 * 1000); // Let it click for however many seconds u want, in this case 20 seconds
            autoclicker.stopClicking();

            // Hold Alt + Tab to get back to here and use shift + F% to stop the program in case you forget and don't wanna click everything in sight

        }
    }
}