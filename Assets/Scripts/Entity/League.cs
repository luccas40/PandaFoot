using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

[Serializable()]
public class League {

    private string nome;
    private Dictionary<DateTime, Match> diaPartidas;
    private List<Team> participantes;
    private Match m;


    public League(string nome)
    {
        this.nome = nome;
        diaPartidas = new Dictionary<DateTime, Match>();
        participantes = new List<Team>();
    }




    public void gerarConfrontos()
    {
        bool frente = true;
        foreach(Team t in participantes)
        {
            DateTime vix = DateTime.Parse("2017-01-29");

            if(frente)
                for(int i=0; i<participantes.Count; i++)
                {
                    
                    if (!diaPartidas.ContainsKey(vix))
                    {
                        diaPartidas.Add(vix, new Match());
                    }

                    if (!t.Equals(participantes[i]))
                    {                        
                        diaPartidas[vix].addConfronto(t, participantes[i]);                        
                    }
                    vix = vix.AddDays(7);
                    frente = false;
                }
            else
                for (int i = (participantes.Count-1); i >= 0 ; i--)
                {                    
                    if (!diaPartidas.ContainsKey(vix))
                        diaPartidas.Add(vix, new Match());
                    if (!t.Equals(participantes[i]))
                    {
                        diaPartidas[vix].addConfronto(t, participantes[i]);
                    }
                    vix = vix.AddDays(7);
                    frente = true;
                }

        }


    }

    public void setParticipantes(ref List<Team> p) { this.participantes = p; }


    public void prepareMatches(DateTime dia)
    {
        m = diaPartidas[dia];
        float YPOS = 400;
        foreach (MatchAI mai in m.getPartidas())
        {
            GameObject o = UnityEngine.Object.Instantiate(Resources.Load("Prefabs/Match"), new Vector3(0, YPOS, 0), new Quaternion()) as GameObject;
            o.transform.SetParent(GameObject.Find("Canvas/Panel").transform, false);
            YPOS -= 35;
            mai.setMatchObj(o);
        }
    }

    public void playMatches(int minute)
    {
        m.actMatches(minute);
    }




}
