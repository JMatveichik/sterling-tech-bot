using SterlingTechBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SterlingTechBot.Services
{
	public class SterlingTradeApiService : ITradeApiService
	{
		private readonly ITradeXmlService _tradeXmlService;
		private readonly ISterlingTradeApi _sterlingTradeApi;

		public SterlingTradeApiService(ISterlingTradeApi sterlingTradeApi, ITradeXmlService tradeXmlService)
		{
			_tradeXmlService  = tradeXmlService ?? throw new ArgumentNullException(nameof(tradeXmlService));
			_sterlingTradeApi = sterlingTradeApi ?? throw new ArgumentNullException(nameof(sterlingTradeApi));
		}

		public async Task<IEnumerable<Trade>> GetTrades(string accountId)
		{
			var xmlData = await _sterlingTradeApi.GetTrades(accountId);
			return _tradeXmlService.ParseTradesFromXml(xmlData);
		}

		public async Task<string> CopyTrades(IEnumerable<Trade> trades, string targetAccountId)
		{
			var xmlToSend = _tradeXmlService.ConvertTradesToXml(trades);
			await _sterlingTradeApi.CopyTrades(targetAccountId, xmlToSend);
			return xmlToSend;
		}
	}
}
