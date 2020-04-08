using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.PreProcessing
{
    public class Text
    {
        public static string[] TextToWordSequence(string text, string filters= "!\"#$%&()*+,-./:;<=>?@[\\]^_`{|}~\t\n", bool lower= true, string split= " ")
        {
            throw new NotImplementedException();
        }

        public static int[] OntHot(string text, int n, string filters = "!\"#$%&()*+,-./:;<=>?@[\\]^_`{|}~\t\n", bool lower = true, string split = " ")
        {
            throw new NotImplementedException();
        }

        public static int[] HashingTrick(string text, Func<string, int> hash_function = null, string filters = "!\"#$%&()*+,-./:;<=>?@[\\]^_`{|}~\t\n", bool lower = true, string split = " ")
        {
            throw new NotImplementedException();
        }
    }
}
