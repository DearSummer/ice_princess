using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtData{
    public int damageFigure = 0;
    public object sender;
    public HurtData(int damage, GameObject tsender)
    {
        damageFigure = damage;
        sender = tsender;
    }
}
