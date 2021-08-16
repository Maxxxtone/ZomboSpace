using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygen : Buff
{
    [SerializeField] private int _oxygenAmount = 15;
    protected override void MakeBuffEffect()
    {
        Hero.instance.Hp += _oxygenAmount;
    }
}
