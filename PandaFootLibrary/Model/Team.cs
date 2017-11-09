using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable()]
public class Team {

    private int id;
    private string name;
    private string miniName;
    private List<Player> players;
    private Bank bank;
    private Player[] titulares;
    private Player[] reservas;
    private string colorRGB;
    private double reputation;


    public int ID { get{ return this.id; } }
    public string Nome { get { return name; } }
    public Bank Banco { get { return bank; } }

    private Coach coach;
    private string nation;


    public Team()
    {
    }

    public Team (int id, string nome, string miniName, List<Player> jogadores, Bank banco, string cor, Coach coach, string nation, double reputation)
    { 
        this.id = id;
        this.name = nome;
        this.miniName = miniName;
        this.players = jogadores;
        this.bank = banco;
        this.colorRGB = cor;
        this.coach = coach;
        this.nation = nation;
        this.reputation = reputation;
    }


    public List<Player> getPlayers()
    {
        return players;
    }

    public Bank getBank()
    {
        return bank;
    }

    public void setCoach(ref Coach c)
    {
        this.coach = c;
    }



}
