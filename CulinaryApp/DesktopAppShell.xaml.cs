namespace CulinaryApp;

public partial class DesktopAppShell : Shell
{
	public DesktopAppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(EditUserRecipePage), typeof(EditUserRecipePage));
    }
}

