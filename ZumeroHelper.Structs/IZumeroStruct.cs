using System;
using SQLite.Net;

namespace ZumeroHelper.Structs
{
    public interface IZumeroStruct<TBackground> : ISerializable<TBackground>, IConvertible
    {
        #region Overrides

        bool Equals(object obj);

        int GetHashCode();

        string ToString();

        #endregion
    }
}