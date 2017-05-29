using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class GameController : MonoBehaviour {


    List<League> ligas;

	
	void Start () {
        ligas = new List<League>();
        League t = new League("Torneio 1");
        t.gerarConfrontos();
        t.prepareMatches(new DateTime());

        ligas.Add(t);
        startNextMatches();
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void startNextMatches()
    {
        StartCoroutine(matchMinuteByMinute(0, 1f/Const.Speed));
    }


    IEnumerator matchMinuteByMinute(int minute, float speed)
    {
        foreach(League l in ligas)
        {
            l.playMatches(minute);
        }


        minute++;
        yield return new WaitForSeconds(speed);
        if(minute <= 90) {
            StartCoroutine(matchMinuteByMinute(minute, speed));
        }else
        {
            //Partida Acabou / next Day
        }
        
    }



}
