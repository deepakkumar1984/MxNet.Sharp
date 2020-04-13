using MxNet.Gluon.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Linq;
using OpenCvSharp;

namespace MxNet.GluonCV.Data
{
    public class Kinetics400 : Dataset<(NDArray, int)>
    {
        public string Root { get; }
        public string Setting { get; }
        public bool Train { get; }
        public bool TestMode { get; }
        public string NamePattern { get; }
        public string VideoExt { get; }
        public bool IsColor { get; }
        public string Modality { get; }
        public int NumSegments { get; }
        public int NumCrop { get; }
        public int NewLength { get; }
        public int NewStep { get; }
        public int NewWidth { get; }
        public int NewHeight { get; }
        public int TargetWidth { get; }
        public int TargetHeight { get; }
        public bool TemporalJitter { get; }
        public bool VideoLoader { get; }
        public bool UseDecord { get; }
        public bool Slowfast { get; }
        public int SlowTemporalStride { get; }
        public int FastTemporalStride { get; }
        public int SkipLength { get; }
        public string[] Classes { get; }
        public Dictionary<string, int> ClassToIdx { get; }
        public List<(string, int, int)> Clips { get; }
        public Func<NDArrayList, NDArrayList> TransformFn { get; }

        public Kinetics400(string root = "/datasets/kinetics400/rawframes_train",
                  string setting = "/datasets/kinetics400/kinetics400_train_list_rawframes.txt",
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
                  bool slowfast = false,
                  int slow_temporal_stride = 16,
                  int fast_temporal_stride = 2,
                  Func<NDArrayList, NDArrayList> transform = null)
        {
            Root = root;
            Setting = setting;
            Train = train;
            TestMode = test_mode;
            NamePattern = name_pattern;
            VideoExt = video_ext;
            IsColor = is_color;
            Modality = modality;
            NumSegments = num_segments;
            NumCrop = num_crop;
            NewLength = new_length;
            NewStep = new_step;
            NewWidth = new_width;
            NewHeight = new_height;
            TargetWidth = target_width;
            TargetHeight = target_height;
            TemporalJitter = temporal_jitter;
            VideoLoader = video_loader;
            UseDecord = use_decord;
            Slowfast = slowfast;
            SlowTemporalStride = slow_temporal_stride;
            FastTemporalStride = fast_temporal_stride;
            TransformFn = transform;
            SkipLength = new_length * new_step;

            if (this.Slowfast)
            {
                Debug.Assert(slow_temporal_stride % fast_temporal_stride == 0, "slow_temporal_stride needs to be multiples of slow_temporal_stride, please set it accordinly.");
                Debug.Assert(!temporal_jitter, "Slowfast dataloader does not support temporal jitter. Please set temporal_jitter=False.");
                Debug.Assert(new_step == 1, "Slowfast dataloader only support consecutive frames reading, please set new_step=1.");
            }
            if (this.VideoLoader)
            {
                if (this.UseDecord)
                {
                    //this.decord = try_import_decord();
                    throw new NotSupportedException("UseDecord");
                }
                else
                {
                    //this.mmcv = try_import_mmcv();
                    throw new NotSupportedException("MMCV");
                }
            }
            (Classes, ClassToIdx) = this.FindClasses(root);
            this.Clips = this.MakeDataset(root, setting);
            if (this.Clips.Count == 0)
            {
                throw new Exception("Found 0 video clips in subfolders of: " + root + "\nCheck your data directory (opt.data-dir).");
            }
        }

