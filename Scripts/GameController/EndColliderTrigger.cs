using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndColliderTrigger : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Warrior warrior = other.GetComponent<Warrior>();

        if (warrior != null)
        {
            Game.StartInteriorScene();
        }
    }
}
