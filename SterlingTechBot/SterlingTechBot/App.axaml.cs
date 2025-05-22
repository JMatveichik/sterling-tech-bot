using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using SterlingTechBot.Services;
using SterlingTechBot.ViewModels;
using SterlingTechBot.Views;
using System;

namespace SterlingTechBot;

public partial class App : Application
{
	public ServiceProvider? ServiceProvider { get; private set; }

	public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var services = new ServiceCollection();
        services.AddApplicationServices();

        ServiceProvider = services.BuildServiceProvider();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
			var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
			var mainViewModel = ServiceProvider.GetRequiredService<MainViewModel>();

			mainWindow.DataContext = mainViewModel; // Устанавливаем DataContext
			desktop.MainWindow = mainWindow;
		}
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = ServiceProvider.GetRequiredService<MainView>();
			{
                DataContext = ServiceProvider.GetRequiredService<MainViewModel>();
			};
        }

        base.OnFrameworkInitializationCompleted();
    }
}
