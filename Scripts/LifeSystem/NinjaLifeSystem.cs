using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaLifeSystem : MonoBehaviour, Damageable
{
    private LifeSystem lifeSystem;
    private bool canDoDamage;
    private bool isDead;

    void Awake()
    {
        lifeSystem = new LifeSystem(Constants.maxHpNinja);
    }

    // Start is called before the first frame update
    void Start()
    {
        canDoDamage = false;
        isDead = false;

        UI.RegisterEnemy(gameObject);
        UI.SetEnemyHealth(gameObject, lifeSystem.GetHp(), lifeSystem.GetMaxHp());
        
    }

    public bool IsDead()
    {
        if (lifeSystem != null)
        {
            return lifeSystem.IsDead();
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead() && !isDead)
        {
            UI.RemoveEnemy(gameObject);
            isDead = true;
        }
    }

    public void EnableNinjaDamage()
    {
        canDoDamage = true;
    }

    public void DisableNinjaDamage()
    {
        canDoDamage = false;
    }

    public void DoDamage(GameObject hit)
    {
        if (canDoDamage)
        {
            Damageable damageable = hit.GetComponent<Damageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(Constants.ninjaAttackDamage);
            }
        }
    }
    
    public void TakeDamage(int amount)
    {
        lifeSystem.TakeDamage(amount);
        UI.SetEnemyHealth(gameObject, lifeSystem.GetHp(), lifeSystem.GetMaxHp());
    }
}
