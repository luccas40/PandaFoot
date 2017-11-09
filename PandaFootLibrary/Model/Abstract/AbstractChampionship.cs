using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PwndaGames.PandaFoot.Model.Abstract
{
    [Serializable]
    public abstract class AbstractChampionship
    {

        protected string nome;
        public Dictionary<int, Round> diaPartidas;
        protected List<int> participantes;
        protected DateTime startDate;
        protected int roundNumber;


        public List<int> Participantes { get { return participantes; } }
        public string Nome { get { return nome; } }

        public AbstractChampionship(string nome, DateTime startDate)
        {
            this.nome = nome;
            this.roundNumber = 0;
            diaPartidas = new Dictionary<int, Round>();
            participantes = new List<int>();
            this.startDate = startDate;
        }

        public abstract void gerarConfrontos();

        public void setParticipantes(List<int> p) { this.participantes = p; }

        public void prepareMatches(DateTime dia)
        {

        }











    }
}
