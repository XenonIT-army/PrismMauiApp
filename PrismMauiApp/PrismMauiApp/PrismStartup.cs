using Ninject;
using Prism.Ioc;
using PrismMauiApp.Interface;
using PrismMauiApp.Model;
using PrismMauiApp.Moduls;
using PrismMauiApp.Views;

namespace PrismMauiApp;

internal static class PrismStartup
{
    public static void Configure(PrismAppBuilder builder)
    {
        builder.RegisterTypes(RegisterTypes)
                .OnAppStart("NavigationPage/MainPage");

    }

    private static void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<MainPage>()
                     .RegisterInstance(SemanticScreenReader.Default);
        containerRegistry.RegisterForNavigation<MainShell>()
                   .RegisterInstance(SemanticScreenReader.Default);
    }
}
