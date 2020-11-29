using System;
namespace WebStockManager.Model
{
	/// <summary>StockCalendar表实体类
	/// 作者:alonso(line id: menshin7)
	/// 创建时间:2020-11-29 14:47:42
	/// </summary>
	[Serializable]
	public partial class StockCalendar
	{
		public StockCalendar()
		{}
		private int _Id ;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _Id=value;}
			get{return _Id;}
		}
		private string _chYear ;
		/// <summary>
		/// 
		/// </summary>
		public string chYear
		{
			set{ _chYear=value;}
			get{return _chYear;}
		}
		private string _ReSetDate ;
		/// <summary>
		/// 
		/// </summary>
		public string ReSetDate
		{
			set{ _ReSetDate=value;}
			get{return _ReSetDate;}
		}
	}
}
