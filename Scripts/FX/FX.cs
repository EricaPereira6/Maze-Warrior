using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX
{

    private static IFX instance;

    public static void Set(IFX instance)
    {
        if (FX.instance == null)
        {
            FX.instance = instance;
        }
    }

    public static void ParticleSwordStroke()
    {
        if (instance != null)
        {
            instance.ParticleSwordStroke();
        }

    }
}