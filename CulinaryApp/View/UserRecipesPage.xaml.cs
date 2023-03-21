using CulinaryApp.Model;
using CulinaryApp.ViewModel;

namespace CulinaryApp;

public partial class UserRecipesPage : ContentPage
{
	public UserRecipesPage(UserRecipesViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        (BindingContext as UserRecipesViewModel).SetupView();
        base.OnAppearing();
    }

    async void ListView_ItemTapped(System.Object sender, Microsoft.Maui.Controls.ItemTappedEventArgs e)
    {
        var userRecipe = (e.Item as UserRecipe);
        await (BindingContext as UserRecipesViewModel).ShowRecipeDetail(userRecipe);
    }
}


