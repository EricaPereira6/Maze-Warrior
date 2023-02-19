using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSoundManager : MonoBehaviour
{

    private AudioSource source, attackSource;


    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.volume = Constants.soundVolume;

        Transform attackAudioTransform = GameObject.Find(Constants.attackAudioSourceGO).transform;
        attackSource = attackAudioTransform.GetComponent<AudioSource>();
        attackSource.volume = Constants.soundVolume;
    }

    // Update is called once per frame
    void Update()
    {
        if (source != null && source.volume != Constants.soundVolume)
        {
            source.volume = Constants.soundVolume;
        }
        if (attackSource != null && attackSource.volume != Constants.soundVolume)
        {
            attackSource.volume = Constants.soundVolume;
        }
    }

    private void FootStep(AnimationEvent animEvent)
    {

        if (animEvent.animatorClipInfo.weight > 0.5f)
        {
            Sound.FootStep(source);
        }

    }

    private void ThrowPunch()
    {

        Sound.ThrowPunch(attackSource);

    }

    private void SwordStroke()
    {
        Sound.SwordStroke(attackSource);
        FX.ParticleSwordStroke();
    }
}
