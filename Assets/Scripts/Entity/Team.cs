using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable()]
public class Team {
    private string name;
    private List<Player> players;
    private Bank bank;
    private Player[] titulares;
    private Player[] reservas;

    public Team()
    {
    }

    public Team (string nome, List<Player> jogadores, Bank banco)
    {
        this.name = nome;
        this.players = jogadores;
        this.bank = banco;
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

}
