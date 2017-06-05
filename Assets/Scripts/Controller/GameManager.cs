using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


    private string saveData;
    private bool newGame;

    public GameObject[] panes;
    public Text[] savesText;

    public InputField nomeTecnico;


    // Use this for initialization
    void Start () {

        //ConvertDados convert = new ConvertDados();
        //convert.ConvertToTeam("module", "brazil.bin");

        
        DontDestroyOnLoad(this);
        
        //carregar savess
        carregarSaves();
        loadButton(0);
    }
	
    public void jogar() {
        string name = nomeTecnico.text;
        if (!"".Equals(name))
        {
            saveData = name + ".ide";
            newGame = true;
            StartCoroutine(loadLevel());
        }
                
    }

    public void carregar(Text saveName)
    {
        if (!"Vazio".Equals(saveName.text))
        {
            saveData = saveName.text + ".ide";
            newGame = false;
            StartCoroutine(loadLevel());
        }
    }


    public void loadButton(int i)
    {
        foreach (GameObject o in panes)
            o.SetActive(false);
        if (i < 4)
            panes[i].SetActive(true);
        else
            Application.Quit();
    }


    IEnumerator loadLevel()
    {
        AsyncOperation o = SceneManager.LoadSceneAsync("TeamLevel");
        yield return new WaitForSeconds(3);
        while (!o.isDone)
            yield return null;
    }

    public string getSaveData(){ return saveData; }
    public bool getNewGame() { return newGame; }

    public void carregarSaves()
    {
        
        DirectoryInfo Dir = new DirectoryInfo(@Application.persistentDataPath+ "/save");
        FileInfo[] Files = Dir.GetFiles("*.ide", SearchOption.AllDirectories);
        int i = 0;
        foreach (FileInfo File in Files)
        {
            if (i >= 5) break;

            savesText[i].text = Path.GetFileNameWithoutExtension(File.Name);
            i++;
        }

    }

}
