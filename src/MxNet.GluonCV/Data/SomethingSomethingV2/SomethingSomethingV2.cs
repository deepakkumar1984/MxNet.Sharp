using MxNet.Gluon.Data;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MxNet.GluonCV.Data
{
    public class SomethingSomethingV2 : Dataset<(NDArray, NDArray)>
    {
        public SomethingSomethingV2(string root= "/mxnet/datasets/somethingsomethingv2/20bn-something-something-v2-frames",
                                     string setting= "~/.mxnet/datasets/somethingsomethingv2/train_videofolder.txt",
                                     bool train= true,
                                     bool test_mode= false,
                                     string name_pattern= "%06d.jpg",
                                     string video_ext= "mp4",
                                     bool is_color= true,
                                     string modality= "rgb",
                                     int num_segments= 1,
                                     int new_length= 1,
                                     int new_step= 1,
                                     int new_width= 340,
                                     int new_height= 256,
                                     int target_width= 224,
                                     int target_height= 224,
                                     bool temporal_jitter= false,
                                     bool video_loader= false,
                                     bool use_decord= false,
                                     Func<NDArray, NDArray, (NDArray, NDArray)> transform= null)
        {
            throw new NotImplementedException();
        }

        public override (NDArray, NDArray) this[int idx] => throw new NotImplementedException();

        public override int Length => throw new NotImplementedException();

        private List<(string, int, int)> MakeDataset(string directory, string setting) => throw new NotImplementedException();

        private (int, int) SampleTrainIndices(int num_frames) => throw new NotImplementedException();

        private (int, int) SampleValIndices(int num_frames) => throw new NotImplementedException();

        private (int, int) SampleTestIndices(int num_frames) => throw new NotImplementedException();

        private Mat[] ImageTSNCv2Loader(string directory, int duration, int[] indices, int skip_offsets) => throw new NotImplementedException();

        private Mat[] VideoTSNMMCvLoader(string directory, StreamReader video_reader, int duration, int[] indices, int skip_offsets) => throw new NotImplementedException();

        private Mat[] VideoTSNDecordLoader(string directory, StreamReader video_reader, int duration, int[] indices, int skip_offsets) => throw new NotImplementedException();

        private Mat[] VideoTSNDecordBatchLoader(string directory, StreamReader video_reader, int duration, int[] indices, int skip_offsets) => throw new NotImplementedException();
    }
}
