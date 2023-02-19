using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem
{

    private float hp;
    private float maxHp;

    public LifeSystem(float maxHp)
    {
        this.maxHp = maxHp;
        hp = maxHp;
    }

    public float GetHp()
    {
        return hp;
    }

    public float GetMaxHp()
    {
        return maxHp;
    }

    public void RegenerateLife(int amount)
    {
        hp = Mathf.Min(hp + amount, maxHp);
    }

    public void TakeDamage(int amount)
    {
        hp = Mathf.Max(hp - amount, 0);
    }

    public bool IsDead()
    {
        return hp == 0;
    }
}
