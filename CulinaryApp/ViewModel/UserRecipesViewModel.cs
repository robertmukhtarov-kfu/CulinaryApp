using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CulinaryApp.Model;
using System.Windows.Input;
using CulinaryApp.Data;

namespace CulinaryApp.ViewModel;

public partial class UserRecipesViewModel : BaseViewModel
{
    public UserRecipeDB db;

    public ObservableCollection<UserRecipe> userRecipes { get; set; }

    public UserRecipesViewModel(UserRecipeDB db)
    {
        this.db = db;
        userRecipes = new ObservableCollection<UserRecipe>();
        Title = "My Recipes";
    }

    public async void SetupView()
    {
        userRecipes.Clear();
        var list = await db.GetUserRecipesAsync();
        foreach (var recipe in list)
        {
            userRecipes.Add(recipe);
        }
    }

    public async Task ShowRecipeDetail(UserRecipe userRecipe)
    {
        await Shell.Current.GoToAsync($"{nameof(EditUserRecipePage)}", true, new Dictionary<string, object>
        {
            {"UserRecipe", userRecipe }
        });
    }

    [RelayCommand]
    public async void AddNewRecipeAsync()
    {
        await Shell.Current.GoToAsync($"{nameof(EditUserRecipePage)}", true);
    }
}
