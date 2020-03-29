using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace MxNet.GluonCV.Data.Market1501
{
    public class LabelRead
    {
        public static ((string, int)[], (string, int)[]) LabelList(float ratio= 1, string root= "/datasets", string name= "market1501")
        {
            root = mx.AppPath + root;
            if (name == "market1501")
            {
                var path = Path.Combine(root, "Market-1501-v15.09.15");
                var train_txt = Path.Combine(path, "train.txt");
                var image_path = Path.Combine(path, "bounding_box_train");
                var item_list = (from line in File.ReadAllLines(train_txt)
                                 select (Path.Combine(image_path, line.Split(' ')[0]), Convert.ToInt32(line.Split(' ')[1]))).ToList();

                item_list.Shuffle();
                var count = item_list.Count;
                var train_count = Convert.ToInt32(count * ratio);
                var train_set = item_list.Take(train_count).ToList();
                var valid_set = item_list.Skip(train_count).ToList();
                return (train_set.ToArray(), valid_set.ToArray());
            }
            return (null, null);
        }
    }
}
