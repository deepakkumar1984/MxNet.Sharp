using MxNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace MNIST
{
    public class GluonDemo
    {
        public static void LoadData()
        {
            var dataset = TestUtils.GetMNIST();
        }
    }
}
