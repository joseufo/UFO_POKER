using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Photon.Hive.Plugin;

namespace PokerPlugin
{
    // Poker Server be
    public class PokerPlugin : PluginBase
    {

        public override string Name => "PokerPlugin";

        PokerEval PokEval = new PokerEval();

        private Dictionary<int, PlayerData> DRoomPlayersData = new Dictionary<int, PlayerData>();

        private Dictionary<string, int> playerScores = new Dictionary<string, int>();
        Dictionary<byte, object> generalData = new Dictionary<byte, object>();

        float smallBlindAmount, bigBlindAmount, maxRaiseAmount, currentBetAmount;

        private IPluginLogger pluginLogger;

        private object startGameTimer;
        private int roomTotalPlayers = 0, roundPlayerCount = 0;
        private int initStartTime = 7000; //60000
        //private IPluginHost pluginHost;
        const int maxPlayers = 5, minPlayers = 2;

        // to clients-
        const byte INITSEAT = 51, SEATPLAYER = 55, TIMERGAMESTART = 101, ROUNDSTART = 103, TURNSTART = 105, SWITCHTURN = 115,
            FLOPCARDS = 121, TURNCARD = 122, RIVERCARD = 123, ROUNDEND = 125;
        //to server
        const byte PLACEBET = 20, ACCEPTBET = 22, CHECK = 23, FOLD = 25;

        private bool gameStarted = false, roundInProgress = false;

        private IList<int> currentRoundActors = (IList<int>)new List<int>();


        List<PlayerData> currentRoundPlayers = new List<PlayerData>();
        public override bool SetupInstance(IPluginHost host, Dictionary<string, string> config, out string errorMsg)
        {

            this.pluginLogger = host.CreateLogger(this.Name);

            return base.SetupInstance(host, config, out errorMsg);

        }

        float m_timeStamp;

        SerializableGameState photonGameState = new SerializableGameState();
        string roomID;
        //AvlSeat - Available Seat 0 to 4
        List<int> AvlSeats = new List<int> { 0, 1, 2, 3, 4 };
        public override void OnCreateGame(ICreateGameCallInfo info)
        {
            this.PluginHost.TryRegisterType(typeof(CardData), (byte)1, SerializeCardData, DeserializeCardData);
            this.PluginHost.SetProperties(0, new Hashtable() { { (object)"AvlSeat", (object)0 } }, (Hashtable)null, true);
            //this.smallBlindAmount = float.Parse(info.Request.GameProperties[(object)"smallBlind"].ToString());
            smallBlindAmount = 1; bigBlindAmount = 2;
            roomID = info.Request.GameId;
            //this.PluginHost.SetProperties(0, new Hashtable() { { (object)"BeginTime", (object)-1 } }, (Hashtable)null, true);
            info.Continue(); // same as base.OnCreateGame(info);
            IList<IActor> currentActors = this.PluginHost.GameActors;
            this.pluginLogger.InfoFormat("\n\n OnCreateGame {0} by user {1} - \n Actor-{2}, Name: {3}  \n...................\n", info.Request.GameId, info.UserId, currentActors[0].ActorNr, currentActors[0].Nickname);


            photonGameState = PluginHost.GetSerializableGameState();
            //photonGameState.EmptyRoomTTL = 600000;
            photonGameState.PlayerTTL = 30000;
            photonGameState.MaxPlayers = maxPlayers;
            //playerScores.Add(info.UserId, 0);           

            //this.roomSize = int.Parse(info.Request.GameProperties[(object)"roomSize"].ToString());
            RegPlayer(currentActors[0]);
        }

        public override void OnJoin(IJoinGameCallInfo info)
        {

            info.Continue();

            this.pluginLogger.InfoFormat("\n\n PLAYER_JOINED, in {0} - user {1} \n...................\n", info.Request.GameId, info.UserId);
            IActor actor = GetActor(info.ActorNr);
            if (!DRoomPlayersData.ContainsKey(info.ActorNr))
                RegPlayer(actor);
        }

