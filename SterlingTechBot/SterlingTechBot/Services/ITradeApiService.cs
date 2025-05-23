using SterlingLib;
using SterlingTechBot.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SterlingTechBot.Services
{
	public interface ITradeApiService
	{
		Task <IEnumerable<structSTIOrderUpdate>> GetOrders(string accountId);
		Task<bool> CopyOrders(string targetAccountId, IEnumerable<structSTIOrderUpdate> orders);
	}
}
