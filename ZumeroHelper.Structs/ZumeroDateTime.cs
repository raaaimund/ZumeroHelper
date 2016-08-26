using System;

namespace ZumeroHelper.Structs
{
    public struct ZumeroDateTime : IZumeroStruct<string>, IComparable<ZumeroDateTime>
    {
        public const string Format = "yyyy-MM-dd HH:mm:ss.fff";

        #region Properties

        public DateTime DateTimeValue
        {
            get { return _dateTimeValue; }
            set
            {
                _dateTimeValue = value;
                _value = Encode(value);
            }
        }

        #endregion

        #region Fields

        DateTime _dateTimeValue;
        string _value;

        #endregion

        #region Constructors

        public ZumeroDateTime(string value)
        {
            _value = value;
            _dateTimeValue = Decode(value);
        }

        public ZumeroDateTime(DateTime dateTimeValue)
        {
            _value = Encode(dateTimeValue);
            _dateTimeValue = dateTimeValue;
        }

        #endregion

        #region Encode 

        public static string Encode(DateTime dateTime)
        {
            return dateTime.ToString(Format);
        }

        #endregion

        #region Decode

        public static DateTime Decode(string value)
        {
            return DateTime.Parse(value);
        }

        #endregion

        #region Operators

        public static bool operator >(ZumeroDateTime x, DateTime y)
        {
            return x._dateTimeValue > y;
        }

        public static bool operator <(ZumeroDateTime x, DateTime y)
        {
            return x._dateTimeValue < y;
        }

        public static bool operator >(ZumeroDateTime x, ZumeroDateTime y)
        {
            return x._dateTimeValue > y._dateTimeValue;
        }

        public static bool operator <(ZumeroDateTime x, ZumeroDateTime y)
        {
            return x._dateTimeValue < y._dateTimeValue;
        }

        public static bool operator ==(ZumeroDateTime x, DateTime y)
        {
            return x._dateTimeValue == y;
        }

        public static bool operator !=(ZumeroDateTime x, DateTime y)
        {
            return !(x == y);
        }

        public static bool operator ==(ZumeroDateTime x, ZumeroDateTime y)
        {
            return x._dateTimeValue == y._dateTimeValue;
        }

        public static bool operator !=(ZumeroDateTime x, ZumeroDateTime y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Implicitly converts the ZumeroGuid to it's DateTime equivilent
        /// </summary>
        /// <param name="zumeroDateTime"></param>
        /// <returns></returns>
        public static implicit operator DateTime(ZumeroDateTime zumeroDateTime)
        {
            return zumeroDateTime._dateTimeValue;
        }

        /// <summary>
        /// Implicitly converts the Guid to a ZumeroGuid
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static implicit operator ZumeroDateTime(DateTime dateTime)
        {
            return new ZumeroDateTime(dateTime);
        }

        #endregion

        #region Overrides

        public override bool Equals(object obj)
        {
            if (obj is ZumeroDateTime)
                return _dateTimeValue.Equals(((ZumeroDateTime)obj)._dateTimeValue);
            if (obj is DateTime)
                return _dateTimeValue.Equals((DateTime)obj);
            return false;
        }

        public override int GetHashCode()
        {
            return _dateTimeValue.GetHashCode();
        }

        public override string ToString()
        {
            return _dateTimeValue.ToString(Format);
        }

        #endregion

        #region ISerializable

        public string Serialize()
        {
            return _value;
        }

        #endregion

        #region IConvertible

        // SQLite needs the IConvertible interface for using ZumeroGuid in a 
        // where clause. We dont have to implement the methods for IConvertible.

        public TypeCode GetTypeCode()
        {
            throw new NotImplementedException();
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public char ToChar(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public byte ToByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public short ToInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public int ToInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public long ToInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public float ToSingle(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public double ToDouble(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public string ToString(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IComparable

        public int CompareTo(ZumeroDateTime other)
        {
            return _dateTimeValue.CompareTo(other._dateTimeValue);
        }

        #endregion IComparable
    }
}