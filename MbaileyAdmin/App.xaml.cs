using MbaileyAdmin.Models;
using MbaileyAdmin.Pages;

namespace MbaileyAdmin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Login();
        }
    }
}
