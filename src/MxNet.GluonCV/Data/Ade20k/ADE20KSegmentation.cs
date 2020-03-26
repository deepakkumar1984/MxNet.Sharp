using MxNet.Image;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace MxNet.GluonCV.Data
{
    public class ADE20KSegmentation : SegmentationDataset
    {
        public string BASE_DIR = "ADEChallengeData2016";
        public string[] CLASSES = new string[] {"wall", "building, edifice", "sky", "floor, flooring", "tree",
               "ceiling", "road, route", "bed", "windowpane, window", "grass",
               "cabinet", "sidewalk, pavement",
               "person, individual, someone, somebody, mortal, soul",
               "earth, ground", "door, double door", "table", "mountain, mount",
               "plant, flora, plant life", "curtain, drape, drapery, mantle, pall",
               "chair", "car, auto, automobile, machine, motorcar",
               "water", "painting, picture", "sofa, couch, lounge", "shelf",
               "house", "sea", "mirror", "rug, carpet, carpeting", "field", "armchair",
               "seat", "fence, fencing", "desk", "rock, stone", "wardrobe, closet, press",
               "lamp", "bathtub, bathing tub, bath, tub", "railing, rail", "cushion",
               "base, pedestal, stand", "box", "column, pillar", "signboard, sign",
               "chest of drawers, chest, bureau, dresser", "counter", "sand", "sink",
               "skyscraper", "fireplace, hearth, open fireplace", "refrigerator, icebox",
               "grandstand, covered stand", "path", "stairs, steps", "runway",
               "case, display case, showcase, vitrine",
               "pool table, billiard table, snooker table", "pillow",
               "screen door, screen", "stairway, staircase", "river", "bridge, span",
               "bookcase", "blind, screen", "coffee table, cocktail table",
               "toilet, can, commode, crapper, pot, potty, stool, throne",
               "flower", "book", "hill", "bench", "countertop",
               "stove, kitchen stove, range, kitchen range, cooking stove",
               "palm, palm tree", "kitchen island",
               "computer, computing machine, computing device, data processor, "
               "electronic computer, information processing system",
               "swivel chair", "boat", "bar", "arcade machine",
               "hovel, hut, hutch, shack, shanty",
               "bus, autobus, coach, charabanc, double-decker, jitney, motorbus, "
               "motorcoach, omnibus, passenger vehicle",
               "towel", "light, light source", "truck, motortruck", "tower",
               "chandelier, pendant, pendent", "awning, sunshade, sunblind",
               "streetlight, street lamp", "booth, cubicle, stall, kiosk",
               "television receiver, television, television set, tv, tv set, idiot "
               "box, boob tube, telly, goggle box",
               "airplane, aeroplane, plane", "dirt track",
               "apparel, wearing apparel, dress, clothes",
               "pole", "land, ground, soil",
               "bannister, banister, balustrade, balusters, handrail",
               "escalator, moving staircase, moving stairway",
               "ottoman, pouf, pouffe, puff, hassock",
               "bottle", "buffet, counter, sideboard",
               "poster, posting, placard, notice, bill, card",
               "stage", "van", "ship", "fountain",
               "conveyer belt, conveyor belt, conveyer, conveyor, transporter",
               "canopy", "washer, automatic washer, washing machine",
               "plaything, toy", "swimming pool, swimming bath, natatorium",
               "stool", "barrel, cask", "basket, handbasket", "waterfall, falls",
               "tent, collapsible shelter", "bag", "minibike, motorbike", "cradle",
               "oven", "ball", "food, solid food", "step, stair", "tank, storage tank",
               "trade name, brand name, brand, marque", "microwave, microwave oven",
               "pot, flowerpot", "animal, animate being, beast, brute, creature, fauna",
               "bicycle, bike, wheel, cycle", "lake",
               "dishwasher, dish washer, dishwashing machine",
               "screen, silver screen, projection screen",
               "blanket, cover", "sculpture", "hood, exhaust hood", "sconce", "vase",
               "traffic light, traffic signal, stoplight", "tray",
               "ashcan, trash can, garbage can, wastebin, ash bin, ash-bin, ashbin",
               "dustbin, trash barrel, trash bin",
               "fan", "pier, wharf, wharfage, dock", "crt screen",
               "plate", "monitor, monitoring device", "bulletin board, notice board",
               "shower", "radiator", "glass, drinking glass", "clock", "flag" };

        public int NUM_CLASS = 150;

        public string[] Images;

        public string[] Masks;

        public ADE20KSegmentation(string root = "~/.mxnet/datasets/ade", string split = "train", string mode = null, Func<NDArray, NDArray> transform = null, int base_size = 520, int crop_size = 480) : base(root, split, mode, transform, base_size, crop_size)
        {
            root = Path.Combine(Root, this.BASE_DIR);
            Debug.Assert(Directory.Exists(root));
            (Images, Masks) = GetAde20kPairs(root, split);
            Debug.Assert(this.Images.Length == this.Masks.Length);
            if (this.Images.Length == 0)
            {
                throw new Exception("Found 0 images in subfolders of: " + root + "\n");
            }
        }

        public override (NDArray, NDArray) this[int idx]
        {
            get
            {
                var img = Img.ImRead(Images[idx]);
                if (this.Mode == "test")
                {
                    img = this.ImgTransform(img);
                    if (this.Transform != null)
                    {
                        img = this.Transform(img);
                    }

                    return (img, null);
                }

                var mask = Img.ImRead(Masks[idx]);
                // synchrosized transform
                if (this.Mode == "train")
                {
                    (img, mask) = this.SyncTransform(img, mask);
                }
                else if (this.Mode == "val")
                {
                    (img, mask) = this.ValSyncTransform(img, mask);
                }
                else
                {
                    Debug.Assert(this.Mode == "testval");
                    img = this.ImgTransform(img);
                    mask = this.MaskTransform(mask);
                }
                // general resize, normalize and toTensor
                if (this.Transform != null)
                {
                    img = this.Transform(img);
                }
                return (img, mask);
            }
        }

        internal override NDArray MaskTransform(NDArray mask)
        {
            return mask.AsInContext(mx.Cpu()).AsType(DType.Int32) - 1;
        }

        public override int Length => Images.Length;

        public override string[] Classes => CLASSES;

        public override int PredOffset => 1;

        public (string[], string[]) GetAde20kPairs(string folder, string split = "train")
        {
            string mask_folder;
            string img_folder;
            var img_paths = new List<string>();
            var mask_paths = new List<string>();
            if (Mode == "train")
            {
                img_folder = Path.Combine(folder, "images/training");
                mask_folder = Path.Combine(folder, "annotations/training");
            }
            else
            {
                img_folder = Path.Combine(folder, "images/validation");
                mask_folder = Path.Combine(folder, "annotations/validation");
            }
            foreach (var filename in Directory.EnumerateFiles(img_folder))
            {
                var basename = Path.GetFileNameWithoutExtension(filename);
                if (filename.EndsWith(".jpg"))
                {
                    var imgpath = Path.Combine(img_folder, filename);
                    var maskname = basename + ".png";
                    var maskpath = Path.Combine(mask_folder, maskname);
                    if (File.Exists(maskpath))
                    {
                        img_paths.Add(imgpath);
                        mask_paths.Add(maskpath);
                    }
                    else
                    {
                        Console.WriteLine("cannot find the mask:", maskpath);
                    }
                }
            }
            return (img_paths.ToArray(), mask_paths.ToArray());
        }
    }
}
