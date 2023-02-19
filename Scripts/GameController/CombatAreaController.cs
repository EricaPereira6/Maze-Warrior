using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAreaController : MonoBehaviour
{
    public RockSlide rockToDrop;

    private NinjaLifeSystem[] enemies;
    private ArenaTrigger musicTrigger;

    private bool victory;
    private bool paused;

    // Start is called before the first frame update
    void Start()
    {
        enemies = GetComponentsInChildren<NinjaLifeSystem>();
        musicTrigger = GetComponentInChildren<ArenaTrigger>();

        victory = false;
        paused = false;

        if (enemies.Length == 0)
        {
            victory = true;
            musicTrigger.DesertArena();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (victory && !musicTrigger.IsVictoryTriggered())
        {
            musicTrigger.TriggerVictory();
        }
        if (!victory) 
        {
            paused = !musicTrigger.IsCombatMode();

            if (!paused)
            {
                StartCoroutine(Fighting());
            }
        }
    }

    IEnumerator Fighting()
    {
        yield return new WaitForSeconds(1);

        if (!paused && !IsVictory())
        {
            StartCoroutine(Fighting());
        }
    }

    public bool IsVictory()
    {
        if (!victory)
        {
            if (enemies.Length > 0)
            {
                foreach (NinjaLifeSystem ninjaLifeSystem in enemies)
                {
                    if (!ninjaLifeSystem.IsDead())
                    {
                        return false;
                    }
                }
            }

            victory = true;

            rockToDrop.StartRockDrop();
            musicTrigger.Victory();
            UI.SetNumKeys();
        }
        
        return true;
    }
}
