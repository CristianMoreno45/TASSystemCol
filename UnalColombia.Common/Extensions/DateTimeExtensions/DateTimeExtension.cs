namespace UnalColombia.Common.Extensions.DateTimeExtensions
{

    public static class DateTimeExtension
    {

        public static DateTime GetDateTimeFromUnix(this long epochMilliseconds)
        {
            DateTimeOffset datatime = DateTimeOffset.FromUnixTimeMilliseconds(epochMilliseconds);
            return datatime.DateTime;
        }


        public static long ToUnixTime(this DateTime date)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64((date - epoch).TotalMilliseconds);
        }

        public static DateTime ToUTC(this DateTime date)
        {
            var datatime = date.AddHours(date.Hour * -1);
            return datatime;
        }

    }

}
