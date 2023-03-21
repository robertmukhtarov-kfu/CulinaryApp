namespace CulinaryApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = DeviceInfo.Current.Idiom == DeviceIdiom.Desktop ? new DesktopAppShell() : new AppShell();
	}
}

