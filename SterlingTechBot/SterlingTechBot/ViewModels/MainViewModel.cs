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
using SterlingLib;

namespace SterlingTechBot.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		private readonly ITradeApiService	 _tradeService;
		private readonly CompositeDisposable _disposables = new();

		public ObservableCollection<Order> Orders { get; private set; } = new();


		private List<structSTIOrderUpdate> _recievedOrders = new();

		[Reactive]
		public string Result { get; private set; } = string.Empty;

		[Reactive]
		public string SourceAccountId { get; set; } = "ACC-123";

		[Reactive]
		public string TargetAccountId { get; set; } = "ACC-456";

		[Reactive]
		public bool IsLoading { get;  private set; }

		public ReactiveCommand<Unit, Unit> LoadTradesCommand { get; private set; }
		public ReactiveCommand<Unit, Unit> CopyOrdersCommand { get; private set; }

		public MainViewModel(ITradeApiService tradeService)
		{
			_tradeService = tradeService ?? throw new ArgumentNullException(nameof(tradeService));

			LoadTradesCommand = ReactiveCommand.CreateFromTask(LoadTrades);
			CopyOrdersCommand = ReactiveCommand.CreateFromTask(CopyOrders);
		}

		private async Task LoadTrades()
		{
			IsLoading = true;
			try
			{
				var orders = await _tradeService.GetOrders(SourceAccountId);

				Orders.Clear();
				foreach (var ord in orders)
				{
					Orders.Add (new Order(){
						Id = ord.bstrClOrderId,
						Quantity = ord.nQuantity,
						Symbol = ord.bstrSymbol,
						Timestamp = ord.bstrStartTime
						});
				}
			}
			catch (Exception ex)
			{
				Result = ex.Message;
			}
			finally
			{
				IsLoading = false;
			}
		}

		private async Task CopyOrders()
		{
			if (!_recievedOrders.Any())
				return;


			IsLoading = true;
			try
			{
				bool succses = await _tradeService.CopyOrders(TargetAccountId, _recievedOrders);
				Result = succses ? "Error" : "Succses";
			}
			catch (Exception ex)
			{
				Result = ex.Message;
			}
			finally {
				IsLoading = false;
			}
		}
		public void Dispose() => _disposables.Dispose();
	}
}
