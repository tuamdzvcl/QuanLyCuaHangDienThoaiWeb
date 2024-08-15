
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Web2_Ver2
{
    public class Date
    {
        public static string GetCurrentDateTimeString()
        {

            // Đặt múi giờ cho Việt Nam
            TimeZoneInfo vietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

            // Lấy thời gian hiện tại theo múi giờ của Việt Nam
            DateTime currentVietnamDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, vietnamTimeZone);

            // Lấy giờ và phút
            int hour = currentVietnamDateTime.Hour;
            int minute = currentVietnamDateTime.Minute;

            // Lấy ngày, tháng và năm
            int day = currentVietnamDateTime.Day;
            int month = currentVietnamDateTime.Month;
            int year = currentVietnamDateTime.Year;

            // Chuyển thành chuỗi
            string hourMinute = $"{hour:D2}:{minute:D2}";
            string dayMonthYear = $"{day:D2}/{month:D2}/{year%100}";

            // Kết hợp thành chuỗi cuối cùng
            string datenow = $"{hourMinute}-{dayMonthYear}";

            // Trả về kết quả
            return datenow;
        }

        public static string GetDateNow()
        {
            // Đặt múi giờ cho Việt Nam
            TimeZoneInfo vietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

            // Lấy thời gian hiện tại theo múi giờ của Việt Nam
            DateTime currentVietnamDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, vietnamTimeZone);

            // Lấy ngày, tháng và năm
            int day = currentVietnamDateTime.Day;
            int month = currentVietnamDateTime.Month;
            int year = currentVietnamDateTime.Year;

            // Lấy thứ trong tuần
            DayOfWeek dayOfWeek = currentVietnamDateTime.DayOfWeek;

            // Tạo bảng tra cứu
            Dictionary<DayOfWeek, string> dayOfWeekMap = new Dictionary<DayOfWeek, string>()
                {
                    {DayOfWeek.Monday, "Thứ hai"},
                    {DayOfWeek.Tuesday, "Thứ ba"},
                    {DayOfWeek.Wednesday, "Thứ tư"},
                    {DayOfWeek.Thursday, "Thứ năm"},
                    {DayOfWeek.Friday, "Thứ sáu"},
                    {DayOfWeek.Saturday, "Thứ bảy"},
                    {DayOfWeek.Sunday, "Chủ nhật"}
                };

            // Chuyển thứ trong tuần sang tiếng Việt
            string dayOfWeekStr = dayOfWeekMap[dayOfWeek];

            // Chuyển thành chuỗi
            string dateNow = $"{dayOfWeekStr}-{day:D2}/{month:D2}/{year}";

            // Trả về kết quả
            return dateNow;
        }

        public static DateTime DateSapXep()
        {
            TimeZoneInfo vietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

            // Lấy thời gian hiện tại theo múi giờ của Việt Nam
            DateTime currentVietnamDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, vietnamTimeZone);

            int day = currentVietnamDateTime.Day;
            int month = currentVietnamDateTime.Month;
            int year = currentVietnamDateTime.Year;

            DateTime date = new DateTime(year, month, day);
            return date;

        }

    }
}