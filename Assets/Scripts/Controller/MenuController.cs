using PwndaGames.PandaFoot.Database;
using PwndaGames.PandaFoot.Util;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    public GameObject[] panes;
    public Text[] savesText;
    public InputField nomeTecnico;
    public Dropdown[] ligaTime;

    private object[] ob;
    private List<object[]> times;

    public LoadingSceneController sceneControl;

    void Start () {

        //carregar Lista de Saves
        ob = SaveGame.getMenuTeams();
        carregarDropdown();
        carregarSavesList();
        Dados.me = new Dados();
        loadButton(0);
    }
	
    public void jogar() {
        string name = nomeTecnico.text;
        if (!"".Equals(name))
        {
            Dados.me.saveLocation = Application.persistentDataPath + "/save/" + name + ".ide";
            Coach jogador = new Coach(name, (int)times[ligaTime[1].value][0], -1);
            Dados.me.temporaryJogador = jogador;
            sceneControl.LoadStartGame();
        }           
    }

    public void carregar(Text saveName)
    {
        if (!"Vazio".Equals(saveName.text))
        {
            Dados.me.saveLocation = Application.persistentDataPath + "/save/" + saveName.text + ".ide";
            sceneControl.LoadStartGame();
        }
        else
            loadButton(1);
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

    private void carregarSavesList()
    {
        DirectoryInfo Dir = new DirectoryInfo(@Application.persistentDataPath + "/save");
        FileInfo[] Files = Dir.GetFiles("*.ide", SearchOption.AllDirectories);
        int i = 0;
        foreach (FileInfo File in Files)
        {
            if (i >= 5) break;

            savesText[i].text = Path.GetFileNameWithoutExtension(File.Name);
            i++;
        }
    }


    public void dropdownHandler(int i)
    {
        ligaTime[1].value = 0;
        ligaTime[1].ClearOptions();
        times = ((List<object[]>)((object[])ob[i])[1]);
        foreach (object[] o in times)
        {
            ligaTime[1].options.Add(new Dropdown.OptionData(o[1].ToString()));
        }
        ligaTime[1].RefreshShownValue();

    }

    private void carregarDropdown()
    {
        ligaTime[0].ClearOptions();
        foreach(object o in ob)
        {
            object[] q = (object[])o;
            ligaTime[0].options.Add(new Dropdown.OptionData(q[0].ToString()));
        }
        ligaTime[0].RefreshShownValue();
        dropdownHandler(0);

    }


    


}
