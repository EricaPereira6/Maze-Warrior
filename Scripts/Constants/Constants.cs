using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    // VARIABLES
    public static float musicVolume = 0.7f;
    public static float soundVolume = 0.7f;

    public static Dictionary<string, string> menuKeys = new Dictionary<string, string>(){ { "run_fw_key", "W" },
                                                                                            { "run_bk_key", "S" },
                                                                                            { "run_lf_key", "A" },
                                                                                            { "run_rg_key", "D" },
                                                                                            { "attack_key", "MOUSE0" },
                                                                                            { "sprint_key", "SHFT" },
                                                                                            { "jump_key", "SPACE" } };

    public static int numkeys = 0;
    public static string currentScene = gameScene;


    // CONSTANTS
    public const string keyTextFormat = " / 3";

    public const float timeWarningTextRemains = 4;
    public const float timeTextRemains = 5;
    public const string cantGoThrough = "You can't go through without the 3 keys";
    public const string firstCongrats = "Good Job. You just defeated the first arena of enemies";
    public const string youWinKeys = "You win keys by defeating enemies in the arenas";
    public const string whyNeedKeys = "You need 2 more keys to find a way out of the Maze";
    public const string youGotIt = "You got the 3 keys";
    public const string yourWayOut = "Now you can find your way out through the Sacred Garden";
    public const string springArenaTitle = "Spring Arena";
    public const string winterArenaTitle = "Winter Arena";
    public const string desertArenaTitle = "Desert Arena";

    public const string desertArenaCollider = "desert_collider";
    public const string winterArenaCollider = "winter_collider";
    public const string springArenaCollider = "spring_collider";


    public const int numDontDestroyMainMenu = 9;
    public const int numDontDestroyGame = 13;
    public const int numDontDestroyInteriorGame = 7;


    public static readonly Vector3 playerInteriorPos = new Vector3(55.65f, 0, 21.92f);
    public static readonly Vector3 playerInteriorRotation = new Vector3(0, 0, 0);


    public const string mainMenuScene = "MainMenu";
    public const string gameScene = "MazeWarriorGame";
    public const string interiorGameScene = "InteriorScene";
    public const string testWarriorScene = "TestWarrior";

    public const string musicSliderName = "music_slider";
    public const string soundSliderName = "sound_slider";

    public const float mouseOverAlpha = 0.6f;

    public static readonly Dictionary<string, string> menuDefaultKeys = new Dictionary<string, string>(){ { "run_fw_key", "W" }, 
                                                                                                        { "run_bk_key", "S" },
                                                                                                        { "run_lf_key", "A" }, 
                                                                                                        { "run_rg_key", "D" }, 
                                                                                                        { "attack_key", "MOUSE0" }, 
                                                                                                        { "sprint_key", "SHFT" }, 
                                                                                                        { "jump_key", "SPACE" } };
    // Damage
    public const int maxHpWarrior = 100;
    public const int playerAttackDamage = 5;
    public const int maxHpNinja = 50;
    public const int ninjaAttackDamage = 5;
    public const int maxHpBossNinja = 80;
    public const int bossNinjaAttackDamage = 10;

    public const int regenerateLife = 10;
    public const float regenerateWaintingTime = 2.3f;

    public const float noMovementWaitingTime = 12;
    public const float deathHeightOffset = 1f;

    public const float fadingRate = 2f;


    // Warrior

    public const float animSprintSpeed = 1.7f;
    public const float animNormalSpeed = 1.0f;

    // AI Ninja Agent
    public const int AIVisionDistance = 17;
    public const int AIVisionCone = 20;
    public const float secondsBeforeNextAttack = 1.7f;
    public const float patrolRemainingDistance = 0.15f;
    public const float farAwayRemainingDistance = 2f;
    public const float attackRemainingDistance = 0.8f;
    public const float closingInRemainingDistance = 1.9f;
    public const float spaceBetween = 0.5f;


    //Moving Rocks
    public const string springRockName = "spring_rock";
    public static readonly Vector3 springLeftPos = new Vector3(85.21f, -95.4f, 3f);
    public static readonly Vector3 springCenterPos = new Vector3(85.20f, -95.4f, 2.94f);
    public static readonly Vector3 springRightPos = new Vector3(85.19f, -95.4f, 2.88f);
    public static readonly Vector3 springFinalPos = new Vector3(85.20f, -102.9f, 2.94f);
    public static readonly Vector3 playerSpringPos = new Vector3(169.3f, 0, 17.3f);
    public static readonly Vector3 playerSpringRotation = new Vector3(0, 406, 0);

    public const string winterRockName = "winter_rock";
    public static readonly Vector3 winterLeftPos = new Vector3(136.40f, -94.78f, 201.57f);
    public static readonly Vector3 winterCenterPos = new Vector3(136.44f, -94.78f, 201.57f);
    public static readonly Vector3 winterRightPos = new Vector3(136.48f, -94.78f, 201.57f);
    public static readonly Vector3 winterFinalPos = new Vector3(136.44f, -99.75f, 201.57f);
    public static readonly Vector3 playerWinterPos = new Vector3(27.1f, 0, 184.3f);
    public static readonly Vector3 playerWinterRotation = new Vector3(0, 446.17f, 0);


    // Sound
    public const string attackAudioSourceGO = "attack_audio_source";


    // Terrain Lights
    public const float changingLightSpeed = 1f;
    public const float targetIntensity = 1.3f;
    public const float normalIntensity = 0.5f;
}
