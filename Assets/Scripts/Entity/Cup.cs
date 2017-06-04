using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Cup : AbstractChampionship
{
    public Cup(string nome, DateTime startDate) : base(nome, startDate)
    {
    }

    public override void gerarConfrontos()
    {
        
    }
}
