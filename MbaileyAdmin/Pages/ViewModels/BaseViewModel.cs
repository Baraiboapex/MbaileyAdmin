
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MbaileyAdmin.Pages.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        string title;

        //[AlsoNofitfyChangeFor(nameof(prop))]
        //[RelayCommand]
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsFinishedLoading))]
        bool isLoading;

        public bool IsFinishedLoading => !isLoading;

    }
}
