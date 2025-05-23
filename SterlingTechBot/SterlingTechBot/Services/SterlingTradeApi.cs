using SterlingLib;
using SterlingTechBot.Models;
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
		private readonly STIApp _STIApplicaltion;
		private readonly STIEvents _STIEvents;

		public SterlingTradeApi(STIApp STIApplicaltion, STIEvents STIEvents)
		{
			_STIApplicaltion = STIApplicaltion
									?? throw new ArgumentNullException(nameof(STIApplicaltion));

			_STIApplicaltion.SetModeXML(true);

			_STIEvents	= STIEvents
									?? throw new ArgumentNullException(nameof(STIEvents));

			//_STIEvents.OnSTIOrderUpdateXML += new _ISTIEventsEvents_OnSTIOrderUpdateXMLEventHandler(OnSTIOrderUpdateXML);
		}

		private void OnSTIOrderUpdateXML(ref string bstrOrder)
		{
		}

		public Task<bool> CopyOrdes(string targetAccountId, IEnumerable<structSTIOrderUpdate> orders)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<structSTIOrderUpdate>> GetOrders(string accountId)
		{
			// Асинхронный вызов без блокировки UI
			return Task.Run(() =>
			{
				// 1. Инициализация объекта для работы с ордерами
				STIOrderMaint orderMaint = new STIOrderMaint();

				// 2. Создание фильтра
				structSTIOrderFilter filter = new structSTIOrderFilter
				{
					bstrAccount = accountId,
					bOpenOnly = 1,		// false = все ордера (включая исторические)
					bstrSymbol = "",    // Пусто = все символы
					bstrInstrument = "" // Пусто = все типы инструментов
				};

				// 3. Подготовка переменных для результатов
				Array? orderArray = null;

				// 4. Запрос ордеров
				int result = orderMaint.GetOrderListEx(ref filter, ref orderArray);

				// 5. Обработка результатов
				if (result == 0)
				{
					var returnedOrders = (structSTIOrderUpdate[])orderArray;
					return returnedOrders.AsEnumerable();
				}

				return Enumerable.Empty<structSTIOrderUpdate>();
			});
		}


	}
}
