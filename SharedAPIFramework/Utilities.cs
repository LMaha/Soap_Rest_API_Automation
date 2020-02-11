using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedAPIFramework
{
	public class Utilities
	{
		public Utilities()
		{

		}
		public DateTime GetNextWeekday()
		{
			DateTime date = DateTime.Today.AddDays(1);
			if (date.DayOfWeek == DayOfWeek.Saturday)
			{
				date = date.AddDays(2);
			}
			else if (date.DayOfWeek == DayOfWeek.Sunday) 
			{
				date = date.AddDays(1);
			}
			return date;
		}

		public DateTime GetNextWeekend()
		{
			DateTime date = DateTime.Today.AddDays(1);
			while (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
			{
				date = date.AddDays(1);
			}
			return date;
		}

		public DateTime GetNextLaborDay() 
		{
			return GetNextDayOfWeekFromDate(9, 1, DayOfWeek.Monday, 1);
		}

		public DateTime GetNextMemorialDay()
		{
			return GetNextDayOfWeekFromDate(5, 31, DayOfWeek.Monday, -1);
		}
		public DateTime GetNextThanksgivingDay()
		{
			return GetNextDayOfWeekFromDate(11, 30, DayOfWeek.Thursday, -1);
		}

		public DateTime GetNextDayOfWeekFromDate(int month, int day, DayOfWeek dow, int AddSubDay)
		{
			int year = DateTime.Today.Year;
			string dt = year + "-" + month.ToString("D2") + "-" + day.ToString("D2");
			DateTime date = DateTime.ParseExact(dt, "yyyy-MM-dd", CultureInfo.InvariantCulture);
			while (date.DayOfWeek != dow)
			{
				date = date.AddDays(AddSubDay);
			}
			if (DateTime.Compare(DateTime.Today, date) >= 0)
			{
				year++;

				dt = year + "-" + month.ToString("D2") + "-" + day.ToString("D2");
				date = DateTime.ParseExact(dt, "yyyy-MM-dd", CultureInfo.InvariantCulture);
				while (date.DayOfWeek != dow)
				{
					date = date.AddDays(AddSubDay);
				}
			}
			return date;
		}

		public string GetNextDay(int month, int day)
		{
			int year = DateTime.Today.Year;
			string dt = year + "-" + month.ToString("D2") + "-" + day.ToString("D2");
			DateTime date = DateTime.ParseExact(dt, "yyyy-MM-dd", CultureInfo.InvariantCulture);
			// If date has already passed, increment to next year
			if (DateTime.Compare(DateTime.Today, date) >= 0)
			{
				year++;
				dt = year + "-" + month.ToString("D2") + "-" + day.ToString("D2");
			}
			return dt;
		}

		public string GetRandomDay()
		{
			Random rand = new Random();
			// Get random date within next year
			string date = DateTime.Today.AddDays(rand.Next(1, 366)).ToString("yyyy-MM-dd");

			return date;
		}
	}
}
