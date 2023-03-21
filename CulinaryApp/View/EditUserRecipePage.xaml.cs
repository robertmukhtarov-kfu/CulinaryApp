using CommunityToolkit.Mvvm.ComponentModel;
using CulinaryApp.Model;
using CulinaryApp.ViewModel;

namespace CulinaryApp;


public partial class EditUserRecipePage : ContentPage
{
    public EditUserRecipePage(EditUserRecipeViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        (BindingContext as EditUserRecipeViewModel).SetupView();
        base.OnAppearing();
    }
}


