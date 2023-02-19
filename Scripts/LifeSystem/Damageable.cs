using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Damageable
{
    void TakeDamage(int amount);
    void DoDamage(GameObject hit);
}