        public override (NDArray, int) this[int idx]
        {
            get
            {
                NDArrayList clip_input = new NDArrayList();
                string video_name;
                var (directory, duration, target) = this.Clips[idx];
                if (this.VideoLoader)
                {
                    if (directory.Split('/').Last().Contains("."))
                    {
                        // data in the "setting" file already have extension, e.g., demo.mp4
                        video_name = directory;
                    }
                    else
                    {
                        // data in the "setting" file do not have extension, e.g., demo
                        // So we need to provide extension (i.e., .mp4) to complete the file name.
                        video_name = $"{directory}.{VideoExt}";
                    }
                    if (this.UseDecord)
                    {
                        //var decord_vr = this.decord.VideoReader(video_name, width: this.new_width, height: this.new_height);
                        //duration = decord_vr.Count;
                        throw new NotSupportedException();
                    }
                    else
                    {
                        //var mmcv_vr = this.mmcv.VideoReader(video_name);
                        //duration = mmcv_vr.Count;
                        throw new NotSupportedException();
                    }
                }

                NDArray segment_indices = null;
                NDArray skip_offsets = null;
                if (this.Train && !this.TestMode)
                {
                    (segment_indices, skip_offsets) = this.SampleTrainIndices(duration);
                }
                else if (!this.Train && !this.TestMode)
                {
                    (segment_indices, skip_offsets) = this.SampleValIndices(duration);
                }
                else
                {
                    (segment_indices, skip_offsets) = this.SampleTestIndices(duration);
                }

                // N frames of shape H x W x C, where N = num_oversample * num_segments * new_length
                if (this.VideoLoader)
                {
                    if (this.Slowfast)
                    {
                        //clip_input = this.VideoTSNDecordSlowFastLoader(directory, decord_vr, duration, segment_indices, skip_offsets);
                        throw new NotSupportedException();
                    }
                    else if (this.UseDecord)
                    {
                        //clip_input = this._video_TSN_decord_batch_loader(directory, decord_vr, duration, segment_indices, skip_offsets);
                        throw new NotSupportedException();
                    }
                    else
                    {
                        //clip_input = this._video_TSN_mmcv_loader(directory, mmcv_vr, duration, segment_indices, skip_offsets);
                        throw new NotSupportedException();
                    }
                }
                else if (this.Slowfast)
                {
                    clip_input = this.ImageSlowfastCv2Loader(directory, duration, segment_indices, skip_offsets);
                }
                else
                {
                    clip_input = this.ImageTSNCv2Loader(directory, duration, segment_indices, skip_offsets);
                }
                if (this.TransformFn != null)
                {
                    clip_input = this.TransformFn(clip_input);
                }

                NDArray clip = null;
                if (this.Slowfast)
                {
                    var sparse_sampels = clip_input.Length / (this.NumSegments * this.NumCrop);
                    clip = nd.Stack(clip_input, clip_input.Length, axis: 0);
                    clip = clip.Reshape(-1, sparse_sampels, 3, this.TargetHeight, this.TargetWidth);
                    clip = clip.Transpose(new Shape(0, 2, 1, 3, 4));
                }
                else
                {
                    clip = nd.Stack(clip_input, clip_input.Length, axis: 0);
                    clip = clip.Reshape(-1, this.NewLength, 3, this.TargetHeight, this.TargetWidth);
                    clip = nd.Transpose(clip_input, new Shape(0, 2, 1, 3, 4));
                }
                if (this.NewLength == 1)
                {
                    clip = nd.Squeeze(clip, axis: new Shape(2));
                }
                return (clip, target);
            }
        }

        public override int Length => Clips.Count;

        private (string[], Dictionary<string, int>) FindClasses(string directory) => throw new NotImplementedException();

        private List<(string, int, int)> MakeDataset(string directory, string setting) => throw new NotImplementedException();

        private (NDArray, NDArray) SampleTrainIndices(int num_frames)
        {
            NDArray skip_offsets;
            NDArray offsets = null;
            var average_duration = (num_frames - this.SkipLength + 1) / this.NumSegments;
            if (average_duration > 0)
            {
                offsets = new NDArray(Enumerable.Range(0, this.NumSegments).ToArray()) * average_duration;
                offsets = offsets + nd.Random.Normal(0, average_duration, shape: new Shape(this.NumSegments));
            }
            else if (num_frames > Math.Max(this.NumSegments, this.SkipLength))
            {
                offsets = nd.Sort(nd.Random.Normal(0, num_frames - this.SkipLength + 1, shape: new Shape(this.NumSegments)));
            }
            else
            {
                offsets = nd.Zeros(new Shape(this.NumSegments));
            }
            if (this.TemporalJitter)
            {
                skip_offsets = nd.Random.Normal(0, NewStep, shape: new Shape(this.SkipLength / NewStep));
            }
            else
            {
                skip_offsets = nd.Zeros(new Shape(this.SkipLength / this.NewStep), dtype: DType.Int32);
            }

            return (offsets + 1, skip_offsets);
        }

        private (NDArray, NDArray) SampleValIndices(int num_frames)
        {
            NDArray skip_offsets;
            NDArray offsets;
            if (num_frames > this.NumSegments + this.SkipLength - 1)
            {
                var tick = (num_frames - this.SkipLength + 1) / (float)this.NumSegments;
                offsets = nd.Array((from x in Enumerable.Range(0, this.NumSegments)
                                    select Convert.ToInt32(tick / 2.0 + tick * x)).ToArray());
            }
            else
            {
                offsets = nd.Zeros(new Shape(this.NumSegments));
            }
            if (this.TemporalJitter)
            {
                skip_offsets = nd.Random.Normal(0, NewStep, shape: new Shape(this.SkipLength / this.NewStep));
            }
            else
            {
                skip_offsets = nd.Zeros(new Shape(this.SkipLength / this.NewStep), dtype: DType.Int32);
            }
            return (offsets + 1, skip_offsets);
        }

        private (NDArray, NDArray) SampleTestIndices(int num_frames)
        {
            NDArray skip_offsets;
            NDArray offsets;
            if (num_frames > this.SkipLength - 1)
            {
                var tick = (num_frames - this.SkipLength + 1) / (float)this.NumSegments;
                offsets = nd.Array((from x in Enumerable.Range(0, this.NumSegments)
                                    select Convert.ToInt32(tick / 2.0 + tick * x)).ToArray());
            }
            else
            {
                offsets = nd.Zeros(new Shape(this.NumSegments));
            }

            if (this.TemporalJitter)
            {
                skip_offsets = nd.Random.Normal(0, NewStep, shape: new Shape(this.SkipLength / this.NewStep));
            }
            else
            {
                skip_offsets = nd.Zeros(new Shape(this.SkipLength / this.NewStep), dtype: DType.Int32);
            }
            return (offsets + 1, skip_offsets);
        }

