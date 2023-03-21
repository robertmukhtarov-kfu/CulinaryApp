using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CulinaryApp.Model;
using System.Windows.Input;
using CulinaryApp.Data;

namespace CulinaryApp.ViewModel;

[QueryProperty(nameof(UserRecipe), "UserRecipe")]
public partial class EditUserRecipeViewModel : BaseViewModel
{
    UserRecipeDB db;

    [ObservableProperty]
    UserRecipe userRecipe;

    [ObservableProperty]
    bool isDeleteVisible = false;

    [ObservableProperty]
    string recipeTitle;

    [ObservableProperty]
    string recipeInstructions;

    public EditUserRecipeViewModel(UserRecipeDB db)
    {
        this.db = db;
        Title = "";
    }

    public void SetupView()
    {
        if (UserRecipe is not null)
        {
            RecipeTitle = UserRecipe.Title;
            RecipeInstructions = UserRecipe.Instructions;
            IsDeleteVisible = true;
        }
    }

    [RelayCommand]
    public async Task SaveRecipeAsync()
    {
        if (UserRecipe is null)
        {
            UserRecipe = new UserRecipe();
            UserRecipe.ID = 0;
        }
        UserRecipe.Title = RecipeTitle;
        UserRecipe.Instructions = RecipeInstructions;
        await db.SaveUserRecipeAsync(UserRecipe);
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    public async Task DeleteRecipeAsync()
    {
        await db.DeleteUserRecipeAsync(UserRecipe);
        await Shell.Current.GoToAsync("..");
    }
}
