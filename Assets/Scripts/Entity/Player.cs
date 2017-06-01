﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable()]
public class Player {

    private string name;
    private int age;
    private int str;
    private int power;
    private int energy;
    private string nation;
    private int position;

    public Player()
    {
    }

    public Player(string nome, int idade, int forca, int potencial, int energy, string nation, int position)
    {
        this.name = nome;
        this.age = idade;
        this.str = forca;
        this.power = potencial;
        this.energy = energy;
        this.nation = nation;
        this.position = position;
    }

    public string getName()
    {
        return name;
    }

    public int getAge()
    {
        return age;
    }

    public int getStrenght()
    {
        return str;
    }

    public int getPower()
    {
        return power;
    }

    public void lowyEnergy()
    {

    }

    public int getEnergy() { return energy; }

}
