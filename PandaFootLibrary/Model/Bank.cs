using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable()]
public class Bank {


    private double money;
    public double Money { get { return this.money; } set { money = value; } }


    public Bank(double money)
    {
        this.money = money;
    }

    public override string ToString()
    {
        return "$"+money;
    }

}
