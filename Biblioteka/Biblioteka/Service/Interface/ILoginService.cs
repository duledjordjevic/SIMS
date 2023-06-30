using Biblioteka.ViewModel;

namespace Biblioteka.Service.Interface
{
    public interface ILoginService
    {
        void Login(string username, string Password, MainViewModel mainViewModel);
    }
}
