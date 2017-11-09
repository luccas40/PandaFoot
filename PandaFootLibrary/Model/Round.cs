using PwndaGames.PandaFoot.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Round {

    private int id;
    private List<Match> matches;
    public string title;
    private DateTime dia;

    public int ID { get { return id; } }
    public List<Match> Matches { get { return matches; } set { matches = value; } }
    public DateTime Dia { get { return dia; } }

    public Round(int id, DateTime dia)
    {
        this.id = id;
        this.matches = new List<Match>();
        this.dia = dia;
    }

    public void addMatch(Match m)
    {
        matches.Add(m);
    }

    public void actMinute(int minute)
    {
        matches.FindAll(o => o.State == MatchState.Running).ForEach(o => o.acontecerMinuto(minute));
    }

    public void proximoTempo()
    {
        matches.ForEach(o => o.proximoTempo());
    }

    public bool isEnded()
    {
        return matches.All(o => o.State == MatchState.Ended);
    }

    public bool isPaused()
    {
        return matches.All(o => o.State == MatchState.Paused);
    }


}
