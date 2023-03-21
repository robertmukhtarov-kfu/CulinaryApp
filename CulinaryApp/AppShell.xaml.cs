namespace CulinaryApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(EditUserRecipePage), typeof(EditUserRecipePage));
    }
}

