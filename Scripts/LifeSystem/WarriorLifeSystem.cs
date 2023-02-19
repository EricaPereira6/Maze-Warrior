using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;

public class WarriorLifeSystem : MonoBehaviour, Damageable
{
    private LifeSystem lifeSystem;
    private bool canDoDamage;

    private List<GameObject> toDamage;


    void Awake()
    {
        lifeSystem = new LifeSystem(Constants.maxHpWarrior);
    }

    // Start is called before the first frame update
    void Start()
    {

        canDoDamage = false;

        UI.SetPlayerHealth(lifeSystem.GetHp(), lifeSystem.GetMaxHp());

        toDamage = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (toDamage.Count > 0)
        {
            Damage();
        }
    }

    public LifeSystem GetLifeSystem()
    {
        return lifeSystem;
    }

    public float GetWarriorHp()
    {
        return lifeSystem.GetHp();
    }

    public float GetWarriorMaxHp()
    {
        return lifeSystem.GetMaxHp();
    }

    public bool IsDead()
    {
        if (lifeSystem != null)
        {
            return lifeSystem.IsDead();
        }
        return false;
    }

    public void EnableDamage()
    {
        canDoDamage = true;
    }

    public void DisableDamage()
    {
        canDoDamage = false;
    }

    public void DoDamage(GameObject hit)
    {
        if (canDoDamage)
        {
            toDamage.Add(hit);
        }
    }


    public void Damage()
    {
        for(int i = 0; i < toDamage.Count; i++)
        {
            i = 0;
            Damageable damageable = toDamage[i].GetComponent<Damageable>();
            if (damageable != null)
            {
                Debug.Log("damaged");
                damageable.TakeDamage(Constants.playerAttackDamage);
                
            }
            toDamage.RemoveAt(i);
        }

    }

    public void TakeDamage(int amount)
    {
        lifeSystem.TakeDamage(amount);
        UI.SetPlayerHealth(lifeSystem.GetHp(), lifeSystem.GetMaxHp());
    }

    public void RegenerateLife(int amount)
    {
        lifeSystem.RegenerateLife(amount);
        UI.SetPlayerHealth(lifeSystem.GetHp(), lifeSystem.GetMaxHp());
    }

}
