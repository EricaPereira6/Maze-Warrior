using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour, IFX
{

    public Transform sparksPos;
    public GameObject sparksPrefab;

    private GameObject sparksInstance;

    private static bool isWall;

    // Start is called before the first frame update
    void Start()
    {
        FX.Set(this);

        isWall = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ParticleSwordStroke()
    {
        if (isWall)
        {
            if (sparksInstance == null)
            {
                sparksInstance = Instantiate(sparksPrefab, sparksPos.position, Quaternion.identity);
                sparksInstance.transform.localScale = Vector3.one;
            }
            sparksInstance.transform.position = sparksPos.position;
            sparksInstance.transform.rotation = sparksPos.rotation;
            sparksInstance.GetComponent<ParticleSystem>().Play();

            isWall = false;
        }
    }

    public static void HitWall(bool wallHitted)
    {
        isWall = wallHitted;
    }

}
