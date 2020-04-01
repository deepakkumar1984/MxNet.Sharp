using System;
using System.Collections.Generic;
using System.Text;

namespace CocoTools.NET
{
    public class CocoCat
    {
        public string Name { get; set; }

        public string SuperCategory { get; set; }

        public int ID { get; set; }

        public float Area { get; set; }

        public bool Ignore { get; set; }

        public bool IsCrowd { get; set; }

        public (int, int, int, int) BBox { get; set; }

        public List<int[]> Segmentation { get; set; }
    }

    public class COCO
    {
        public COCO(string root)
        {
            throw new NotImplementedException();
        }

        public int[] GetCatIds(string[] catNms=null, string[] supNms=null, int[] catIds=null)
        {
            throw new NotImplementedException();
        }

        public CocoCat[] LoadCats(int[] ids)
        {
            throw new NotImplementedException();
        }

        public int[] GetImgIds(int[] imgIds = null, int[] catIds = null)
        {
            throw new NotImplementedException();
        }

        public COCOEntry[] LoadImgs(int[] ids)
        {
            throw new NotImplementedException();
        }

        public CocoCat[] LoadAnns(int[] ids)
        {
            throw new NotImplementedException();
        }

        public int[] GetAnnIds(int[] imgIds=null, int[] catIds=null, float[] areaRng=null, bool? iscrowd= null)
        {
            throw new NotImplementedException();
        }
    }
}
