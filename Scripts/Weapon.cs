using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject damager;

    private Damageable damageable;
    private Warrior warrior;
    private Ninja ninja;
    private SoundRepository soundRepository;

    // Start is called before the first frame update
    void Start()
    {
        // holder can do damage
        damageable = damager.GetComponent<Damageable>();
        warrior = damager.GetComponent<Warrior>();
        ninja = damager.GetComponent<Ninja>();

        soundRepository = FindObjectOfType<SoundRepository>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Damageable otherDamageable = other.GetComponent<Damageable>();
        if (damageable != null && otherDamageable != null && damageable != otherDamageable)
        {
            
            if (!(ninja != null && other.GetComponent<Ninja>() != null))
            {
                damageable.DoDamage(other.gameObject);
            }

        }
        else if (other.CompareTag("Wall") && warrior != null)
        {
            soundRepository.ChoseSwordClip(true);
            FXManager.HitWall(true);
        }
    }


}
