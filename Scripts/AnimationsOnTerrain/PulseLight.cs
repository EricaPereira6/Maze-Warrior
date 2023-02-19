using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseLight : MonoBehaviour
{

    private Light pulsingLight;

    private bool pulse;
    
    // Start is called before the first frame update
    void Start()
    {
        pulsingLight = GetComponent<Light>();
        pulse = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pulse && pulsingLight != null)
        {
            ChangeIntensity(Constants.changingLightSpeed, Constants.targetIntensity);
        }
    }

    public void Pulse(bool pulsing)
    {
        pulse = pulsing;

        if (!pulse)
        {
            pulsingLight.intensity = Constants.normalIntensity;
        }
    }

    public bool IsPulsing()
    {
        return pulse;
    }


    public void ChangeIntensity(float changeSpeed, float targetIntensity)
    {
        pulsingLight.intensity = Mathf.Max(Constants.normalIntensity, Mathf.PingPong(changeSpeed * Time.time, targetIntensity));
    }
}
