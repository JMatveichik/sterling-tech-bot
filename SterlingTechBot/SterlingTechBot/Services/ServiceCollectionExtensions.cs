using Microsoft.Extensions.DependencyInjection;
using SterlingTechBot.Views;
using SterlingTechBot.ViewModels;
using SterlingLib;

namespace SterlingTechBot.Services
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			// Регистрация сервисов
			services.AddTransient<ITradeApiService, SterlingTradeApiService>();
			services.AddTransient<ISterlingTradeApi, SterlingTradeApi>();
			services.AddTransient<ITradeXmlService, TradeXmlService>();

			services.AddSingleton<STIApp>(provider =>
			{
				var stiApp = new STIApp();
				return stiApp;
			});

			services.AddSingleton<STIEvents>(provider =>
			{
				var stiEvents = new STIEvents();
				return stiEvents;
			});


			// Регистрация ViewModels
			services.AddSingleton<MainViewModel>();

			//Регистрация Views
			services.AddSingleton<MainWindow>();
			services.AddSingleton<MainView>();

			return services;
		}
	}
}