        public override void OnLeave(ILeaveGameCallInfo info)
        {
            //base.OnLeave(info);
            info.Continue();
            this.pluginLogger.InfoFormat("\n PLAYER_LEFT, froom {0},  Actor: {1} - Name : {2} \n..........30 sec Removal\n", roomID, info.ActorNr, info.Nickname);

        }

        public int currentPlayerTurn = 0;
        private void RegPlayer(IActor actorPlayer)
        {
            if (DRoomPlayersData.ContainsKey(actorPlayer.ActorNr)) return;
            currentSeatPos = AvlSeats[0]; AvlSeats.Remove(currentSeatPos);
            PlayerData tPlayerData = new PlayerData();
            tPlayerData.playerName = actorPlayer.Nickname;
            tPlayerData.playerPosition = currentSeatPos;
            tPlayerData.playerActorNo = actorPlayer.ActorNr;
            //IActor actorPlayer = GetActor(info.ActorNr);
            actorPlayer.Properties.SetProperty((object)"SeatPos", (object)currentSeatPos);
            DActorPositon[actorPlayer.ActorNr] = currentSeatPos;

            IList<int> tempPlayerList = new List<int>();
            foreach (var actorKey in DRoomPlayersData.Keys)
            {
                tempPlayerList.Add(actorKey);
            }
            this.generalData[(byte)0] = currentSeatPos;
            this.generalData[(byte)1] = actorPlayer.ActorNr;
            this.generalData[(byte)2] = DActorPositon;
            this.PluginHost.BroadcastEvent(tempPlayerList, 0, SEATPLAYER, this.generalData, (byte)0);
            tempPlayerList.Clear();

            DRoomPlayersData.Add(actorPlayer.ActorNr, tPlayerData);

            tempPlayerList.Add(actorPlayer.ActorNr);
            //this.generalData[(byte)1] = DActorPositon;
            this.PluginHost.BroadcastEvent(tempPlayerList, 0, INITSEAT, this.generalData, (byte)0);


            //foreach (IActor gameActor in this.PluginHost.GameActors)
            //{

            //}

            roomTotalPlayers = PluginHost.GameActors.Count;
            if (roundInProgress)
                return;


            if (!gameStarted && roomTotalPlayers >= minPlayers)
            {
                this.generalData.Clear();
                m_timeStamp = (float)Environment.TickCount; //[PhotonNetwork.ServerTimestamp]
                this.generalData[(byte)2] = (object)(m_timeStamp);
                this.generalData[(byte)3] = (m_timeStamp + initStartTime);
                if (this.PluginHost.GameProperties[(object)"BeginTime"] == null)
                    this.PluginHost.SetProperties(0, new Hashtable() { { (object)"BeginTime", (m_timeStamp + initStartTime) } }, (Hashtable)null, true);

                this.PluginHost.BroadcastEvent((byte)0, 0, (byte)0, TIMERGAMESTART, this.generalData, (byte)0);
                //this.startGameTimer = this.PluginHost.CreateTimer(new Action(this.StartGame), 20000, 500);
                if (!timerStarted)
                    this.startGameTimer = this.PluginHost.CreateOneTimeTimer(null, new Action(this.PokerStartTimer), initStartTime);

                //this.PluginHost.BroadcastEvent((byte)0, (byte)0, (byte)0, STARTGAME, this.sendInfo, (byte)0);

            }
        }
        int roundCount;