        private NDArrayList ImageTSNCv2Loader(string directory, int duration, NDArray indices, NDArray skip_offsets_nd)
        {
            string frame_path;
            NDArrayList sampled_list = new NDArrayList();
            var skip_offsets = skip_offsets_nd.GetValues<int>();
            foreach (var seg_ind in indices.GetValues<int>())
            {
                var offset = Convert.ToInt32(seg_ind);
                foreach (var _tup_1 in Enumerable.Range(0, Convert.ToInt32(Math.Ceiling(Convert.ToDouble(this.SkipLength - 0) / this.NewStep))).Select(_x_1 => 0 + _x_1 * this.NewStep).Select((_p_1, _p_2) => Tuple.Create(_p_2, _p_1)))
                {
                    var i = _tup_1.Item1;
                    if (offset + skip_offsets[i] <= duration)
                    {
                        frame_path = Path.Combine(directory, (offset + skip_offsets[i]).ToString(this.NamePattern));
                    }
                    else
                    {
                        frame_path = Path.Combine(directory, offset.ToString(NamePattern));
                    }
                    var cv_img = Cv2.ImRead(frame_path);
                    if (cv_img == null)
                    {
                        throw new Exception($"Could not load file {frame_path} starting at frame {offset}. Check data path.");
                    }
                    if (this.NewWidth > 0 && this.NewHeight > 0)
                    {
                        var h = cv_img.Height;
                        var w = cv_img.Width;
                        if (h != this.NewHeight || w != this.NewWidth)
                        {
                            Cv2.Resize(cv_img, cv_img, new Size(this.NewWidth, this.NewHeight));
                        }
                    }

                    var img = NDArray.LoadCV2Mat(cv_img);

                    img = img[":,:,::-1"]; //ToDo: will not work need to fix indexing
                    sampled_list.Add(img);
                    if (offset + this.NewStep < duration)
                    {
                        offset += this.NewStep;
                    }
                }
            }
            return sampled_list;
        }

        private NDArrayList ImageSlowfastCv2Loader(string directory, int duration, NDArray indices, NDArray skip_offsets_nd)
        {
            string frame_path;
            NDArrayList sampled_list = new NDArrayList();
            var skip_offsets = skip_offsets_nd.GetValues<int>();
            foreach (var seg_ind in indices.GetValues<int>())
            {
                var offset = Convert.ToInt32(seg_ind);
                var fast_list = new List<NDArray>();
                var slow_list = new List<NDArray>();
                foreach (var _tup_1 in Enumerable.Range(0, Convert.ToInt32(Math.Ceiling(Convert.ToDouble(this.SkipLength - 0) / this.NewStep))).Select(_x_1 => 0 + _x_1 * this.NewStep).Select((_p_1, _p_2) => Tuple.Create(_p_2, _p_1)))
                {
                    var i = _tup_1.Item1;
                    if (offset + skip_offsets[i] <= duration)
                    {
                        frame_path = Path.Combine(directory, (offset + skip_offsets[i]).ToString(this.NamePattern));
                    }
                    else
                    {
                        frame_path = Path.Combine(directory, offset.ToString(NamePattern));
                    }

                    if ((i + 1) % this.FastTemporalStride == 0)
                    {
                        var cv_img = Cv2.ImRead(frame_path);
                        if (cv_img == null)
                        {
                            throw new Exception($"Could not load file {frame_path} starting at frame {offset}. Check data path.");
                        }
                        if (this.NewWidth > 0 && this.NewHeight > 0)
                        {
                            var h = cv_img.Height;
                            var w = cv_img.Width;
                            if (h != this.NewHeight || w != this.NewWidth)
                            {
                                Cv2.Resize(cv_img, cv_img, new Size(this.NewWidth, this.NewHeight));
                            }
                        }

                        var img = NDArray.LoadCV2Mat(cv_img);

                        img = img[":,:,::-1"]; //ToDo: will not work need to fix indexing
                        fast_list.Add(img);
                        if (offset + this.NewStep < duration)
                        {
                            offset += this.NewStep;
                        }
                    }
                    if (offset + this.NewStep < duration)
                    {
                        offset += this.NewStep;
                    }
                }

                fast_list.AddRange(slow_list);
                sampled_list.Add(fast_list.ToArray());
            }

            return sampled_list;
        }

        private NDArrayList VideoTSNMmcvLoader(string directory, FileStream video_reader, int duration, NDArray indices, NDArray skip_offsets) => throw new NotSupportedException();

        private NDArrayList VideoTSNDecordLoader(string directory, FileStream video_reader, int duration, NDArray indices, NDArray skip_offsets) => throw new NotSupportedException();

        private NDArrayList VideoTSNDecordBatchLoader(string directory, FileStream video_reader, int duration, NDArray indices, NDArray skip_offsets) => throw new NotSupportedException();

        private NDArrayList VideoTSNDecordSlowFastLoader(string directory, FileStream video_reader, int duration, NDArray indices, NDArray skip_offsets) => throw new NotSupportedException();
    }
}
