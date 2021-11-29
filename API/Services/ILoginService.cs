namespace API.Services
{
    public interface ILoginService
    {
        public bool ValidateCredentials(string username, string password);
    }
}
