using FireSharp.Interfaces;

namespace WebVaanoli.Data.Interfaces
{
    public interface IVaanoliDataContext
    {
        IFirebaseClient Genres { get; }
        IFirebaseClient Radios { get; }
        IFirebaseClient StreamQualities { get; }
    }
}