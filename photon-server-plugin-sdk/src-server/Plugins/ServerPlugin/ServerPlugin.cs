using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.Hive.Plugin;

namespace ServerPlugin
{
    public class ServerPlugin: PluginBase
    {

       public override string Name => "ServerPlugin";

        private Dictionary<string, int> playerScores = new Dictionary<string, int>();
        private const string SCORES_KEY = "player_scores";

        private IPluginLogger pluginLogger;
        //private IPluginHost pluginHost;
        public override bool SetupInstance(IPluginHost host, Dictionary<string, string> config, out string errorMsg)
        {

            this.pluginLogger = host.CreateLogger(this.Name);
            return base.SetupInstance(host, config, out errorMsg);
        }

        public override void OnCreateGame(ICreateGameCallInfo info)
        {
            this.pluginLogger.InfoFormat("\n\n OnCreateGame {0} by user {1} \n...................\n", info.Request.GameId, info.UserId);
            info.Continue(); // same as base.OnCreateGame(info);

            playerScores.Add(info.UserId, 0);
           
        }
        Dictionary<byte, object> sendInfo = new Dictionary<byte, object>();
        public override void OnRaiseEvent(IRaiseEventCallInfo info)
        {
          
            if (info.Request.EvCode == 5)
            {
                string playerId = info.UserId;
                int points = (int)info.Request.Data;
                this.pluginLogger.InfoFormat("{0} -Raisevent data", points);
                if (!playerScores.ContainsKey(playerId))
                {
                    playerScores[playerId] = 0;
                }

                playerScores[playerId] += points;
                this.sendInfo[(byte)0] = (object)playerScores[playerId];
                
                Dictionary<byte, object> sendInfo= new Dictionary<byte, object>();
                //sendInfo.Add(101, "Player" + info.ActorNr + "SendDAta");
                
                this.PluginHost.BroadcastEvent((byte) 0, (byte)0, (byte)0, (byte)12, this.sendInfo, (byte)0);
                
                //BroadcastEvent(10, sendInfo);
            }
        }

    }
}
