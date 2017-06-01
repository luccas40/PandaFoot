using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable()]
public class MatchAI  {

    private Team team1;
    private Team team2;

    [NonSerialized]
    Text team1Name;
    [NonSerialized]
    Text team2Name;
    [NonSerialized]
    Text vs;

    private int team1Gol;
    private int team2Gol;

    public MatchAI(Team team1, Team team2)
    {
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

        team1Name.text = team1.getName();
        team2Name.text = team2.getName();

    }

    private void updateScore()
    {
        vs.text = team1Gol + " vs " + team2Gol;
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
        
        

    }
}
