using PwndaGames.PandaFoot.Controller;
using PwndaGames.PandaFoot.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableRow : MonoBehaviour {

    private Text pposicao;
    private Text pnome;

    private Text pforca;

    private Image energyImg;
    private Transform energy;

    private Text pidade;
    private Text psalario;
    private Text ppasse;

    private GameController game;
    Player p;

    public void setRefPlayer(ref Player p) { this.p = p; }


    void Start()
    {
        game = GameObject.Find("GameController").GetComponent<GameController>();
        pposicao = transform.Find("posicao").GetComponent<Text>();
        pnome = transform.Find("nome").GetComponent<Text>();

        pforca = transform.Find("forca").GetComponent<Text>();

        energy = transform.Find("energyBack/energy").transform;
        energyImg = energy.GetComponent<Image>();
        pidade = transform.Find("idade").GetComponent<Text>();
        psalario = transform.Find("salario").GetComponent<Text>();
        ppasse = transform.Find("passe").GetComponent<Text>();
        transform.localScale = new Vector3(1f, 1f, 1f);
}

    void Update()
    {
        if(p != null)
        {
            pposicao.text = p.Position.ToString();
            pnome.text = p.Nome;

            pforca.text = p.Forca.ToString();

            pidade.text = p.Idade.ToString();
            psalario.text = "$"+AbbrevationUtility.AbbreviateNumber(p.Salario);
            ppasse.text = "$" + AbbrevationUtility.AbbreviateNumber(p.Valor);
        }

        //energyImg.material.SetColor("_Color", (Resources.Load("Materials/TeamColor") as Material).color);
    }

    public void OnMouseDown()
    {
        game.selectPlayer(p);
    }



}
