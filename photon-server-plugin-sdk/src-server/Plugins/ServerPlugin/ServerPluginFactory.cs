using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.Hive.Plugin;
namespace ServerPlugin
{
    public class ServerPluginFactory: PluginFactoryBase
    {
        public override IGamePlugin CreatePlugin(string pluginName)
        {
            return new ServerPlugin();
        }
    }


}
