using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{

    private Transform self;
    private Animator anim;
    private CapsuleCollider capsule;
    private Rigidbody rg;

    private Vector3 capsuleColliderCenter;
    private bool isMoving;
    private bool canAttack;
    private bool isDead;
    //private bool wallJump;

    private WarriorLifeSystem lifeSystem;
    void Start()
    {
        self = transform;
        anim = GetComponent<Animator>();
        capsule = GetComponent<CapsuleCollider>();
        rg = GetComponent<Rigidbody>();

        capsuleColliderCenter = capsule.center;
        isMoving = false;
        canAttack = true;
        isDead = false;
        //wallJump = false;

        lifeSystem = GetComponent<WarriorLifeSystem>();

        StartCoroutine(IdleLookingRoutine());
    }


    void Update()
    {
        if (!isDead && !Game.StopMoving())
        {

            float verticalMovement = Input.GetAxis("Vertical");
            float horizontalMovement = Input.GetAxis("Horizontal");


            RaycastHit hit;
            if (Physics.Raycast(self.position, self.forward + Vector3.right, out hit, 1) && verticalMovement > 0)
            {
                if (hit.collider != null && hit.collider.CompareTag("Stairs"))
                {
                    anim.SetBool("stairs", true);
                }
            }
            else
            {
                anim.SetBool("stairs", false);
                anim.SetFloat("vertical", verticalMovement);
                anim.SetFloat("horizontal", horizontalMovement);
            }


            isMoving = verticalMovement != 0 || horizontalMovement != 0;
            anim.SetBool("isMoving", isMoving);


            if (canAttack)
            {
                if (!isMoving && Input.GetButtonUp("Fire1"))
                {
                    anim.SetTrigger("attack");
                }
                else if (isMoving && Input.GetButtonUp("Fire1"))
                {
                    anim.SetTrigger("one_sw_attack");
                }
            }

            canAttack = !GameController.IsPaused();

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                anim.SetFloat("sprintSpeed", Constants.animSprintSpeed);
            }
            else
            {
                anim.SetFloat("sprintSpeed", Constants.animNormalSpeed);
            }



            if (Input.GetButtonUp("Jump"))
            {
                anim.SetTrigger("jump");
            }


            //if (Physics.Raycast(self.position, self.forward + Vector3.right, out hit, 2))
            //{
            //    if (hit.transform.CompareTag("Wall") && !wallJump)
            //    {
            //        wallJump = true;
            //    }
            //}
            //else
            //{
            //    wallJump = false;
            //}




            if (lifeSystem.IsDead())
            {
                Game.StartGameOver();

                anim.SetTrigger("die");

                isDead = true;
                rg.isKinematic = true;
                capsule.height = 0;


            }
        }
        else if (Game.StopMoving())
        {
            ResetWarrior();
        }

        Vector3 height = Vector3.up * anim.GetFloat("jumpCurve");

        float gravity = anim.GetFloat("gravityCurve");

        if (lifeSystem.IsDead())
        {
            height = -1 * (Vector3.up * (anim.GetFloat("collider_height") * Constants.deathHeightOffset));
            gravity = 1;
        }

        capsule.center = capsuleColliderCenter + height;

        rg.useGravity = gravity >= 1;
        
    }

    public void IsUpStairs(bool isStairs)
    {
        anim.SetBool("stairs", isStairs);
    }

    public void ResetWarrior()
    {
        anim.SetBool("isMoving", true);
        anim.SetFloat("horizontal", 0);
        anim.SetFloat("vertical", 0);
    }


    IEnumerator IdleLookingRoutine()
    {
        yield return new WaitForSeconds(Constants.noMovementWaitingTime);

        if (!isMoving)
        {
            anim.SetTrigger("noMovement");
        }
        else
        {
            yield return new WaitForSeconds(Constants.noMovementWaitingTime);
        }

        StartCoroutine(IdleLookingRoutine());
    }
}
