using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

[Serializable()]
public class League : AbstractChampionship
{
    public League(string nome, DateTime startDay) : base(nome, startDay)
    {
    }

    public override void gerarConfrontos()
    {

        bool frente = true;
        List<Team> ListTeam = new List<Team>(participantes);


        if (ListTeam.Count % 2 != 0)
        {
            ListTeam.Add(new Team());
        }

        int numDays = (participantes.Count - 1);
        int halfSize = participantes.Count / 2;

        List<Team> teams = new List<Team>();

        teams.AddRange(ListTeam);
        teams.RemoveAt(0);

        int teamsSize = teams.Count;

        DateTime diaCampeonato = startDate;

        for (int day = 0; day < numDays; day++)
        {
            Match m = new Match();
            int teamIdx = day % teamsSize;
            if (frente)
            {
                m.addConfronto(participantes[participantes.IndexOf(teams[teamIdx])], participantes[participantes.IndexOf(ListTeam[0])]);
                frente = false;
            }
            else
            {
                m.addConfronto(participantes[participantes.IndexOf(ListTeam[0])], participantes[participantes.IndexOf(teams[teamIdx])]);
                frente = true;
            }

            for (int idx = 1; idx < halfSize; idx++)
            {
                int firstTeam = (day + idx) % teamsSize;
                int secondTeam = (day + teamsSize - idx) % teamsSize;
                m.addConfronto(participantes[participantes.IndexOf(teams[firstTeam])], participantes[participantes.IndexOf(teams[secondTeam])]);
            }


            if (!diaPartidas.ContainsKey(diaCampeonato))
                diaPartidas.Add(diaCampeonato, m);
            diaCampeonato = diaCampeonato.AddDays(7);
        }

    }
}
