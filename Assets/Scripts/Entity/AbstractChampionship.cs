using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class AbstractChampionship {

    protected string nome;
    protected Dictionary<DateTime, Match> diaPartidas;
    protected List<Team> participantes;
    private Match m;
    protected DateTime startDate;


    public AbstractChampionship(string nome, DateTime startDate)
    {
        this.nome = nome;
        diaPartidas = new Dictionary<DateTime, Match>();
        participantes = new List<Team>();
        this.startDate = startDate;
    }

    public abstract void gerarConfrontos();

    public void setParticipantes(ref List<Team> p) { this.participantes = p; }

    public void prepareMatches(DateTime dia)
    {

        if (diaPartidas.ContainsKey(dia))
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
    }

    public void playMatches(int minute)
    {
        m.actMatches(minute);
    }











}
