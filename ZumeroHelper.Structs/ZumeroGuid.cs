using System;

namespace ZumeroHelper.Structs
{
    public struct ZumeroGuid : IZumeroStruct<byte[]>, IComparable<ZumeroGuid>
    {
        #region Properties

        public Guid GuidValue
        {
            get { return _guidValue; }
            set
            {
                _guidValue = value;
                _value = Encode(value);
            }
        }

        #endregion

        #region Fields

        Guid _guidValue;
        byte[] _value;

        #endregion

        #region Constructors

        public ZumeroGuid(byte[] value)
        {
            _value = value;
            _guidValue = Decode(value);
        }

        public ZumeroGuid(Guid guidValue)
        {
            _value = Encode(guidValue);
            _guidValue = guidValue;
        }

        #endregion

        #region Encode 

        public static byte[] Encode(Guid guid)
        {
            return guid.ToByteArray();
        }

        #endregion

        #region Decode

        public static Guid Decode(byte[] value)
        {
            return new Guid(value);
        }

        #endregion

        #region Operators

        public static bool operator ==(Guid x, ZumeroGuid y)
        {
            return x == y._guidValue;
        }

        public static bool operator !=(Guid x, ZumeroGuid y)
        {
            return !(x == y._guidValue);
        }

        public static bool operator ==(ZumeroGuid x, ZumeroGuid y)
        {
            return x._guidValue == y._guidValue;
        }

        public static bool operator !=(ZumeroGuid x, ZumeroGuid y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Implicitly converts the ZumeroGuid to it's byte array equivilent
        /// </summary>
        /// <param name="zumeroGuid"></param>
        /// <returns></returns>
        public static implicit operator byte[] (ZumeroGuid zumeroGuid)
        {
            return zumeroGuid._value;
        }

        /// <summary>
        /// Implicitly converts the ZumeroGuid to it's Guid equivilent
        /// </summary>
        /// <param name="zumeroGuid"></param>
        /// <returns></returns>
        public static implicit operator Guid(ZumeroGuid zumeroGuid)
        {
            return zumeroGuid._guidValue;
        }

        /// <summary>
        /// Implicitly converts the byte array to a ZumeroGuid
        /// </summary>
        /// <param name="zumeroGuidAsBytes"></param>
        /// <returns></returns>
        public static implicit operator ZumeroGuid(byte[] zumeroGuidAsBytes)
        {
            return new ZumeroGuid(zumeroGuidAsBytes);
        }

        /// <summary>
        /// Implicitly converts the Guid to a ZumeroGuid
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static implicit operator ZumeroGuid(Guid guid)
        {
            return new ZumeroGuid(guid);
        }

        #endregion

        #region Overrides

        public override bool Equals(object obj)
        {
            if (obj is ZumeroGuid)
                return _guidValue.Equals(((ZumeroGuid)obj)._guidValue);
            if (obj is Guid)
                return _guidValue.Equals((Guid)obj);
            if (obj is string)
                return _guidValue.ToString().Equals(obj.ToString());
            return false;
        }

        public override int GetHashCode()
        {
            return _guidValue.GetHashCode();
        }

        public override string ToString()
        {
            return _guidValue.ToString();
        }

        #endregion

        #region ISerializable

        public byte[] Serialize()
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

        public int CompareTo(ZumeroGuid other)
        {
            return _guidValue.CompareTo(other._guidValue);
        }

        #endregion IComparable
    }
}