using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras
{
    public class KerasContext : IDisposable
    {
        private Context[] scope_ctx;

        public KerasContext(Context ctx)
        {
            scope_ctx = MxNetBackend.GetMxNetContexts(ctx);
            MxNetBackend._CURRENT_SCOPE_CTX = scope_ctx;
        }

        public void Dispose()
        {
            MxNetBackend._CURRENT_SCOPE_CTX = null;
        }
    }
}
