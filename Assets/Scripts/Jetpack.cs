using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : Buff
{
    protected override void MakeBuffEffect()
    {
        HeroController.instace.IncreaseSpeed();
    }
}
