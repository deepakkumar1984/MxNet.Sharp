using MxNet.Interop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MxNet
{
    public class Autograd
    {
        public static bool SetRecording(bool is_recording)
        {
            int prev = 0;
            NativeMethods.MXAutogradSetIsRecording(Convert.ToInt32(is_recording), ref prev);

            return Convert.ToBoolean(prev);
        }

        public static bool SetTraining(bool train_mode)
        {
            int prev = 0;
            NativeMethods.MXAutogradSetIsTraining(Convert.ToInt32(train_mode), ref prev);

            return Convert.ToBoolean(prev);
        }

        public static bool IsRecording()
        {
            int curr = 0;
            NativeMethods.MXAutogradIsRecording(ref curr);

            return Convert.ToBoolean(curr);
        }

        public static bool IsTraining()
        {
            int curr = 0;
            NativeMethods.MXAutogradIsTraining(ref curr);

            return Convert.ToBoolean(curr);
        }

        public static _RecordingStateScope Record(bool train_mode = true) => new _RecordingStateScope(true, train_mode);

        public static _RecordingStateScope Pause(bool train_mode = true) => new _RecordingStateScope(false, train_mode);

        public static _RecordingStateScope TrainMode() => new _RecordingStateScope(null, true);

        public static _RecordingStateScope PredictMode() => new _RecordingStateScope(null, false);

        public static void MarkVariables(NDArray[] variables, NDArray[] gradients, OpGradReq grad_reqs= OpGradReq.Write)
        {
            int[] gradReqs = new int[variables.Length];
            for(int i=0;i<gradReqs.Length;i++)
            {
                gradReqs[i] = (int)OpGradReq.Write;
            }

            NativeMethods.MXAutogradMarkVariables(variables.Length, MxUtil.GetNDArrayHandles(variables), gradReqs, MxUtil.GetNDArrayHandles(gradients));
        }

        private static (IntPtr[], IntPtr[]) ParseHead(NDArray[] heads, NDArray[] head_grads)
        {
            IntPtr[] headHandles = null;
            IntPtr[] headGradHandles = null;

            headHandles = MxUtil.GetNDArrayHandles(heads);

            if(head_grads == null)
            {
                headHandles = new IntPtr[heads.Length];
                for (int i = 0; i < headHandles.Length; i++)
                {
                    headHandles[i] = IntPtr.Zero;
                }
            }
            else
            {
                if (heads.Length != head_grads.Length)
                    throw new ArgumentException("heads and head_grads must be lists of the same length");

                headGradHandles = MxUtil.GetNDArrayHandles(head_grads);
            }

            return (headHandles, headGradHandles);
        }

        public static void Backward(NDArray[] heads, NDArray[] head_grads = null, bool retain_graph= false, bool train_mode= true)
        {
            var (head_handles, head_grads_handles) = ParseHead(heads, head_grads);

            NativeMethods.MXAutogradBackwardEx(head_handles.Length, head_handles, head_grads_handles, 0,
                                                new IntPtr[] { }, Convert.ToInt32(retain_graph),
                                                0, Convert.ToInt32(train_mode), new IntPtr[] { }, new int[] { });
        }

        public static NDArray[] Grad(NDArray[] heads, NDArray[] variables, NDArray[] head_grads = null, bool retain_graph = false, bool create_graph = true, bool train_mode = true)
        {
            var (head_handles, head_grads_handles) = ParseHead(heads, head_grads);

            IntPtr[] grad_handles = new IntPtr[head_handles.Length];
            int[] grad_stypes = new int[head_handles.Length];

            NativeMethods.MXAutogradBackwardEx(head_handles.Length, head_handles, head_grads_handles, variables.Length,
                                                MxUtil.GetNDArrayHandles(variables), Convert.ToInt32(retain_graph),
                                                Convert.ToInt32(create_graph), Convert.ToInt32(train_mode), grad_handles, grad_stypes);

            List<NDArray> result = new List<NDArray>();
            foreach (var item in grad_handles)
            {
                result.Add(new NDArray(item));
            }

            return result.ToArray();
        }

        public static Symbol GetSymbol(NDArray x)
        {
            IntPtr hdl = IntPtr.Zero;
            NativeMethods.MXAutogradGetSymbol(x.GetHandle(), hdl);
            return new Symbol(hdl);
        }

        public class _RecordingStateScope : MxDisposable
        {
            private bool? _enter_is_record;
            private bool? _enter_train_mode;
            private bool? _prev_is_record;
            private bool? _prev_train_mode;
            public _RecordingStateScope(bool? is_record, bool train_mode)
            {
                _enter_is_record = is_record;
                _enter_train_mode = train_mode;
                _prev_is_record = null;
                _prev_train_mode = null;
                if (_enter_is_record.HasValue)
                    _prev_is_record = SetRecording(_enter_is_record.Value);

                if (_enter_train_mode.HasValue)
                    _prev_train_mode = SetRecording(_enter_train_mode.Value);
            }

            public override MxDisposable Enter()
            {
                if(_enter_is_record.HasValue)
                    _prev_is_record = SetRecording(_enter_is_record.Value);

                if (_enter_train_mode.HasValue)
                    _prev_train_mode = SetRecording(_enter_train_mode.Value);
                return this;
            }

            public override void Exit()
            {
                if (_enter_is_record.HasValue && _prev_is_record != _enter_is_record)
                    SetRecording(_prev_is_record.Value);

                if (_enter_train_mode.HasValue && _prev_train_mode != _enter_train_mode)
                    SetRecording(_prev_train_mode.Value);
            }
        }
    }
}
