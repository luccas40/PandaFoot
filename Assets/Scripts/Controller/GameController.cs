using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


    GameManager manager;
    private Dados dados;
    private string saveData;
	
	void Start () {
        DontDestroyOnLoad(this);
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        saveData = Application.persistentDataPath + "/save/" + manager.getSaveData();
        
        if (!File.Exists(saveData)) loadNewGame();
        else loadSaveData();
        saveGameData();

        
    }

    public void startNextMatches()
    {
        SceneManager.LoadScene("GameLevel");
        StartCoroutine(matchMinuteByMinute(0, 1f/Const.Speed));
    }


    IEnumerator matchMinuteByMinute(int minute, float speed)
    {
        foreach(League l in dados.getLigas())
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

    void loadNewGame() { 
    
        League t = new League("Torneio 1");
        t.gerarConfrontos();
        t.prepareMatches(new DateTime());

        dados = new Dados();
        dados.addLeague(t);
        saveData += "save.ide";
        
    }

    void loadSaveData()
    {        
        try
        {
            using (Stream stream = File.Open(saveData, FileMode.Open))
            {
                BinaryFormatter bin = new BinaryFormatter();
                dados = (Dados)bin.Deserialize(stream);
            }
        }
        catch (IOException) { loadNewGame(); }
    }


    public void saveGameData()
    {
        try {
            if (!Directory.Exists(saveData.Replace("save.ide", "")))
                Directory.CreateDirectory(saveData.Replace("save.ide", ""));

            using (Stream stream = File.Open(saveData, FileMode.CreateNew))
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, dados);
            }
        }
        catch (IOException) { }
    }

}
