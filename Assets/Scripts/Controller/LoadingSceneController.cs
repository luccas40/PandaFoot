using PwndaGames.PandaFoot.Database;
using PwndaGames.PandaFoot.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Fading))]
public class LoadingSceneController : MonoBehaviour {


    private AsyncOperation async;
    public float newGameProgress;
    public float actualProgress;

    private Text loadInfo;
    private RectTransform progressBar;



    void Start () {
        DontDestroyOnLoad(this.gameObject);
        actualProgress = 0;
        newGameProgress = 0;
    }

    void FixedUpdate()
    {

        if(actualProgress > newGameProgress)
        {
            actualProgress -= Time.fixedDeltaTime * 34;
        }

        if(actualProgress < newGameProgress)
        {
            actualProgress += Time.fixedDeltaTime * 34;
        }

        
        if(async != null && actualProgress < 100 && newGameProgress != 0)
        {
            newGameProgress = 50f + (async.progress*50)+5;
        }


        if (SceneManager.GetActiveScene().name.Equals("LoadLevel"))
        {
            
            if (loadInfo == null)
            {
                loadInfo = GameObject.Find("Canvas/Panel/backProgressBar/Text").GetComponent<Text>();
                progressBar = GameObject.Find("Canvas/Panel/backProgressBar/ProgressBar").GetComponent<RectTransform>();
                
            }

            progressBar.localScale = new Vector3(actualProgress/100, 1f, 1f); 

        }
        


    }

    public void LoadScene(string scene)
    {
        StartCoroutine(LoadLevel(scene)); 
    }


    public void LoadStartGame()
    {
        LoadScene("LoadLevel");
        StartCoroutine(loadNewGame());
    }

    private IEnumerator loadNewGame()
    {
        actualProgress = 0;
        newGameProgress = 0;
        yield return new WaitForSeconds(2f);
        newGameProgress = 10f;
        loadInfo.text = "Carregando Campeonatos...";
        yield return SaveGame.LoadSaveGame(false, Dados.me.saveLocation);
        yield return new WaitForSeconds(2f);
        newGameProgress = 25f;
        yield return SaveGame.saveGameData();
        yield return new WaitForSeconds(2f);
        newGameProgress = 50f;
        loadInfo.text = "Carregando Assets...";
        async = SceneManager.LoadSceneAsync("TeamLevel");        
        async.allowSceneActivation = false;
        yield return new WaitUntil(() => actualProgress > 99);
        loadInfo.text = "Completo";
        yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(GetComponent<Fading>().BeginFade(1));
        async.allowSceneActivation = true;
        async = null;
    }

    private IEnumerator LoadLevel(string Level)
    {        
        yield return new WaitForSeconds(GetComponent<Fading>().BeginFade(1));
        async = SceneManager.LoadSceneAsync(Level);
        yield return async;
        async = null;
        
    }



}
