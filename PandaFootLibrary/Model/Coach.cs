using PwndaGames.PandaFoot.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable ()]
public class Coach
{
    private string name;
    private int idTime;
    private int idade;

    public string Nome { get { return name; } }
    public Team Time { get { return Dados.me.Times[idTime]; } set { idTime = value.ID; } }


    public Coach(string nome, int time, int idade)
    {
        this.name = nome;
        this.idTime = time;
        this.idade = idade;
    }


}
