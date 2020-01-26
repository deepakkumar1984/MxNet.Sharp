using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Initializers
{
    public abstract class Initializer
    {
        public Initializer()
        {
            throw new NotImplementedException();
        }

        public void SetVerbosity(bool verbose = false, Func<NDArray, string> print_func = null) => throw new NotImplementedException();

        public abstract void InitWeight(string name, NDArray arr);

        private void VerbosePrint(InitDesc desc, string @init, NDArray arr) => throw new NotImplementedException();

        public string Dumps() => throw new NotImplementedException();

        public void Call(InitDesc desc, NDArray arr) => throw new NotImplementedException();

        private void InitBilinear(NDArray arr) => throw new NotImplementedException();

        private void InitZero(NDArray arr) => throw new NotImplementedException();

        private void InitLocBias(NDArray arr) => throw new NotImplementedException();

        private void InitOne(NDArray arr) => throw new NotImplementedException();

        private void InitBias(NDArray arr) => throw new NotImplementedException();

        private void InitQuantizedBias(NDArray arr) => throw new NotImplementedException();

        private void InitGamma(NDArray arr) => throw new NotImplementedException();

        private void InitBeta(NDArray arr) => throw new NotImplementedException();

        private void InitQuantizedWeight(NDArray arr) => throw new NotImplementedException();

        private void InitDefault(NDArray arr) => throw new NotImplementedException();
    }
}
