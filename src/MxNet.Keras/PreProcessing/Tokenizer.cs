using MxNet.Keras.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.PreProcessing
{
    public class Tokenizer
    {
        public Tokenizer(int? num_words= null, string filters= "!\"#$%&()*+,-./:;<=>?@[\\]^_`{|}~\t\n", bool lower= true, string split= " ",
                 bool char_level= false, string oov_token= "", int document_count= 0)
        {
            throw new NotImplementedException();
        }

        public void FitOnTexts(string[] texts)
        {
            throw new NotImplementedException();
        }

        public void FitOnSequences(Sequence<int>[] sequences)
        {
            throw new NotImplementedException();
        }

        public Sequence<int>[] TextsToSequences(string[] texts)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sequence<int>> TextsToSequencesGenerator(string[] texts)
        {
            throw new NotImplementedException();
        }

        public string[] SequencesToTexts(Sequence<int>[] sequences)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> SequencesToTextsGenerator(Sequence<int>[] sequences)
        {
            throw new NotImplementedException();
        }

        public NDArray TextsToMatrix(string[] texts, string mode = "binary")
        {
            throw new NotImplementedException();
        }

        public NDArray SequencesToMatrix(Sequence<int>[] texts, string mode = "binary")
        {
            throw new NotImplementedException();
        }

        public ConfigDict GetConfig()
        {
            throw new NotImplementedException();
        }

        public string ToJson()
        {
            throw new NotImplementedException();
        }

        public static Tokenizer TokenizerFromJson(string json_string)
        {
            throw new NotImplementedException();
        }
    }
}
