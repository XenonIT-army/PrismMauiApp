namespace PrismMauiApp;

public partial class App : Application
{
    public static AppModuls AppModuls { get; private set; }
    public App()
    {
        InitializeComponent();
        AppModuls = new AppModuls();
    }
}
