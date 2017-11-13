using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using PwndaGames.PandaFoot.Util;

[Serializable()]
public class Player {

    private string name;
    private int age;
    private int str;
    private int power;
    private int energy;
    private string nation;
    private PlayerPosition position;
    private DateTime contrato;
    private double valor;
    private double custo;

    public string Nome { get { return name; } }
    public int Idade { get { return age; } }
    public int Forca { get { return str; } }
    public int Potencial { get { return power; } }
    public int Energia { get { return energy; } }
    public string Nation { get { return nation; } }
    public PlayerPosition Position { get { return position; } }
    public DateTime Contrato { get { return contrato; } }
    public double Valor { get { return valor; } }
    public double Salario { get { return custo; } }

    public Player()
    {
    }

    public Player(string nome, int idade, int forca, int potencial, int energy, string nation, PlayerPosition position, DateTime contrato, double valor, double custo)
    {
        this.name = nome;
        this.age = idade;
        this.str = forca;
        this.power = potencial;
        this.energy = energy;
        this.nation = nation;
        this.position = position;
        this.contrato = contrato;
        this.valor = valor;
        this.custo = custo;
    }
    

}
