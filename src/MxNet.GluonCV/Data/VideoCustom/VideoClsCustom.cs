using MxNet.Gluon.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MxNet.GluonCV.Data.Ucf101
{
    public class VideoClsCustom : Dataset<(NDArray, NDArray)>
    {
        public VideoClsCustom(string root,
                 string setting,
                 bool train = true,
                 bool test_mode = false,
                 string name_pattern = "img_%05d.jpg",
                 string video_ext = "mp4",
                 bool is_color = true,
                 string modality = "rgb",
                 int num_segments = 1,
                 int num_crop = 1,
                 int new_length = 1,
                 int new_step = 1,
                 int new_width = 340,
                 int new_height = 256,
                 int target_width = 224,
                 int target_height = 224,
                 bool temporal_jitter = false,
                 bool video_loader = false,
                 bool use_decord = false,
                 bool slowfast= false,
                 int slow_temporal_stride= 16,
                 int fast_temporal_stride= 2,
                 Func<NDArray, NDArray, (NDArray, NDArray)> transform = null) : base()
        {
            throw new NotImplementedException();
        }

        public override (NDArray, NDArray) this[int idx] => throw new NotImplementedException();

        public override int Length => throw new NotImplementedException();

        private (string[], Dictionary<string, int>) FindClasses(string directory)
        {
            throw new NotImplementedException();
        }

        private List<(string, int, int)> MakeDataset(string directory, string setting)
        {
            throw new NotImplementedException();
        }

        private (int, int) SampleTrainIndices(int num_frames) => throw new NotImplementedException();

        private (int, int) SampleValIndices(int num_frames) => throw new NotImplementedException();

        private (int, int) SampleTestIndices(int num_frames) => throw new NotImplementedException();

        private NDArrayList ImageTSNCv2Loader(string directory, int duration, NDArray indices, int skip_offsets) => throw new NotImplementedException();

        private NDArrayList ImageSlowfastCv2Loader(string directory, int duration, NDArray indices, int skip_offsets) => throw new NotImplementedException();

        private NDArrayList VideoTSNMmcvLoader(string directory, FileStream video_reader, int duration, NDArray indices, int skip_offsets) => throw new NotImplementedException();

        private NDArrayList VideoTSNDecordLoader(string directory, FileStream video_reader, int duration, NDArray indices, int skip_offsets) => throw new NotImplementedException();

        private NDArrayList VideoTSNDecordBatchLoader(string directory, FileStream video_reader, int duration, NDArray indices, int skip_offsets) => throw new NotImplementedException();

        private NDArrayList VideoTSNDecordSlowfastLoader(string directory, FileStream video_reader, int duration, NDArray indices, int skip_offsets) => throw new NotImplementedException();
    }
}
