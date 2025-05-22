using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using SterlingTechBot.Models;
using SterlingTechBot.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using System.Windows;

namespace SterlingTechBot.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		private readonly ITradeApiService	 _tradeService;
		private readonly CompositeDisposable _disposables = new();

		[Reactive]
		public List<Trade> Trades { get; private set; } = new();

		[Reactive]
		public string Result { get; private set; } = string.Empty;

		[Reactive]
		public string SourceAccountId { get; set; } = "ACC-123";

		[Reactive]
		public string TargetAccountId { get; set; } = "ACC-456";

		[Reactive]
		public bool IsLoading { get;  private set; }

		public ReactiveCommand<Unit, Unit> LoadTradesCommand { get; private set; }
		public ReactiveCommand<Unit, Unit> CopyTradesCommand { get; private set; }

		public MainViewModel(ITradeApiService tradeService)
		{
			_tradeService = tradeService ?? throw new ArgumentNullException(nameof(tradeService));

			LoadTradesCommand = ReactiveCommand.CreateFromTask(LoadTrades);
			CopyTradesCommand = ReactiveCommand.CreateFromTask(CopyTrades);
		}

		private async Task LoadTrades()
		{
			IsLoading = true;
			try
			{
				var trades = await _tradeService.GetTrades(SourceAccountId);
				Trades = trades.ToList();
			}
			catch (Exception ex)
			{

			}
			finally
			{
				IsLoading = false;
			}
		}

		private async Task CopyTrades()
		{
			if (!Trades.Any())
				return;


			IsLoading = true;
			try
			{
				Result = await _tradeService.CopyTrades(Trades.ToList(), TargetAccountId);
			}
			catch (Exception ex)
			{
				return ;
			}
			finally {
				IsLoading = false;
			}
		}


		public void Dispose() => _disposables.Dispose();
	}
}
