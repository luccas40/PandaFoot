using PwndaGames.PandaFoot.Database;
using PwndaGames.PandaFoot.Model.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using UnityEngine;

namespace PwndaGames.PandaFoot.Model
{
    [Serializable()]
    public class League : AbstractChampionship
    {
        public League(string nome, DateTime startDay) : base(nome, startDay)
        {
        }

        public override void gerarConfrontos()
        { //Round Robin Tournament
            DateTime diaCampeonato = startDate;
            List<int> ListTeam = new List<int>(participantes);

            if (ListTeam.Count % 2 != 0)
            {
                ListTeam.Add(-1);
            }

            int numDays = (ListTeam.Count - 1);
            int halfSize = ListTeam.Count / 2;

            List<int> teams = new List<int>();

            teams.AddRange(ListTeam);
            teams.RemoveAt(0);

            int teamsSize = teams.Count;

            for (int day = 0; day < numDays; day++)
            {
                Round r = new Round(day + 1, diaCampeonato);
                r.title = nome;

                int teamIdx = day % teamsSize;                
                r.addMatch(new Match(Dados.me.Times[teams[teamIdx]], Dados.me.Times[ListTeam[0]]));

                for (int idx = 1; idx < halfSize; idx++)
                {
                    int firstTeam = teams[(day + idx) % teamsSize];
                    int secondTeam = teams[(day + teamsSize - idx) % teamsSize];
                    r.addMatch(new Match(Dados.me.Times[firstTeam], Dados.me.Times[secondTeam]));
                }
                if (!diaPartidas.ContainsKey(day + 1))
                    diaPartidas.Add(day + 1, r);
                diaCampeonato = diaCampeonato.AddDays(7);
            }
        }
    }
}
