using SterlingTechBot.Models;
using System.Collections.Generic;


namespace SterlingTechBot.Services
{
	public interface ITradeXmlService
	{
		IEnumerable<Order> ParseTradesFromXml(string xmlData);
		string ConvertTradesToXml(IEnumerable<Order> trades);
	}
}
