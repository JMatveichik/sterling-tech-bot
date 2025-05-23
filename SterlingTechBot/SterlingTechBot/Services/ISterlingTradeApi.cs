using SterlingLib;
using SterlingTechBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SterlingTechBot.Services
{
	public interface ISterlingTradeApi
	{
		Task<IEnumerable<structSTIOrderUpdate>> GetOrders(string accountId);

		Task<bool> CopyOrdes(string targetAccountId, IEnumerable<structSTIOrderUpdate> orders);
	}
}
