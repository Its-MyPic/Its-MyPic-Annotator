using System.Net;

namespace MyPic_Annotator
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
            WebProxy myProxy = new("127.0.0.1", 7777)
            {
                BypassProxyOnLocal = true
            };
            WebRequest.DefaultWebProxy = myProxy;
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}