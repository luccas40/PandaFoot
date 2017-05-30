using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


    private string saveData;


	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
	}
	
    public void jogar() {
        StartCoroutine(loadLevel());        
    }

    public void carregar()
    {
        saveData = "save.ide";
        StartCoroutine(loadLevel());
    }



    IEnumerator loadLevel()
    {
        AsyncOperation o = SceneManager.LoadSceneAsync("TeamLevel");
        yield return new WaitForSeconds(3);
        while (!o.isDone)
            yield return null;
    }

    public string getSaveData()
    {
        return saveData;
    }

}
