// ReSharper disable once CheckNamespace
namespace MxNet.IO
{

    /// <summary>
    /// Default object for holding a mini-batch of data and related information. This class cannot be inherited.
    /// </summary>
    public sealed class DataBatch
    {

        #region Properties

        public NDArrayList Data
        {
            get;
            internal set;
        }

        public int[] Index
        {
            get;
            internal set;
        }

        public NDArrayList Label
        {
            get;
            internal set;
        }

        public int? Pad
        {
            get;
            internal set;
        }

        public DataDesc[] ProvideData
        {
            get;
            internal set;
        }

        public DataDesc[] ProvideLabel
        {
            get;
            internal set;
        }

        public int? BucketKey
        {
            get;
            internal set;
        }

        #endregion

        public DataBatch(NDArrayList data, NDArrayList label = null, int? pad= null, int[] index= null,
                        int? bucket_key= null, DataDesc[] provide_data= null, DataDesc[] provide_label = null)
        {
            Data = data;
            Label = label;
            Pad = pad;
            Index = index;
            BucketKey = bucket_key;
            ProvideData = provide_data;
            ProvideLabel = provide_label;
        }

        public DataBatch Shallowcopy()
        {
            return (DataBatch)this.MemberwiseClone();
        }
    }

}