using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace BlazorNews.Core.Convertors
{
    public static class DateConvertor
    {
        public static string DateToShamsi(this DateTime dateTime)
        {
            PersianCalendar pc = new PersianCalendar();
            string shamsiDate = pc.GetYear(dateTime) + "/" + pc.GetMonth(dateTime).ToString("00") + "/" + pc.GetDayOfMonth(dateTime).ToString("00");
            return shamsiDate;
        }
    }
}
