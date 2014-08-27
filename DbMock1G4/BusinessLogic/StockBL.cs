using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using DbMock1G4.BusinessObjects;
using DbMock1G4.DataAccess;

namespace DbMock1G4.BusinessLogic
{
	public class StockBL
	{

		#region ***** Init Methods ***** 
		StockDA objStockDA;
		public StockBL()
		{
			objStockDA = new StockDA();
		}
		#endregion

		#region ***** Get Methods ***** 
		public Stock GetByStockId(int stockid)
		{
			return objStockDA.GetByStockId(stockid);
		}

		public List<Stock> GetList()
		{
			const string cacheName = "lstStock";
			if( ServerCache.Get(cacheName) == null )
			{
				ServerCache.Insert(cacheName, objStockDA.GetList(), "Stock");
			}
			return (List<Stock>) ServerCache.Get(cacheName);
		}

	
		public List<Stock> GetListPaged(int recperpage, int pageindex)
		{
			return objStockDA.GetListPaged(recperpage, pageindex);
		}

		#endregion

		#region ***** Add Update Delete Methods ***** 
		
		public int Add(Stock objStock)
		{
			ServerCache.Remove("Stock", true);
			return objStockDA.Add(objStock);
		}

	
		public void Update(Stock objStock)
		{
			ServerCache.Remove("Stock", true);
			objStockDA.Update(objStock);
		}

	
		public void Delete(int stockid)
		{
			ServerCache.Remove("Stock", true);
			objStockDA.Delete(stockid);
		}
		#endregion
	}
}
