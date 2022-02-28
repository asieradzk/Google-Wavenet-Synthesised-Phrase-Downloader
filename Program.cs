using System.Management.Automation;

namespace WordsDownloader
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            new Thread(() =>
            {
                //Put folder named Key in the executable directory and your API key .json inside of it
                string path = Directory.GetCurrentDirectory();

                path = Directory.GetFiles(path + @"\Key")[0];


                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path, EnvironmentVariableTarget.Machine);

                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path, EnvironmentVariableTarget.User);
            }).Start();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());




            

        }
    }
}