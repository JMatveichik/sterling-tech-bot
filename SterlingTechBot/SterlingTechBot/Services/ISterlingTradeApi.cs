using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SterlingTechBot.Services
{
	public interface ISterlingTradeApi
	{
		Task<string> GetTrades(string accountId);
		Task<bool> CopyTrades(string targetAccountId, string xmlToSend);
	}
}
