using CommunityToolkit.Mvvm.ComponentModel;

namespace CulinaryApp.ViewModel;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    string title;
}
