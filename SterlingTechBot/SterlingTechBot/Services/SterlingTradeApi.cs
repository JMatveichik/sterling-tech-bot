using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SterlingTechBot.Services
{
	public class SterlingTradeApi : ISterlingTradeApi
	{
		public Task<bool> CopyTrades(string targetAccountId, string xmlToSend)
		{
			return Task.Run(() =>
			{
				// Здесь может быть работа с ActiveX или HTTP-запросами
				return true;
			});
		}

		public Task<string> GetTrades(string accountId)
		{
			// Асинхронный вызов без блокировки UI
			return Task.Run(() =>
			{
				// Пример XML-данных (в реальности - вызов API)
				return @$"<?xml version='1.0' encoding='UTF-8'?>
						 <ArrayOfTrade>
                          <Trade>
                            <Id>123</Id>
                            <AccountId>{accountId}</AccountId>
                            <Amount>100.50</Amount>
                            <Timestamp>2023-12-01T10:00:00</Timestamp>
                          </Trade>
						<Trade>
                            <Id>234</Id>
                            <AccountId>{accountId}</AccountId>
                            <Amount>1050.50</Amount>
                            <Timestamp>2023-12-01T10:00:00</Timestamp>
                          </Trade>
						<Trade>
                            <Id>568</Id>
                            <AccountId>{accountId}</AccountId>
                            <Amount>220.50</Amount>
                            <Timestamp>2023-12-01T10:00:00</Timestamp>
                          </Trade>
                        </ArrayOfTrade>";
			});
		}
	}
}
