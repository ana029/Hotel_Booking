﻿namespace HotelBookingAPI
{
    public static class HelperService
    {
        public static string GetFullMessage(this Exception ex)
        {
            if (ex == null)
                return string.Empty;

            var messages = new List<string>();

            while (ex != null)
            {
                messages.Add(ex.Message);

                ex = ex.InnerException;
            }

            return string.Join("=>", messages);
        }
    }
}
