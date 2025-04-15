using PIS.Forms;
using PIS.Models;
using PIS.Services;

namespace PIS
{
    public class App
    {
        private readonly UserService _userService;
        private readonly ApplicationService _applicationService;

        public App(UserService userService, ApplicationService applicationService)
        {
            _userService = userService;
            _applicationService = applicationService;
        }

        public void Run()
        {
            var authForm = new AuthForm(_userService, this);
            System.Windows.Forms.Application.Run(authForm);
        }

        public void ShowAdminMenu(User admin)
        {
            var adminForm = new AdminForm(_userService, _applicationService, admin);
            adminForm.Show();
        }

        public void ShowLandlordMenu(User landlord)
        {
            var landlordForm = new LandlordForm(_userService, _applicationService, landlord);
            landlordForm.Show();
        }

        public void ShowSpecialistMenu(User specialist)
        {
            var specialistForm = new SpecialistForm(_applicationService);
            specialistForm.Show();
        }
    }
}
