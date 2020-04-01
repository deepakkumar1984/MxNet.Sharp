using MxNet.Gluon.Data;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MxNet.GluonCV.Data
{
    public class HMDB51 : Dataset<(NDArray, int)>
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
        public int NewLength { get; }
        public int NewStep { get; }
        public int NewWidth { get; }
        public int NewHeight { get; }
        public int TargetWidth { get; }
        public int TargetHeight { get; }
        public bool TemporalJitter { get; }
        public bool VideoLoader { get; }
        public bool UseDecord { get; }
        public int SkipLength { get; }
        public string[] Classes { get; }
        public Dictionary<string, int> ClassToIdx { get; }
        public List<(string, int, int)> Clips { get; }
        public Func<NDArrayList, NDArrayList> TransformFn { get; }

        public HMDB51(string root= "~/mxnet/datasets/hmdb51/rawframes",
                 string setting= "~/mxnet/datasets/hmdb51/testTrainMulti_7030_splits/hmdb51_train_split_1_rawframes.txt",
                 bool train= true,
                 bool test_mode= false,
                 string name_pattern= "img_%05d.jpg",
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
                 Func<NDArrayList, NDArrayList> transform= null)
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
            NewLength = new_length;
            NewStep = new_step;
            NewWidth = new_width;
            NewHeight = new_height;
            TargetWidth = target_width;
            TargetHeight = target_height;
            TemporalJitter = temporal_jitter;
            VideoLoader = video_loader;
            UseDecord = use_decord;
            TransformFn = transform;
            SkipLength = new_length * new_step;
            if(video_loader)
            {
                throw new NotSupportedException("Currently video loader is not supported");
            }

            (Classes, ClassToIdx) = FindClasses(root);
            Clips = MakeDataset(root, setting);
            if (this.Clips.Count == 0)
            {
                throw new Exception("Found 0 video clips in subfolders of: " + root + "\nCheck your data directory (opt.data-dir).");
            }
        }

        public override (NDArray, int) this[int idx]
        {
            get
            {
                NDArrayList clip_input;
                var (directory, duration, target) = this.Clips[idx];
                if (this.VideoLoader)
                {
                    if (this.UseDecord)
                    {
                        //var decord_vr = this.decord.VideoReader("{}.{}".format(directory, this.video_ext), width: this.new_width, height: this.new_height);
                        //duration = decord_vr.Count;
                        throw new NotSupportedException("Decord is not supported");
                    }
                    else
                    {
                        //var mmcv_vr = this.mmcv.VideoReader("{}.{}".format(directory, this.video_ext));
                        //duration = mmcv_vr.Count;
                        throw new NotSupportedException("MMVC is not supported");
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
                    if (this.UseDecord)
                    {
                        //clip_input = this.VideoTSNDecordBatchLoader(directory, decord_vr, duration, segment_indices, skip_offsets);
                        throw new NotSupportedException("Decord is not supported");
                    }
                    else
                    {
                        //clip_input = this._video_TSN_mmcv_loader(directory, mmcv_vr, duration, segment_indices, skip_offsets);
                        throw new NotSupportedException("MMVC is not supported");
                    }
                }
                else
                {
                    clip_input = this.ImageTSNCv2Loader(directory, duration, segment_indices, skip_offsets);
                }
                if (this.TransformFn != null)
                {
                    clip_input = this.TransformFn(clip_input);
                }

                var clip = nd.Stack(clip_input, clip_input.Length, axis: 0);
                clip = clip.Reshape(-1, this.NewLength, 3, this.TargetHeight, this.TargetWidth);
                clip = nd.Transpose(clip_input, new Shape(0, 2, 1, 3, 4));
                if (this.NewLength == 1)
                {
                    clip = nd.Squeeze(clip, new Shape(2));
                }

                return (clip, target);
            }
        }

        public override int Length => Clips.Count;

        private (string[], Dictionary<string, int>) FindClasses(string directory)
        {
            var classes = (from i in Directory.EnumerateDirectories(directory)
                           where Directory.Exists(i)
                            select i).ToList();
            classes.Sort();
            var class_to_idx = Enumerable.Range(0, classes.Count).ToDictionary(i => classes[i], i => i);
            return (classes.ToArray(), class_to_idx);
        }

        private List<(string, int, int)> MakeDataset(string directory, string setting)
        {
            var clips = new List<(string, int, int)>();

            var data = File.ReadAllLines(setting);
            foreach (var line in data)
            {
                var line_info = line.Split(',');
                // line format: video_path, video_duration, video_label
                if (line_info.Length < 3)
                {
                    throw new Exception(String.Format("Video input format is not correct, missing one or more element. {0}", line));
                }

                var clip_path = Path.Combine(directory, line_info[0].Trim());
                var duration = Convert.ToInt32(line_info[1].Trim());
                var target = Convert.ToInt32(line_info[2].Trim());
                var item = (clip_path, duration, target);
                clips.Add(item);
            }

            return clips;
        }

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

        private NDArrayList VideoTSNMmcvLoader(string directory, FileStream video_reader, int duration, NDArray indices, int skip_offsets) => throw new NotSupportedException();

        private NDArrayList VideoTSNDecordLoader(string directory, FileStream video_reader, int duration, NDArray indices, int skip_offsets) => throw new NotSupportedException();

        private NDArrayList VideoTSNDecordBatchLoader(string directory, FileStream video_reader, int duration, NDArray indices, int skip_offsets) => throw new NotSupportedException();
    }

    public class HMDB51Attr
    {
        public int NumClasses = 51;

        public string[] Classes => new string[] {"brush_hair", "cartwheel", "catch", "chew", "clap", "climb", "climb_stairs",
                        "dive", "draw_sword", "dribble", "drink", "eat", "fall_floor", "fencing",
                        "flic_flac", "golf", "handstand", "hit", "hug", "jump", "kick", "kick_ball",
                        "kiss", "laugh", "pick", "pour", "pullup", "punch", "push", "pushup",
                        "ride_bike", "ride_horse", "run", "shake_hands", "shoot_ball", "shoot_bow",
                        "shoot_gun", "sit", "situp", "smile", "smoke", "somersault", "stand",
                        "swing_baseball", "sword", "sword_exercise", "talk", "throw", "turn", "walk", "wave" };
    }
}
