using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCollider : MonoBehaviour
{

    private Transform self;
    //private GameObject[] portalChildren;

    // Start is called before the first frame update
    void Start()
    {
        self = transform;

        //portalChildren = new GameObject[self.childCount];

        //for (int i = 0; i < self.childCount; i++)
        //{
        //    portalChildren[i] = self.GetChild(i).gameObject;
        //    portalChildren[i].SetActive(false);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    foreach(GameObject go in portalChildren)
        //    {
        //        go.SetActive(true);
        //    }
        //}
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<Warrior>())
        {
            Game.StartGameWon();
        }
    }
}
