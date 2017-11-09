using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using PwndaGames.PandaFoot.Util;

[Serializable()]
public class Match  {

    [NonSerialized]
    Text team1Name;
    [NonSerialized]
    Text team2Name;
    [NonSerialized]
    Text vs;

    private int intervalCount;
    private int intervalActual;

    private MatchState state;
    public MatchState State { get { return state; } }

    private Team team1;
    private Team team2;

    private int team1Gol;
    private int team2Gol;

    public Match(Team team1, Team team2)
    {
        state = MatchState.Running;
        this.team1 = team1;
        this.team2 = team2;
        team1Gol = 0;
        team2Gol = 0;
    }

    public void setMatchObj(GameObject obj)
    {
        Text[] matchObj = obj.GetComponentsInChildren<Text>();
        team1Name = matchObj[0];
        vs = matchObj[1];
        team2Name = matchObj[2];

        team1Name.text = team1.Nome;
        team2Name.text = team2.Nome;
        intervalCount = 0;
        intervalActual = 0;

    }

    private void updateScore()
    {
        vs.text = team1Gol + " vs " + team2Gol;
    }

    public void proximoTempo()
    {
        state = MatchState.Running;
        intervalCount = 0;
        intervalActual = 0;
    }



    public void acontecerMinuto(int minuto)
    {


        int tmp = UnityEngine.Random.Range(1, 100);
        if(tmp <= 5)
        {
            tmp = UnityEngine.Random.Range(1, 3);
            if(tmp == 1)
            {
                team1Gol++;
            }
            else
            {
                team2Gol++;
            }
            updateScore();
        }


#region Estrutura_de_acrescimo
        if(minuto == 45 || minuto == 90)
        {
            if (intervalCount == 0)
                intervalCount = UnityEngine.Random.Range(1, 5);
            else
                intervalActual++;
        }

        if (intervalActual == intervalCount && intervalCount > 0)
        {
            state = MatchState.Paused;
            if(minuto == 90)
            {
                state = MatchState.Ended;
            }
        }
#endregion

    }
}
