using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data
{
    public class COCOKeyPoints : VisionDataset
    {
        public COCOKeyPoints(string root, string splits = "person_keypoints_val2017", bool check_centers = false, bool skip_empty = true) : base(root)
        {
            throw new NotImplementedException();
        }

        public override string[] Classes => throw new NotImplementedException();

        public int NumJoints => 17;

        public int[,] JointPairs => new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 }, { 9, 10 }, { 11, 12 }, { 13, 14 }, { 15, 16 } };

        public COCO Coco => throw new NotImplementedException();

        public override (NDArray, NDArray) this[int idx] => throw new NotImplementedException();

        internal (string[], NDArrayList) LoadJsons() => throw new NotImplementedException();

        internal Dictionary<string, int[]> CheckLoadKeypoints(COCO coco, COCOEntry entry) => throw new NotImplementedException();

        internal (NDArray, int) GetBoxCenterArea(int[] bbox) => throw new NotImplementedException();

        internal (NDArray, int) GetKeypointsCenterCount(int[] keypoints) => throw new NotImplementedException();
    }
}
