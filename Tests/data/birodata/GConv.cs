using System;

namespace Tests.data
{
    public static class GConv
    {
        #region // sql - net - string //
        public static string DbToStr(object data)
        {
            return (data == System.DBNull.Value) ? string.Empty : Convert.ToString(data);
        }
        public static string DbToStr(object data, string default_value)
        {
            return (data == System.DBNull.Value) ? default_value : Convert.ToString(data);
        }
        public static string DbToStrNull(object data)
        {
            return (data == System.DBNull.Value) ? null : Convert.ToString(data);
        }
        public static object StrToDb(string data)
        {
            return data;
        }
        public static object StrToDb(string data, string nullval)
        {
            return data == nullval ? System.DBNull.Value : (object)data;
        }
        #endregion
        #region // sql - net - bool //
        public static bool DbToBln(object data)
        {
            return (data == System.DBNull.Value) ? false : Convert.ToBoolean(data);
        }
        public static bool DbToBln(object data, bool default_value)
        {
            return (data == System.DBNull.Value) ? default_value : Convert.ToBoolean(data);
        }
        public static bool? DbToBlnNull(object data)
        {
            return (data == System.DBNull.Value) ? (bool?)null : Convert.ToBoolean(data);
        }
        public static object BlnToDb(bool data)
        {
            return data;
        }
        public static object BlnToDb(bool data, bool nullval)
        {
            return data == nullval ? System.DBNull.Value : (object)data;
        }
        #endregion
        #region // sql - net - short //
        public static short DbToShort(object data)
        {
            return (data == System.DBNull.Value) ? (short)0 : Convert.ToInt16(data);
        }
        public static short DbToShort(object data, short default_value)
        {
            return (data == System.DBNull.Value) ? default_value : Convert.ToInt16(data);
        }
        public static short? DbToShortNull(object data)
        {
            return (data == System.DBNull.Value) ? (short?)null : Convert.ToInt16(data);
        }
        public static object ShortToDb(short data)
        {
            return data;
        }
        public static object ShortToDb(short data, short nullval)
        {
            return data == nullval ? System.DBNull.Value : (object)data;
        }
        public static object ShortToDb(short? data)
        {
            return data;
        }
        public static object ShortToDb(short? data, short nullval)
        {
            return data == nullval ? System.DBNull.Value : (object)data;
        }
        #endregion
        #region // sql - net - int //
        public static int DbToInt(object data)
        {
            return (data == System.DBNull.Value) ? 0 : Convert.ToInt32(data);
        }
        public static int DbToInt(object data, int default_value)
        {
            return (data == System.DBNull.Value) ? default_value : Convert.ToInt32(data);
        }
        public static int? DbToIntNull(object data)
        {
            return (data == System.DBNull.Value) ? (int?)null : Convert.ToInt32(data);
        }
        public static object IntToDb(int data)
        {
            return data;
        }
        public static object IntToDb(int data, int nullval)
        {
            return data == nullval ? System.DBNull.Value : (object)data;
        }
        public static object IntToDb(int? data)
        {
            return data;
        }
        public static object IntToDb(int? data, int nullval)
        {
            return data == nullval ? System.DBNull.Value : (object)data;
        }
        #endregion
        #region // sql - net - long //
        public static long DbToLong(object data)
        {
            return (data == System.DBNull.Value) ? (long)0 : Convert.ToInt64(data);
        }
        public static long DbToLong(object data, long default_value)
        {
            return (data == System.DBNull.Value) ? default_value : Convert.ToInt64(data);
        }
        public static long? DbToLongNull(object data)
        {
            return (data == System.DBNull.Value) ? (long?)null : Convert.ToInt64(data);
        }
        public static object LongToDb(long data)
        {
            return data;
        }
        public static object LongToDb(long data, long nullval)
        {
            return data == nullval ? System.DBNull.Value : (object)data;
        }
        #endregion
        #region // sql - net - float //
        public static float DbToFloat(object data)
        {
            return (data == System.DBNull.Value) ? (float)0 : Convert.ToSingle(data);
        }
        public static float DbToFloat(object data, float default_value)
        {
            return (data == System.DBNull.Value) ? default_value : Convert.ToSingle(data);
        }
        public static float? DbToFloatNull(object data)
        {
            return (data == System.DBNull.Value) ? (float?)null : Convert.ToSingle(data);
        }
        #endregion
        #region // sql - net - double //
        public static double DbToDbl(object data)
        {
            return (data == System.DBNull.Value) ? (double)0 : Convert.ToDouble(data);
        }
        public static double DbToDbl(object data, double default_value)
        {
            return (data == System.DBNull.Value) ? default_value : Convert.ToDouble(data);
        }
        public static double? DbToDblNull(object data)
        {
            return (data == System.DBNull.Value) ? (double?)null : Convert.ToDouble(data);
        }
        #endregion
        #region // sql - net - decimal //
        public static decimal DbToDec(object data)
        {
            return (data == System.DBNull.Value) ? (decimal)0 : Convert.ToDecimal(data);
        }
        public static decimal DbToDec(object data, decimal default_value)
        {
            return (data == System.DBNull.Value) ? default_value : Convert.ToDecimal(data);
        }
        public static decimal? DbToDecNull(object data)
        {
            return (data == System.DBNull.Value) ? (decimal?)null : Convert.ToDecimal(data);
        }
        public static object DecToDb(decimal data)
        {
            return data;
        }
        public static object DecToDb(decimal data, decimal nullval)
        {
            return data == nullval ? System.DBNull.Value : (object)data;
        }
        #endregion
        #region // sql - net - datetime //
        public static DateTime DbToDt(object data)
        {
            return (data == System.DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(data);
        }
        public static DateTime DbToDt(object data, DateTime default_value)
        {
            return (data == System.DBNull.Value) ? default_value : Convert.ToDateTime(data);
        }
        public static DateTime? DbToDtNull(object data)
        {
            return (data == System.DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(data);
        }
        public static object DtToDb(DateTime data)
        {
            return data;
        }
        public static object DtToDb(DateTime data, DateTime nullval)
        {
            return data == nullval ? System.DBNull.Value : (object)data;
        }
        #endregion
        #region // sql - net - guid //
        public static Guid DbToGid(object data)
        {
            return (data == System.DBNull.Value) ? Guid.Empty : (Guid)data;
        }
        public static Guid DbToGid(object data, Guid default_value)
        {
            return (data == System.DBNull.Value) ? default_value : (Guid)data;
        }
        public static Guid? DbToGidNull(object data)
        {
            return (data == System.DBNull.Value) ? (Guid?)null : (Guid)data;
        }
        public static object GidToDb(Guid data)
        {
            return data;
        }
        public static object GidToDb(Guid data, Guid nullval)
        {
            return data == nullval ? System.DBNull.Value : (object)data;
        }
        #endregion
        #region // sql - net - timestamp //
        public static ulong DbTsToLong(object data)
        {
            if (data != System.DBNull.Value)
            {
                byte[] byteData = (byte[])data;
                Array.Reverse(byteData);
                return BitConverter.ToUInt64(byteData, 0);
            }
            else
            {
                return 0;
            }

        }
        #endregion
    }
}
