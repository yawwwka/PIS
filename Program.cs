using PIS.Services;
using System;
using System.Windows.Forms;

namespace PIS
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var passwordHasher = new PasswordHasher();
            var databaseService = new DatabaseService("Host=localhost;Username=postgres;Password=123123;Database=PISDB",
                passwordHasher);
            var userService = new UserService(databaseService, passwordHasher);
            var applicationService = new ApplicationService(databaseService);

            var app = new App(userService, applicationService);
            app.Run();
        }
    }
}