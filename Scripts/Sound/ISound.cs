using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISound
{

    void FootStep(AudioSource source);

    void ThrowPunch(AudioSource source);

    void SwordStroke(AudioSource source);

    void StartRockDrop();

    void StartRegenerator();

    void StartGameOver();

    void StopPlayingSound();

    void StartAmbientMusic();

    void StartCombatMusic();

    void StartFinalMusic();

    void StopPlayingMusic();

    void FadeMusic(float duration, float volumeTarget);

}
