using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PwndaGames.PandaFoot.Util { 
    public enum RoundState
    {
        None,
        Idle,
        Running,
        Ended
    }

    public enum DiaType
    {
        None,
        Partida,
        Transferencia
    }

    public enum GameControl
    {
        None,
        Idle,
        Simulating
    }

    public enum MatchState
    {
        Running,
        Paused,
        Ended
    }

    public enum MatchTempo
    {
        Tempo_1,
        Tempo_2
    }

    public enum PlayerPosition
    {
        GK,
        LE,
        ZG,
        LD,
        VOL,
        ME,
        MD,
        MA,
        ALE,
        ALD
    }


}
