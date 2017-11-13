using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable()]
public class Team {

    private int id;
    private string name;
    private string miniName;
    private string imgName;
    private List<Player> players;
    private List<Player> academia;
    private Bank bank;
    private Player[] titulares;
    private Player[] reservas;
    private string colorRGB;
    private double reputation;


    public int ID { get{ return this.id; } }
    public string Nome { get { return name; } }
    public string Logo { get { return imgName; } }
    public Bank Banco { get { return bank; } }
    public List<Player> Jogadores { get { return players; } }
    public List<Player> Academia { get { return academia; } }

    private Coach coach;
    private string nation;


    public Team()
    {
    }

    public Team (int id, string nome, string miniName, List<Player> players, List<Player> academia, Bank banco, string cor, Coach coach, string nation, double reputation, string imgName)
    { 
        this.id = id;
        this.name = nome;
        this.miniName = miniName;
        this.players = players;
        this.academia = academia;
        this.bank = banco;
        this.colorRGB = cor;
        this.coach = coach;
        this.nation = nation;
        this.reputation = reputation;
        this.imgName = imgName;
    }


    public void setCoach(ref Coach c)
    {
        this.coach = c;
    }



}
