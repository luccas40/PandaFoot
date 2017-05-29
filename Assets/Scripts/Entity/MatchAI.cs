using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchAI  {

    private Team team1;
    private Team team2;

    public MatchAI(Team team1, Team team2)
    {
        this.team1 = team1;
        this.team2 = team2;
    }



    public void acontecerMinuto(int minuto)
    {

        Debug.Log("Nada aconteceu ( " + team1.getName() + " ) vs ( " + team2.getName() + " ) Minuto: " + minuto);

    }
}
