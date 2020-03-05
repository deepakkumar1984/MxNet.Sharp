using System;
using MxNet.Interop;
using MxNet.Optimizers;
using Newtonsoft.Json;

namespace MxNet.KVstore
{
    public class KVStoreServer
    {
        public delegate void ServerController(int cmd_id, string cmd_body);

        private IntPtr handle;
        private bool init_logging;
        private readonly KVStore kvstore;

        public KVStoreServer(KVStore kvstore)
        {
            this.kvstore = kvstore;
            handle = kvstore.handle;
            init_logging = false;
        }

        public ServerController Controller()
        {
            ServerController ctl = (cmd_id, cmd_body) =>
            {
                var head = "";
                if (!init_logging)
                {
                    head = string.Format("{0} Server[{1}]", DateTime.Now.ToString(), kvstore.Rank);
                    Logger.Log(head);
                    init_logging = true;
                }

                if (cmd_id == 0)
                {
                    var optimizer = JsonConvert.DeserializeObject(cmd_body);
                    kvstore.SetOptimizer((Optimizer) optimizer);
                }
                else
                {
                    Console.WriteLine("Server {0}, unknown command ({1},{2})", kvstore.Rank, cmd_id, cmd_body);
                }
            };

            return ctl;
        }

        public void Run()
        {
            var serverController = Controller();
            var controller = new MXKVStoreServerController
            {
                body = "",
                head = 0,
                controller_handle = serverController.Method.MethodHandle.GetFunctionPointer()
            };

            NativeMethods.MXKVStoreRunServer(kvstore.handle, controller, controller.controller_handle);
        }

        public static void InitServerModule()
        {
            NativeMethods.MXKVStoreIsWorkerNode(out var is_worker);
            if (is_worker == 0)
            {
                var kvstore = KVStoreBase.Create("dist");
                var server = new KVStoreServer(kvstore);
                server.Run();
            }
        }
    }
}