using MxNet.Interop;
using MxNet.Optimizers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.KVstore
{
    public class KVStoreServer
    {
        private KVStore kvstore;
        private IntPtr handle;
        private bool init_logging;
        public delegate void ServerController(int cmd_id, string cmd_body);

        public KVStoreServer(KVStore kvstore)
        {
            this.kvstore = kvstore;
            this.handle = kvstore.handle;
            init_logging = false;
        }

        public ServerController Controller()
        {
            ServerController ctl = (cmd_id, cmd_body) => 
            {
                string head = "";
                if(!init_logging)
                {
                    head = string.Format("{0} Server[{1}]", DateTime.Now.ToString(), kvstore.Rank);
                    Logger.GetLogger().Log(head);
                    init_logging = true;
                }

                if(cmd_id == 0)
                {
                    var optimizer = Newtonsoft.Json.JsonConvert.DeserializeObject(cmd_body);
                    kvstore.SetOptimizer((Optimizer)optimizer);
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
            MXKVStoreServerController controller = new MXKVStoreServerController()
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
            if(is_worker == 0)
            {
                var kvstore = KVStoreBase.Create("dist");
                var server = new KVStoreServer(kvstore);
                server.Run();
            }
        }

    }
}
