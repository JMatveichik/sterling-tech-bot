using SterlingTechBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SterlingLib;

namespace SterlingTechBot.Services
{
	public class SterlingTradeApiService : ITradeApiService
	{
		private readonly ITradeXmlService _tradeXmlService;
		private readonly ISterlingTradeApi _sterlingTradeApi;



		public SterlingTradeApiService(ISterlingTradeApi sterlingTradeApi, ITradeXmlService tradeXmlService)
		{
			_tradeXmlService = tradeXmlService ?? throw new ArgumentNullException(nameof(tradeXmlService));
			_sterlingTradeApi = sterlingTradeApi ?? throw new ArgumentNullException(nameof(sterlingTradeApi));
		}

		public async Task<IEnumerable<structSTIOrderUpdate>> GetOrders(string accountId)
		{
			return await _sterlingTradeApi.GetOrders(accountId);
		}

		public async Task<bool> CopyOrders(string targetAccountId, IEnumerable<structSTIOrderUpdate> orders)
		{
			return await _sterlingTradeApi.CopyOrdes(targetAccountId, orders);
		}
	}
}
