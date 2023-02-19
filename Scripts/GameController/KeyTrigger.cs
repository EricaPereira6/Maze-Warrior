using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTrigger : MonoBehaviour
{

    public Collider keyCollider;

    private bool gateOpen;

    // Start is called before the first frame update
    void Start()
    {
        gateOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gateOpen && Constants.numkeys == 3)
        {
            gateOpen = true;
            Destroy(keyCollider);
            UI.SetFinalText();
            Sound.StartFinalMusic();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!gateOpen)
        {
            UI.SetText(Constants.cantGoThrough, Constants.timeWarningTextRemains);
        }
    }
}
