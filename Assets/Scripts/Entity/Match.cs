﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Match {


    private List<MatchAI> partidas;

    public Match()
    {
        this.partidas = new List<MatchAI>();
    }

    public void addConfronto(Team time1, Team time2)
    {
        partidas.Add(new MatchAI(time1, time2));
    }

    public void actMatches(int i)
    {
        foreach (MatchAI m in partidas)
        {
            m.acontecerMinuto(i);
        }
    }


}
