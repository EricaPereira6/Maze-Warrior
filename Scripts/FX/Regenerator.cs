using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regenerator : MonoBehaviour
{
    public GameObject GOLight;

    private PulseLight pulseLight;

    private bool regenerating;

    // Start is called before the first frame update
    void Start()
    {
        pulseLight = GOLight.GetComponent<PulseLight>();

        regenerating = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Warrior>() != null)
        { 
            regenerating = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        WarriorLifeSystem ls = other.GetComponent<WarriorLifeSystem>();

        if (ls != null && ls.GetWarriorHp() < ls.GetWarriorMaxHp())
        {
            regenerating = true;
            StartCoroutine(Regenerating(ls));
        }
    }

    

    IEnumerator Regenerating(WarriorLifeSystem ls)
    {
        
        if (pulseLight != null && !pulseLight.IsPulsing())
        {
            pulseLight.Pulse(true);
        }

        Sound.StartRegenerator();

        yield return new WaitForSeconds(Constants.regenerateWaintingTime / 2f);

        ls.RegenerateLife(Constants.regenerateLife);

        yield return new WaitForSeconds(Constants.regenerateWaintingTime / 2f);


        if (ls.GetWarriorHp() < ls.GetWarriorMaxHp() && regenerating)
        {
            StartCoroutine(Regenerating(ls));
        }
        else
        {
            regenerating = false;

            if (pulseLight != null)
            {
                pulseLight.Pulse(false);
            }
        }
    }
}
