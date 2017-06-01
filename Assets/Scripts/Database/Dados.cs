using System;
using System.Collections;
using System.Collections.Generic;

[Serializable ()]
public class Dados {


    private Coach jogador;

    private DateTime actualDay;
    private List<League> ligas; //Todas as Ligas Disponiveis
    public List<Team> times; //Todos os times Disponiveis;

    public Dados()
    {
        actualDay = DateTime.Parse("2017-01-29");
        ligas = new List<League>();

    }

    public List<League> getLigas() { return ligas; }
    public DateTime getDay() { return actualDay; }

    public void nextDay()
    {
        actualDay.AddDays(1);
    }



    public void addLeague(League l)
    {
        ligas.Add(l);
    }

    public void setTimes(List<Team> times) { this.times = times; }

    public Coach getJogador() { return jogador; }
    public void setJogador(Coach j) { jogador = j; }

}
