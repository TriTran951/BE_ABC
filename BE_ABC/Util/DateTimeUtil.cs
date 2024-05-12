namespace BE_ABC.Util
{
    public static class DateTimeExtensions
    {
        // Chuyển đổi từ DateTime sang Unix time
        public static int ToUnixTime(this DateTime dateTime)
        {
            return (int)(dateTime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }

        // Chuyển đổi từ Unix time sang DateTime
        public static DateTime FromUnixTime(int unixTime)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTime).ToLocalTime();
        }
        public static int getUxixTimeNow()
        {
            return (int)DateTimeExtensions.ToUnixTime(DateTime.UtcNow);
        }
    }
}
