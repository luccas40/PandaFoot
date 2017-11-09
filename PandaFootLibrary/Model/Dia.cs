using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using PwndaGames.PandaFoot.Util;

namespace PwndaGames.PandaFoot.Model
{ 
    [Serializable]
    public class Dia
    {


        private List<Round> rounds;
        private DiaType tipo;
       
        public DiaType Tipo { get { return tipo; } set { tipo = value; } }
        public List<Round> Rounds { get { return rounds; } set { rounds.AddRange(value); } }
        public Round addRound { set { rounds.Add(value); } }
        public DateTime data { get { return rounds[0].Dia; } }

        public Dia() {
            rounds = new List<Round>();
            tipo = DiaType.None;
        }

        
    }
}