        List<Card> currentRoundCard = new List<Card>();
        List<Card> TableCards = new List<Card>();
        bool timerStarted;
        private void PokerStartTimer()
        {
            timerStarted = true;
            this.PluginHost.StopTimer(this.startGameTimer);
            if (roundInProgress) return;
            StartPokerRound();
        }
        class PotData
        {
            public float PotAmount;
            public List<PlayerData> PotPlayers;
        }
        PotData MainPot = new PotData();
        List<PotData> SidePots = new List<PotData>();
        int dealerIndex=-1, smallBlindIndex, bigBlindIndex;
        private void StartPokerRound()
        {
            this.pluginLogger.InfoFormat("\n PokerRound Started {0}  \n", roundCount++);
            roundInProgress = true;
            this.currentRoundCard = InitCardsAndShuffle();
            string tableCardString = "";
            for (int i = 0; i < 5; i++)
            {
                var card = TakeCardFromDeck(ref currentRoundCard);
                tableCardString += card + ", ";
                TableCards.Add(card);
            }
            this.pluginLogger.InfoFormat("\n Table Cards {0},   \n", tableCardString);

            currentRoundPlayers.Clear();
            foreach (var actor in DRoomPlayersData.Keys)
            {
               
                currentRoundActors.Add(actor);

                currentRoundPlayers.Add(DRoomPlayersData[actor]);
                var playerData = DRoomPlayersData[actor];

                playerData.card1 = TakeCardFromDeck(ref currentRoundCard);
                playerData.card2 = TakeCardFromDeck(ref currentRoundCard);
                
                //Dictionary<int, int> suitvalue = new Dictionary<int, int>();
                //suitvalue[playerData.card1data.suit] = playerData.card1data.rank; suitvalue[playerData.card2data.suit] = playerData.card2data.rank;
                int[] playerCardData = new int[4]; playerCardData[0] = playerData.card1.suit; playerCardData[1] = playerData.card1.rank; playerCardData[2] = playerData.card2.suit; playerCardData[3] = playerData.card2.rank;
                this.generalData[(byte)1] = currentRoundPlayers[0].playerActorNo;

                this.generalData[(byte)2] = playerCardData;
                this.generalData[(byte)3] = playerData.card1.cardData;
               
            }
            int indexCount = currentRoundPlayers.Count;
            dealerIndex = (dealerIndex + 1) % indexCount;
            smallBlindIndex = currentRoundPlayers.Count>2 ? (dealerIndex + 1) % indexCount : dealerIndex; 
            bigBlindIndex = (smallBlindIndex + 1) % indexCount;
            currentPlayerTurn = (bigBlindIndex + 1)% indexCount;
            this.pluginLogger.InfoFormat("\n DealerIndex: {0} , SBlindIndex: {1} , BBlindIndex: {2}   \n", dealerIndex, smallBlindIndex, bigBlindIndex);
            this.generalData[(byte)0] = currentRoundActors[dealerIndex]; this.generalData[(byte)1] = currentRoundActors[smallBlindIndex]; this.generalData[(byte)2] = currentRoundActors[bigBlindIndex];
            this.PluginHost.BroadcastEvent(currentRoundActors, 0, ROUNDSTART, this.generalData, (byte)0);
           
            this.delayTimer = this.PluginHost.CreateOneTimeTimer(null, new Action(this.TurnStartCardCast), 2);
            //this.PluginHost.BroadcastEvent(temPlayer, 0, SWITCHTURN, this.generalData, (byte)0);
            //this.PluginHost.BroadcastEvent((byte)0, 0, (byte)0, ROUNDSTART, this.generalData, (byte)0);
            //this.PluginHost.BroadcastEvent(currentRoundPlayers, 0, ROUNDSTART, this.generalData, (byte)0);
            //autoTimer = this.PluginHost.CreateTimer(new Action(this.AutoPlay), 500, 500);
        }
        object delayTimer;
        
        private void TurnStartCardCast()
        {
            this.PluginHost.StopTimer(delayTimer);
            foreach (var actor in DRoomPlayersData.Keys)
            {
                IList<int> temPlayer = new List<int>() { actor };
                
                var playerData = DRoomPlayersData[actor];

                playerData.card1 = TakeCardFromDeck(ref currentRoundCard);
                playerData.card2 = TakeCardFromDeck(ref currentRoundCard);
                this.pluginLogger.InfoFormat("\n ActorPlayer {0} Cards: {1}, {2}   \n", actor, playerData.card1, playerData.card2);
                //Dictionary<int, int> suitvalue = new Dictionary<int, int>();
                //suitvalue[playerData.card1data.suit] = playerData.card1data.rank; suitvalue[playerData.card2data.suit] = playerData.card2data.rank;
                int[] playerCardData = new int[4]; playerCardData[0] = playerData.card1.suit; playerCardData[1] = playerData.card1.rank; playerCardData[2] = playerData.card2.suit; playerCardData[3] = playerData.card2.rank;
                this.generalData[(byte)1] = currentRoundPlayers[currentPlayerTurn].playerActorNo;

                this.generalData[(byte)2] = playerCardData;
                this.generalData[(byte)3] = playerData.card1.cardData;
                this.PluginHost.BroadcastEvent(temPlayer, 0, TURNSTART, this.generalData, (byte)0);
            }
            
        }

