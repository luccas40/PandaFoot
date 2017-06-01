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

    private Text gameTimeTxt;
	
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
        StartCoroutine(waitLoadGameLevel());
        //SceneManager.LoadScene("GameLevel");
       /* foreach (League l in dados.getLigas())
        {
            l.prepareMatches(dados.getDay());
        }*/
        
       // StartCoroutine(matchMinuteByMinute(0, 1f/Const.Speed));
    }


    IEnumerator waitLoadGameLevel()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync("GameLevel");
        yield return new WaitForSeconds(.3f);
        while (!op.isDone)
            yield return null;
        gameTimeTxt = GameObject.Find("time").GetComponent<Text>();
        foreach (League l in dados.getLigas())
        {
            l.prepareMatches(dados.getDay());
        }
        StartCoroutine(matchMinuteByMinute(0, 1f / Const.Speed));
    }


    IEnumerator matchMinuteByMinute(int minute, float speed)
    {
        gameTimeTxt.text = "Tempo: " + minute;

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
            //Partida Acabou
        }
        
    }

    void loadNewGame() {
        dados = new Dados();
        try
        {
            using (Stream stream = File.Open(Application.persistentDataPath+"/data/brazil.bin", FileMode.Open))
            {
                BinaryFormatter bin = new BinaryFormatter();
                dados.setTimes((List<Team>)bin.Deserialize(stream));
            }
        }
        catch (IOException e) { Debug.Log("Erro no metodo loadNewGame  -  " + e);  }

        League t = new League("Torneio 1");
        t.setParticipantes(ref dados.times);
        t.gerarConfrontos();    
        dados.addLeague(t);
        
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
        catch (IOException) { /*voltar*/ }
    }


    public void saveGameData()
    {
        try {
            if (!Directory.Exists(Application.persistentDataPath + "/save"))
                Directory.CreateDirectory(Application.persistentDataPath + "/save");
            using (Stream stream = File.Open(saveData, FileMode.CreateNew))
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, dados);
            }
        }
        catch (IOException) { }
    }

}
