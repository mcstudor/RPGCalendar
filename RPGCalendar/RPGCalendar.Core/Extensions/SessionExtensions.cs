namespace RPGCalendar.Core.Extensions
{
    using System;
    using System.Runtime.CompilerServices;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;

    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value) where T : class
        {
            session.SetString(key, value as string ?? JsonConvert.SerializeObject(value));
        }

        public static void SetBool(this ISession session, string key, bool value)
        {
            session.SetString(key, value.ToString());
        }

        public static void SetGuid(this ISession session, string key, Guid value)
        {
            session.SetString(key, value.ToString());
        }

        public static T? Get<T>(this ISession session, string key) where T : class
        {
            var value = session.GetString(key);
            if (value is null) return null;
            return typeof(T) == typeof(string)
                ? (T)Convert.ChangeType(value, typeof(T))
                : JsonConvert.DeserializeObject<T>(value);
        }

        public static bool? GetBool(this ISession session, string key)
        {
            var value = session.GetString(key);
            try
            {
                return Boolean.Parse(value);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Guid? GetGuid(this ISession session, string key)
        {
            var value = session.GetString(key);
            try
            {
                return Guid.Parse(value);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
