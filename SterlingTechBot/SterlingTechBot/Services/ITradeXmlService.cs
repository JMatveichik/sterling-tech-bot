using SterlingTechBot.Models;
using System.Collections.Generic;


namespace SterlingTechBot.Services
{
	public interface ITradeXmlService
	{
		IEnumerable<Trade> ParseTradesFromXml(string xmlData);
		string ConvertTradesToXml(IEnumerable<Trade> trades);
	}
}
