using PIS.Models;
using System.Collections.Generic;
using System.Linq;

namespace PIS.Services
{
    public class ApplicationService
    {
        private readonly DatabaseService _databaseService;

        public ApplicationService(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public void SubmitApplication(UserApplication application)
        {
            application.Id = GetAllApplications().Count + 1;
        }

        public List<UserApplication> GetApplicationsByUser(string email)
        {
            return GetAllApplications().Where(a => a.OwnerEmail == email).ToList();
        }

        public List<UserApplication> GetAllApplications() => _databaseService.GetAllApplications();
    }
}
