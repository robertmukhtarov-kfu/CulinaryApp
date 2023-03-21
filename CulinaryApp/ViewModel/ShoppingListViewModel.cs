using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CulinaryApp.Model;
using System.Windows.Input;
using CulinaryApp.Data;

namespace CulinaryApp.ViewModel;

public partial class ShoppingListViewModel : BaseViewModel
{
    public ShoppingListItemDB db;

    public ObservableCollection<ShoppingListItem> shoppingListItems { get; set; } = new();

    public ShoppingListViewModel(ShoppingListItemDB db)
    {
        this.db = db;
        Title = "Shopping List";
    }

    public async void SetupView()
    {
        var list = await db.GetShoppingListItemsAsync();
        foreach (ShoppingListItem item in list)
        {
            shoppingListItems.Add(item);
        }
    }

    [RelayCommand]
    public async Task AddNewItemAsync()
    {
        string title = await App.Current.MainPage.DisplayPromptAsync("Add New Item", "Enter the item title");
        if (title == null || title.Length == 0) return;
        var newItem = new ShoppingListItem();
        newItem.Title = title;
        newItem.IsChecked = false;
        await db.SaveShoppingListItemAsync(newItem);
        shoppingListItems.Add(newItem);
    }

    [RelayCommand]
    public async Task RemoveSelectedItemsAsync()
    {
        var itemsToRemove = new List<ShoppingListItem>();
        foreach (var item in shoppingListItems)
        {
            if (item.IsChecked)
            {
                itemsToRemove.Add(item);
            }
        }
        foreach (var item in itemsToRemove)
        {
            await db.DeleteShoppingListItemAsync(item);
            shoppingListItems.Remove(item);
        }
    }

    public async void ItemCheckbox_CheckedChange(ShoppingListItem shoppingListItem)
    {
        if (shoppingListItem != null)
        {
            await db.SaveShoppingListItemAsync(shoppingListItem);
        }
    }
}
