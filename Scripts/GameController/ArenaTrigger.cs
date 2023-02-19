using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaTrigger : MonoBehaviour
{
    private Warrior warrior;

    private bool victory;

    private bool combatMode;

    private string arenaTitle;

    void Awake()
    {
        arenaTitle = "";
    }

    void Start()
    {
        victory = false;
        combatMode = false;

        arenaTitle = name.Equals(Constants.desertArenaCollider) ? Constants.desertArenaTitle :
                        name.Equals(Constants.winterArenaCollider) ? Constants.winterArenaTitle : Constants.springArenaTitle;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (victory)
        {
            UI.SetText(arenaTitle, Constants.timeWarningTextRemains);
        }
        else if (!victory && !name.Equals(Constants.desertArenaCollider))
        {
            warrior = other.GetComponent<Warrior>();

            if (warrior != null)
            {
                combatMode = true;

                Sound.StartCombatMusic();

            }
        }
        if (arenaTitle == "")
        {
            arenaTitle = name.Equals(Constants.desertArenaCollider) ? Constants.desertArenaTitle :
                        name.Equals(Constants.winterArenaCollider) ? Constants.winterArenaTitle : Constants.springArenaTitle;
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (!victory)
        {
            warrior = other.GetComponent<Warrior>();

            if (warrior != null)
            {
                combatMode = false;

                Sound.StartAmbientMusic();
            }
        }
    }

    public void Victory()
    {
        TriggerVictory();

        Sound.StartAmbientMusic();
    }

    public void DesertArena()
    {
        TriggerVictory();

        UI.SetInitialText();
    }

    public bool IsVictoryTriggered()
    {
        return victory;
    }

    public void TriggerVictory()
    {
        victory = true;
    }

    public bool IsCombatMode()
    {
        return combatMode;
    }
}
