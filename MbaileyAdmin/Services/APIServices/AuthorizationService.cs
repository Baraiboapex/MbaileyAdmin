using MbaileyAdmin.Models;

namespace MbaileyAdmin.Services.APIServices
{
    public class AuthorizationAPIService : BaseAPIService
    {
        private readonly List<User> _users = new List<User>() {
          new User()
          {
              Id = 1,
              FirstName = "Matthew",
              LastName="Bailey",
              Password= "DatBoi0717!",
              Email = "matthewpbaileydesigns@gmail.com"
          }
        };

        public AuthorizationAPIService() { }

        public ServiceResponse Login(string email, string password)
        {
            try
            {
                var getUser = _users.SingleOrDefault(u => u.Email == email && u.Password == password);

                if (getUser != null)
                {
                    var loginToken = new Dictionary<string, object>();

                    loginToken["loginToken"] = "7605690656352";

                    return BuildResponse(true, $"User {getUser} Logged In Successfully!", loginToken);
                }
                else
                {
                    throw new Exception("Could Not Login");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BuildResponse(false, ex.Message);
            }
        }
    }
}
