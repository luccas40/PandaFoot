using System;
using System.Collections;
using System.Collections.Generic;

[Serializable ()]
public class Dados {


    private Coach jogador;

    private DateTime actualDay;
    private List<AbstractChampionship> campeonatos; //Todas as Ligas Disponiveis
    public List<Team> times; //Todos os times Disponiveis;

    public Dados()
    {
        actualDay = DateTime.Parse("2017-01-27");
        campeonatos = new List<AbstractChampionship>();

    }

    public List<AbstractChampionship> getChampionships() { return campeonatos; }
    public DateTime getDay() { return actualDay; }

    public void nextDay()
    {
        actualDay.AddDays(1);
    }



    public void addChampionship(AbstractChampionship l)
    {
        campeonatos.Add(l);
    }

    public void setTimes(List<Team> times) { this.times = times; }

    public Coach getJogador() { return jogador; }
    public void setJogador(Coach j) { jogador = j; }

}
