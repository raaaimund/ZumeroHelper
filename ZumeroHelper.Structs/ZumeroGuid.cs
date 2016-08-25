using System;

namespace ZumeroHelper.Structs
{
    public struct ZumeroGuid : IZumeroStruct<byte[]>
    {
        #region Properties

        public Guid Guid
        {
            get { return _guid; }
            set
            {
                _guid = value;
                _value = Encode(value);
            }
        }

        #endregion

        #region Fields

        Guid _guid;
        byte[] _value;

        #endregion

        #region Constructors

        public ZumeroGuid(byte[] value)
        {
            _value = value;
            _guid = Decode(value);
        }

        public ZumeroGuid(Guid guid)
        {
            _value = Encode(guid);
            _guid = guid;
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
            return x == y._guid;
        }

        public static bool operator !=(Guid x, ZumeroGuid y)
        {
            return !(x == y._guid);
        }

        public static bool operator ==(ZumeroGuid x, ZumeroGuid y)
        {
            return x._guid == y._guid;
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
            return zumeroGuid._guid;
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
                return _guid.Equals(((ZumeroGuid)obj)._guid);
            if (obj is Guid)
                return _guid.Equals((Guid)obj);
            if (obj is string)
                return _guid.ToString().Equals(obj.ToString());
            return false;
        }

        public override int GetHashCode()
        {
            return _guid.GetHashCode();
        }

        public override string ToString()
        {
            return _guid.ToString();
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
    }
}