using Microsoft.Extensions.DependencyInjection;
using SterlingTechBot.Views;
using SterlingTechBot.ViewModels;

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


			// Регистрация ViewModels
			services.AddSingleton<MainViewModel>();

			//Регистрация Views
			services.AddSingleton<MainWindow>();
			services.AddSingleton<MainView>();

			return services;
		}
	}
}