        private void EndPokerRound()
        {
            Dictionary<int, int[]> allPlayerCards = new Dictionary<int, int[]>();
            foreach (var player in currentRoundPlayers)
            {
                int[] playerCards = new int[4];
                playerCards[0] = player.card1.suit; playerCards[1] = player.card1.rank; playerCards[2] = player.card2.suit; playerCards[3] = player.card2.rank;
                allPlayerCards.Add(player.playerActorNo, playerCards);
            }
            this.generalData[(byte)0] = allPlayerCards;
            this.PluginHost.BroadcastEvent(currentRoundActors, 0, ROUNDEND, this.generalData, (byte)0);
            roundInProgress = false;
            pokerPhase = 0;

            this.pluginLogger.InfoFormat("\n PokerRound END  \n");
            this.currentRoundCard.Clear();
            foreach (var player in currentRoundPlayers)
            {
                //this.pluginLogger.InfoFormat("{0} Cards: {1} , {2}  \n", player.playerName, player.card1data, player.card2data);
                player.completeEvalData = PokEval.EvaluatePlayerRanks(player, TableCards);
            }
            List<PlayerData> RoundWinners = PokEval.FindPokerPotWinners(currentRoundPlayers);
            this.pluginLogger.InfoFormat("RoundWinner(s): {0}  \n", PokEval.ResultText);
            TableCards.Clear();
            currentRoundPlayers.Clear();
            currentRoundActors.Clear();
            this.generalData.Clear();


            //next round timer
            m_timeStamp = (float)Environment.TickCount; //[PhotonNetwork.ServerTimestamp]
            this.generalData[(byte)2] = (object)(m_timeStamp);
            this.generalData[(byte)3] = (m_timeStamp + initStartTime);

            this.PluginHost.SetProperties(0, new Hashtable() { { (object)"BeginTime", (m_timeStamp + initStartTime) } }, (Hashtable)null, true);

            this.PluginHost.BroadcastEvent((byte)0, 0, (byte)0, TIMERGAMESTART, this.generalData, (byte)0);
            //this.startGameTimer = this.PluginHost.CreateTimer(new Action(this.StartGame), 20000, 500);

            this.startGameTimer = this.PluginHost.CreateOneTimeTimer(null, new Action(this.PokerStartTimer), initStartTime);


        }


