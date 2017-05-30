using System;
using System.Collections;
using System.Collections.Generic;

[Serializable ()]
public class Dados {

    private DateTime actualDay;
    private List<League> ligas;

    public Dados()
    {
        actualDay = new DateTime();
        ligas = new List<League>();

    }


    public List<League> getLigas() { return ligas; }
    public DateTime getDay() { return actualDay; }

    public void nextDay()
    {

    }

    public void addLeague(League l)
    {
        ligas.Add(l);
    }

}
