using PwndaGames.PandaFoot.Model;
using PwndaGames.PandaFoot.Model.Abstract;
using PwndaGames.PandaFoot.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;

namespace PwndaGames.PandaFoot.Database
{
    [Serializable()]
    public class Dados
    {

        [NonSerialized]
        public static Dados me;

        [NonSerialized]
        public Coach temporaryJogador;

        public string saveLocation;
        private Coach jogador;

        private DateTime actualDay;
        private Dictionary<DateTime, Dia> calendarioDeJogos;
        private List<AbstractChampionship> campeonatos; //Todas as Ligas Disponiveis
        private Dictionary<int, Team> times; //Todos os times Disponiveis;

        public Dictionary<int, Team> Times { get { return times; }
                                             set { foreach (Team t in value.Values) if (!times.ContainsKey(t.ID)) times.Add(t.ID, t); } }
        public List<AbstractChampionship> Campeonatos { get { return campeonatos; } set { value.ForEach(c => campeonatos.Add(c)); } }
        public Dictionary<DateTime, Dia> Calendario { get { return calendarioDeJogos; } }
        public DateTime DiaAtual { get { return actualDay; } }

        public Dados()
        {
            actualDay = DateTime.Parse("2017-05-01");
            calendarioDeJogos = new Dictionary<DateTime, Dia>();
            campeonatos = new List<AbstractChampionship>();
            times = new Dictionary<int, Team>();

        }

        

        public void nextDay()
        {
            actualDay = actualDay.AddDays(1);
        }

        public void gerarCalendario()
        {
            foreach (AbstractChampionship ac in campeonatos)
            { 
                ac.gerarConfrontos();
                foreach (Round r in ac.diaPartidas.Values)
                {
                    if (calendarioDeJogos.ContainsKey(r.Dia))
                        calendarioDeJogos[r.Dia].addRound = r;
                    else {
                        Dia d = new Dia();
                        d.addRound = r;
                        d.Tipo = DiaType.Partida;
                        calendarioDeJogos.Add(r.Dia, d);
                    }
                }
            }
            

        }

        public List<Round> getRounds()
        {
            return calendarioDeJogos[actualDay].Rounds;
        }

        public Coach getJogador() { return jogador; }
        public void setJogador(Coach j) { jogador = j; times[j.Time.ID].setCoach(ref jogador); }

    }
}