        object autoTimer;
        void AutoPlay()
        {
            int sendActor = currentPlayerTurn;
            this.PluginHost.BroadcastEvent(0, sendActor, 0, CHECK, this.generalData, (byte)0);
            currentPlayerTurn++;
            if (pokerPhase > 3)
            {
                EndPokerRound();
                this.PluginHost.StopTimer(autoTimer);
            }
        }
        int currentSeatPos = -1;
        Dictionary<int, int> DActorPositon = new Dictionary<int, int>();
        int pokerPhase = 0;
        public override void OnRaiseEvent(IRaiseEventCallInfo info)
        {

            if (info.Request.EvCode == CHECK)
            {

                int playerIndex = currentPlayerTurn;
                this.pluginLogger.InfoFormat("\n Check called by Actor {0} - {1} -CHECK, CurrentPlayerIndex {2} \n....\n RoundPlayercount:- {3}..\n", info.ActorNr, info.Nickname, currentPlayerTurn, DRoomPlayersData[currentRoundActors[currentPlayerTurn]].playerName, currentRoundPlayers.Count);
                if (info.ActorNr != currentRoundActors[playerIndex]) return;
                bool cycleComplete = true;
                currentRoundPlayers[playerIndex].turnComplete = true;
                foreach (var player in currentRoundPlayers) { if (!player.turnComplete) cycleComplete = false; }
                //bool cycleComplete = currentPlayerTurn % currentRoundActors.Count == 0 ? true : false;
                //playerTurnIndex++;
                currentPlayerTurn = (currentPlayerTurn + 1) % currentRoundActors.Count;
                playerIndex = currentPlayerTurn;
                this.pluginLogger.InfoFormat("\n PlayerCount: {0}  \n", currentRoundPlayers.Count);
                if (cycleComplete) //currentPlayerTurn >= (currentRoundPlayers.Count-1
                {
                    foreach (var player in currentRoundPlayers) player.turnComplete = false;
                    //currentPlayerTurn = 1;
                    pokerPhase++;
                    if (pokerPhase > 3)
                    {
                        EndPokerRound();
                    }
                    else
                        SendTableCardsToPlayers(pokerPhase);
                }

                if (!roundInProgress) return;
                this.generalData[(byte)0] = null;
                this.generalData[(byte)2] = currentRoundPlayers[playerIndex].playerActorNo;// this.generalData[(byte)1] = currentRoundActors[currentPlayerTurn];
                this.PluginHost.BroadcastEvent(currentRoundActors, 0, SWITCHTURN, this.generalData, (byte)0);
                //SendTableCardsToPlayers(pokerPhase);
            }
            if (info.Request.EvCode == FOLD)
            {
                int playerIndex = currentPlayerTurn - 1;
                this.pluginLogger.InfoFormat("\n Fold called by Actor {0} - {1} -FOLD, CurrentPlayerTurn {2} \n....\n RoundPlayercount:- {3}..\n", info.ActorNr, info.Nickname, currentPlayerTurn, DRoomPlayersData[currentRoundActors[currentPlayerTurn - 1]].playerName, currentRoundPlayers.Count);
                if (info.ActorNr != currentRoundActors[playerIndex]) return;


                currentRoundActors.Remove(DRoomPlayersData[info.ActorNr].playerActorNo);
                currentRoundPlayers.Remove(DRoomPlayersData[info.ActorNr]);

                //bool cycleComplete = currentPlayerTurn % currentRoundActors.Count == 0 ? true : false;
                bool cycleComplete = true;
                //currentRoundPlayers[playerIndex].turnComplete = true;
                foreach (var player in currentRoundPlayers)
                {
                    if (!player.turnComplete)
                    {
                        cycleComplete = false;
                        currentPlayerTurn = currentRoundPlayers.IndexOf(player) + 1;
                        break;
                    }
                }
                //currentPlayerTurn = (currentPlayerTurn % currentRoundActors.Count);

                this.pluginLogger.InfoFormat("\n PlayerCount: {0}  \n", currentRoundPlayers.Count);
                if (cycleComplete) //currentPlayerTurn > (currentRoundPlayers.Count)
                {
                    foreach (var player in currentRoundPlayers) player.turnComplete = false;
                    currentPlayerTurn = 1;
                    pokerPhase++;
                    if (pokerPhase > 3)
                    {
                        EndPokerRound();
                    }
                    else
                        SendTableCardsToPlayers(pokerPhase);
                }

                if (!roundInProgress) return;
                this.generalData.Clear();
                this.generalData[(byte)0] = info.ActorNr;
                playerIndex = currentPlayerTurn - 1;
                this.generalData[(byte)2] = currentRoundPlayers[playerIndex].playerActorNo; //this.generalData[(byte)3] = currentRoundActors[currentPlayerTurn];
                this.PluginHost.BroadcastEvent(currentRoundActors, 0, SWITCHTURN, this.generalData, (byte)0);

            }

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
                this.generalData[(byte)0] = (object)playerScores[playerId];

                Dictionary<byte, object> sendInfo = new Dictionary<byte, object>();
                //sendInfo.Add(101, "Player" + info.ActorNr + "SendDAta");

                this.PluginHost.BroadcastEvent((byte)0, (byte)0, (byte)0, (byte)12, this.generalData, (byte)0);

                //BroadcastEvent(10, sendInfo);
            }
        }
        private IActor GetActor(int x)
        {
            foreach (IActor gameActor in (IEnumerable<IActor>)this.PluginHost.GameActors)
            {
                if (gameActor.ActorNr == x)
                    return gameActor;
            }
            return (IActor)null;
        }
        void SendTableCardsToPlayers(int phase)
        {
            switch (phase)
            {
                case 1:
                    int[] cards = new int[6];
                    for (int i = 0; i < 3; i++)
                    {
                        cards[i] = TableCards[i].suit;
                        cards[i + 3] = TableCards[i].rank;
                    }
                    this.generalData[(byte)0] = (object)cards;
                    this.PluginHost.BroadcastEvent(currentRoundActors, 0, FLOPCARDS, this.generalData, (byte)0);
                    break;
                case 2:
                    int[] card4 = new int[2];
                    card4[0] = TableCards[3].suit;
                    card4[1] = TableCards[3].rank;
                    this.generalData[(byte)0] = card4;
                    this.PluginHost.BroadcastEvent(currentRoundActors, 0, TURNCARD, this.generalData, (byte)0);
                    break;
                case 3:
                    int[] card5 = new int[2];
                    card5[0] = TableCards[4].suit;
                    card5[1] = TableCards[4].rank;
                    this.generalData[(byte)0] = card5;
                    this.PluginHost.BroadcastEvent(currentRoundActors, 0, RIVERCARD, this.generalData, (byte)0);
                    break;


            }
        }




