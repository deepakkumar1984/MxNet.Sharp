using MxNet.Gluon.Data;
using NumpyDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static NumpyDotNet.np;

namespace MxNet.GluonCV.NN
{
    public class SplitSampler : Sampler<int>
    {
        private int _end;

        private int _start;

        public SplitSampler(int length, int num_parts= 1, int part_index= 0)
        {
            // Compute the length of each partition
            var part_len = length / num_parts;
            // Compute the start index for this partition
            this._start = part_len * part_index;
            // Compute the end index for this partition
            this._end = this._start + part_len;
            if (part_index == num_parts - 1)
            {
                this._end = length;
            }
        }  

        public override int Length => this._end - this._start;

        public override IEnumerator<int> GetEnumerator()
        {
            // Extract examples between `start` and `end`, shuffle and return them.
            var indices = Enumerable.Range(this._start, this._end - this._start).ToArray();
            var inx = np.array(indices);
            new random().shuffle(inx);
            indices = inx.AsInt32Array();
            return indices.ToList().GetEnumerator();
        }
    }
}
