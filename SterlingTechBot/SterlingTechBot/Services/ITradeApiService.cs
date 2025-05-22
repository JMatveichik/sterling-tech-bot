using SterlingTechBot.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SterlingTechBot.Services
{
	public interface ITradeApiService
	{
		Task <IEnumerable<Trade>> GetTrades(string accountId);
		Task<string> CopyTrades(IEnumerable<Trade> trades, string targetAccountId);
	}
}
