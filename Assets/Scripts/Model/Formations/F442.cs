using UnityEngine;
using UnityEditor;
using PwndaGames.PandaFoot.Util;

public class F442 : Formation
{
    public F442()
    {
        PlayerPosition[] defense = { PlayerPosition.LE, PlayerPosition.ZG, PlayerPosition.ZG, PlayerPosition.LD };
        PlayerPosition[] midfield = { PlayerPosition.VOL, PlayerPosition.VOL, PlayerPosition.MA, PlayerPosition.MA };
        PlayerPosition[] attack = { PlayerPosition.ALE, PlayerPosition.ALD };

        super(defense, midfield, attack);
    }
}