using UnityEngine;
using PwndaGames.PandaFoot.Util;

public class F442 : Formation
{
    public F442()
    {
        PlayerPosition[] defense = { PlayerPosition.LE, PlayerPosition.ZG, PlayerPosition.ZG, PlayerPosition.LD };
        PlayerPosition[] midfield = { PlayerPosition.VOL, PlayerPosition.VOL, PlayerPosition.MO, PlayerPosition.MO };
        PlayerPosition[] attack = { PlayerPosition.CA, PlayerPosition.CA };

        super(defense, midfield, attack);
    }
}