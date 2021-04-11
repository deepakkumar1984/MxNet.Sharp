using MxNet.Sym.Numpy;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Numpy
{
    public partial class npx : ND.Numpy.npx
    {
        public static void set_np(bool shape = true, bool array = true, bool dtype = false)
        {
            throw new NotImplementedException();
        }

        public static void reset_np()
        {
            throw new NotImplementedException();
        }

        public static Context cpu(int device_id)
        {
            throw new NotImplementedException();
        }

        public static Context cpu_pinned(int device_id)
        {
            throw new NotImplementedException();
        }

        public static Context gpu(int device_id)
        {
            throw new NotImplementedException();
        }

        public static (int, int) gpu_memory_info(int device_id)
        {
            throw new NotImplementedException();
        }

        public static Context current_context()
        {
            throw new NotImplementedException();
        }

        public static int num_gpus()
        {
            throw new NotImplementedException();
        }
    }
}
