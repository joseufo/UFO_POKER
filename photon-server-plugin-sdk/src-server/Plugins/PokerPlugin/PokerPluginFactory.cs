using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.Hive.Plugin;
namespace PokerPlugin
{
    public class PokerPluginFactory: PluginFactoryBase
    {
        public override IGamePlugin CreatePlugin(string pluginName)
        {
            return new PokerPlugin();
        }
    }


}
