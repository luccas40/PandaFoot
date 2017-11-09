using UnityEngine;
using UnityEditor;
using PwndaGames.PandaFoot.Util;


public abstract class Formation
{

    protected PlayerPosition GKType;
    protected PlayerPosition[] DefenseType;
    protected PlayerPosition[] MidfieldType;
    protected PlayerPosition[] AttackType;

    protected Player GK;
    protected Player[] Defense;
    protected Player[] Midfield;
    protected Player[] Attack;



    protected void super(PlayerPosition[] defense, PlayerPosition[] midfield, PlayerPosition[] attack)
    {
        GKType = PlayerPosition.GK;
        this.DefenseType = defense;
        this.MidfieldType = midfield;
        this.AttackType = attack;
    }

    public void setGK(Player p) { GK = p; }
    public void setDefense(Player[] p) { Defense = p; }
    public void setMidfield(Player[] p) { Midfield = p; }
    public void setAttack(Player[] p) { Attack = p; }




}