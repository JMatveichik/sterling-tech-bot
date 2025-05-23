using SterlingTechBot.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace SterlingTechBot.Services
{
	class TradeXmlService : ITradeXmlService
	{
		public string ConvertTradesToXml(IEnumerable<Order> trades)
		{
			if (trades == null || !trades.Any())
			{
				return string.Empty;
			}

			var serializer = new XmlSerializer(typeof(List<Order>));
			var settings = new XmlWriterSettings
			{
				Indent = true,
				OmitXmlDeclaration = false // Можно изменить на true, если не нужна декларация <?xml?>
			};

			using (var stringWriter = new StringWriter())
			using (var xmlWriter = XmlWriter.Create(stringWriter, settings))
			{
				serializer.Serialize(xmlWriter, trades.ToList());
				return stringWriter.ToString();
			}
		}

		public IEnumerable<Order> ParseTradesFromXml(string xmlData)
		{
			if (string.IsNullOrWhiteSpace(xmlData))
			{
				return Enumerable.Empty<Order>();
			}

			var serializer = new XmlSerializer(typeof(List<Order>));

			using (var stringReader = new StringReader(xmlData))
			using (var xmlReader = XmlReader.Create(stringReader))
			{
				try
				{
					var result = serializer.Deserialize(xmlReader) as List<Order>;
					return result ?? Enumerable.Empty<Order>();
				}
				catch (Exception ex)
				{
					// Логирование ошибки (например, через ILogger)
					Console.WriteLine($"Ошибка парсинга XML: {ex.Message}");
					return Enumerable.Empty<Order>();
				}
			}
		}
	}
}
