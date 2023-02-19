using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadNinja : MonoBehaviour
{
    private Animator anim;
    private CapsuleCollider capsule;
    private Vector3 originalCapsuleCenter;

    private Rigidbody rg;


    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();

        anim.SetTrigger("die");

        capsule = GetComponent<CapsuleCollider>();
        originalCapsuleCenter = capsule.center;

        rg = GetComponent<Rigidbody>();

        rg.isKinematic = true;
        capsule.height = 0;
        capsule.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {

        float height = anim.GetFloat("ninja_capsule_height");

        capsule.center = originalCapsuleCenter - (Vector3.up * (height * Constants.deathHeightOffset));

    }

}
