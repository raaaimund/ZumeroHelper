﻿using System;

namespace ZumeroHelper.Structs
{
    public struct ZumeroDecimal : IZumeroStruct<long>, IComparable<ZumeroDecimal>
    {
        public static long Scale = (long)Math.Pow(10, 6);

        #region Properties

        public decimal DecimalValue
        {
            get { return _decimalValue; }
            set
            {
                _decimalValue = value;
                _value = Encode(value);
            }
        }

        #endregion

        #region Fields

        decimal _decimalValue;
        long _value;

        #endregion

        #region Constructors

        public ZumeroDecimal(long value)
        {
            _value = value;
            _decimalValue = Decode(value);
        }

        public ZumeroDecimal(decimal decimalValue)
        {
            _value = Encode(decimalValue);
            _decimalValue = decimalValue;
        }

        #endregion

        #region Encode 

        public static long Encode(decimal decimalValue)
        {
            return (long) Math.Floor((double) (decimalValue*(decimal) Scale));
        }

        #endregion

        #region Decode

        public static decimal Decode(long value)
        {
            return (decimal) value / (decimal)Scale;
        }

        #endregion

        #region Operators

        public static bool operator ==(ZumeroDecimal x, ZumeroDecimal y)
        {
            return x._decimalValue == y._decimalValue;
        }

        public static bool operator !=(ZumeroDecimal x, ZumeroDecimal y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Implicitly converts the ZumeroDecimal to it's long equivilent
        /// </summary>
        /// <param name="zumeroDecimal"></param>
        /// <returns></returns>
        public static implicit operator long (ZumeroDecimal zumeroDecimal)
        {
            return zumeroDecimal._value;
        }

        /// <summary>
        /// Implicitly converts the ZumeroDecimal to it's decimal equivilent
        /// </summary>
        /// <param name="zumeroDecimal"></param>
        /// <returns></returns>
        public static implicit operator decimal(ZumeroDecimal zumeroDecimal)
        {
            return zumeroDecimal._decimalValue;
        }

        /// <summary>
        /// Implicitly converts the long to a ZumeroDecimal
        /// </summary>
        /// <param name="longValue"></param>
        /// <returns></returns>
        public static implicit operator ZumeroDecimal(long longValue)
        {
            return new ZumeroDecimal(longValue);
        }

        /// <summary>
        /// Implicitly converts the decimal to a ZumeroDecimal
        /// </summary>
        /// <param name="decimalValue"></param>
        /// <returns></returns>
        public static implicit operator ZumeroDecimal(decimal decimalValue)
        {
            return new ZumeroDecimal(decimalValue);
        }

        #endregion

        #region Overrides

        public override bool Equals(object obj)
        {
            if (obj is ZumeroDecimal)
                return _decimalValue.Equals(((ZumeroDecimal)obj)._decimalValue);
            if (obj is decimal)
                return _decimalValue.Equals((decimal)obj);
            return false;
        }

        public override int GetHashCode()
        {
            return _decimalValue.GetHashCode();
        }

        public override string ToString()
        {
            return _decimalValue.ToString();
        }

        #endregion

        #region ISerializable

        public long Serialize()
        {
            return _value;
        }

        #endregion

        #region IConvertible

        // SQLite needs the IConvertible interface for using ZumeroDecimal in a 
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

        public int CompareTo(ZumeroDecimal other)
        {
            return _decimalValue.CompareTo(other._decimalValue);
        }

        #endregion IComparable
    }
}