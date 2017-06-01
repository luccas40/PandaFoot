using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable()]
public class Team {

    private string name;
    private string miniName;
    private List<Player> players;
    private Bank bank;
    private Player[] titulares;
    private Player[] reservas;
    private string colorRGB;
    private int levelTeam;


    private Coach coach;
    private string nation;


    public Team()
    {
    }

    public Team (string nome, string miniName, List<Player> jogadores, Bank banco, string cor, Coach coach, string nation, int level)
    {
        this.name = nome;
        this.miniName = miniName;
        this.players = jogadores;
        this.bank = banco;
        this.colorRGB = cor;
        this.coach = coach;
        this.nation = nation;
        this.levelTeam = level;
    }

    public string getName()
    {
        return name;
    }

    public List<Player> getPlayers()
    {
        return players;
    }

    public Bank getBank()
    {
        return bank;
    }

    public override bool Equals(object obj)
    {
        return name.Equals(((Team)obj).getName());
    }

    public override int GetHashCode()
    {
        return this.getName().GetHashCode();
    }

}