        public Card TakeCardFromDeck(ref List<Card> CardDeck)
        {
            var card = CardDeck[0];
            CardDeck.RemoveAt(0);
            return card;
        }
        //

        public List<Card> InitCardsAndShuffle()
        {

            //string cardDeckString = "";
            List<Card> CardDeck = new List<Card>();
            for (int s = 1; s <= 4; s++)
            {
                for (int r = 1; r <= 13; r++)
                {
                    var card = new Card(s, r);
                    CardDeck.Add(card);
                    //cardDeckString += card;
                }
            }
            //this.pluginLogger.InfoFormat("\n CARD DECK : {0} \n", cardDeckString);
            //foreach (SUIT suit in Enum.GetValues(typeof(SUIT)))
            //{

            //    foreach (VALUE value in Enum.GetValues(typeof(VALUE)))
            //    {
            //        //Deck[i] = new Card { Suit = suit, Value = value };
            //        //i++;
            //        CardDeck.Add(new Card(suit, value));


            //    }

            //}
            var rand = new System.Random();


            for (int i = CardDeck.Count - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                Card temp = CardDeck[i];
                CardDeck[i] = CardDeck[j];
                CardDeck[j] = temp;

            }
            //// Fisher-Yates shuffle
            //for (int i = CardDeck.Count - 1; i > 0; i--)
            //{
            //    int n = UnityEngine.Random.Range(0, i + 1);
            //    Card temp = CardDeck[i];
            //    CardDeck[i] = CardDeck[n];
            //    CardDeck[n] = temp;
            //}
            return CardDeck;

        }


        private byte[] SerializeCardData(object o)
        {
            CardData cardObject = o as CardData;
            if (cardObject == null) { return null; }
            using (var s = new MemoryStream())
            {
                using (var bw = new BinaryWriter(s))
                {
                    bw.Write(cardObject.suit);
                    bw.Write(cardObject.rank);
                    return s.ToArray();
                }
            }
        }
        private object DeserializeCardData(byte[] bytes)
        {
            CardData cardObject = new CardData();
            using (var s = new MemoryStream(bytes))
            {
                using (var br = new BinaryReader(s))
                {
                    cardObject.suit = br.ReadInt32();
                    cardObject.rank = br.ReadInt32();

                }
            }
            return cardObject;
        }




        /////PokerPlugin End
    }



    #region PokerCardLogic





    public enum PlayerRole
    {
        Dealer, SmallBlinder, Bigblinder
    }





    #endregion


}
