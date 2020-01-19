// ReSharper disable once CheckNamespace
namespace MxNet
{

    public sealed class Context
    {

        #region Fields

        private readonly DeviceType _Type;

        private readonly int _Id;

        #endregion

        #region Constructors

        public Context(DeviceType type, int id)
        {
            this._Type = type;
            this._Id = id;
        }

        #endregion

        #region Methods

        public static Context Cpu(int deviceId = 0)
        {
            return new Context(DeviceType.CPU, deviceId);
        }

        public static Context Gpu(int deviceId = 0)
        {
            return new Context(DeviceType.GPU, deviceId);
        }

        public int GetDeviceId()
        {
            return this._Id;
        }

        public DeviceType GetDeviceType()
        {
            return this._Type;
        }

        #endregion

        public override string ToString()
        {
            if(GetDeviceType() == DeviceType.GPU)
            {
                return string.Format("GPU: {0}", GetDeviceId());
            }
            else
            {
                return string.Format("CPU: {0}", GetDeviceId());
            }
        }

    }

}
