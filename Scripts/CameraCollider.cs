using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollider : MonoBehaviour
{

    public Collider[] collidersToIgnore;
    
    private Transform self;

    public Transform cameraNearPos;
    private SphereCollider sphereCollider;

    private Vector3 nearPos;
    private Vector3 farPos;

    private float pos;
    private int numCollisions;

    // Start is called before the first frame update
    void Start()
    {
        self = transform;
        sphereCollider = GetComponent<SphereCollider>();

        nearPos = cameraNearPos.localPosition;
        farPos = self.localPosition;

        pos = 0;
        numCollisions = 0;

        foreach(Collider collider in collidersToIgnore)
        {
            Physics.IgnoreCollision(sphereCollider, collider);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (numCollisions > 0)
        {
            pos += Time.deltaTime;
        }
        else
        {
            if (!Physics.SphereCast(self.position, sphereCollider.radius, -self.forward, out RaycastHit hit, 1))
            {
                pos -= Time.deltaTime;  
                
            }
        }

        // stays only between 0 and 1
        pos = Mathf.Clamp01(pos);

        self.localPosition = Vector3.Lerp(farPos, nearPos, pos);
    }

    private void OnTriggerEnter(Collider other)
    {
        numCollisions++;
    }

    private void OnTriggerExit(Collider other)
    {
        numCollisions--;
    }

}

