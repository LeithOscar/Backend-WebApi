namespace API.Services
{
    public class LoginService: ILoginService
    {
        public bool ValidateCredentials(string username, string password)
        {
            return username.Equals("admin") && password.Equals("PasS");
        }
    }
}
