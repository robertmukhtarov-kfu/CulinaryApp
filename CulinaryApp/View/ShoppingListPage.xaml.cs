using CulinaryApp.Model;
using CulinaryApp.ViewModel;

namespace CulinaryApp;

public partial class ShoppingListPage : ContentPage
{
	public ShoppingListPage(ShoppingListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
        (BindingContext as ShoppingListViewModel).SetupView();
    }

    void CheckBox_CheckedChanged(System.Object sender, Microsoft.Maui.Controls.CheckedChangedEventArgs e)
    {
		var checkBox = (CheckBox)sender;
        (BindingContext as ShoppingListViewModel).ItemCheckbox_CheckedChange(checkBox.BindingContext as ShoppingListItem);
    }
}


