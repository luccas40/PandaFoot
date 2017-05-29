using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class League {

    private string nome;
    private Dictionary<DateTime, Match> diaPartidas;
    private List<Team> participantes;
    private Match m;


    public League(string nome)
    {
        this.nome = nome;
        diaPartidas = new Dictionary<DateTime, Match>();
        participantes = new List<Team>();
    }




    public void gerarConfrontos()
    {
        Team team1 = new Team("Time1", new List<Player>(), new Bank());
        Team team2 = new Team("Time2", new List<Player>(), new Bank());

        Team team3 = new Team("Time3", new List<Player>(), new Bank());
        Team team4 = new Team("Time4", new List<Player>(), new Bank());

        Match ma = new Match();
        ma.addConfronto(team1, team2);
        ma.addConfronto(team3, team4);
        diaPartidas.Add(new DateTime(), ma);

    }


    public void prepareMatches(DateTime dia)
    {
        m = diaPartidas[dia];
    }

    public void playMatches(int minute)
    {
        m.actMatches(minute);
    }




}
