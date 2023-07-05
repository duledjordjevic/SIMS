using Biblioteka.ViewModel;

namespace Biblioteka.Service.Interface
{
    public interface ILoginService
    {
        void Login(string email, string password, MainViewModel mainViewModel);
    }
}
