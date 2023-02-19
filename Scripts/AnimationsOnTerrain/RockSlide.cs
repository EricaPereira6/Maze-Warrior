using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSlide: MonoBehaviour
{
    public GameObject player;

    private Transform self;

    private enum STATE { WAITING_VICTORY, MOVING, NEXT_MOVEMENT, DONE };
    private STATE state;

    private Vector3[] positions;
    private int index;
    private int giggleTimes;
    private bool dropRock;
    private bool startDroping;

    private Vector3 playerPos;
    private Vector3 playerRotation;

    private Warrior warrior;


    void Start()
    {
        self = transform;
        state = STATE.WAITING_VICTORY;

        if (self.name.Equals(Constants.springRockName))
        {
            playerPos = Constants.playerSpringPos;
            playerRotation = Constants.playerSpringRotation;

            positions = new Vector3[5] { Constants.springLeftPos,
                                     Constants.springRightPos,
                                     Constants.springLeftPos,
                                     Constants.springCenterPos,
                                     Constants.springFinalPos };
        }
        else
        {
            playerPos = Constants.playerWinterPos;
            playerRotation = Constants.playerWinterRotation;

            positions = new Vector3[5] { Constants.winterLeftPos,
                                     Constants.winterRightPos,
                                     Constants.winterLeftPos,
                                     Constants.winterCenterPos,
                                     Constants.winterFinalPos };
        }

        giggleTimes = 8;
        index = 0;
        dropRock = false;
        startDroping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dropRock && startDroping)
        {
            player.transform.position = playerPos;
            player.transform.localEulerAngles = playerRotation;
            warrior = player.GetComponent<Warrior>();
            if (warrior != null)
            {
                warrior.ResetWarrior();
            }
            dropRock = true;
            state = STATE.NEXT_MOVEMENT;

            Sound.StartRockDrop();
            Game.MakePayerWait(true);
        }

        if (dropRock && state == STATE.NEXT_MOVEMENT)
        {
            if (index < positions.Length)
            {
                state = STATE.MOVING;
                StartCoroutine(MovingRock(positions[index]));
                index++;

                if (giggleTimes > 0)
                {
                    if (index == 2)
                    {
                        index = 0;
                    }
                    else
                    {
                        giggleTimes--;
                    }
                }
            }
            else
            {
                state = STATE.DONE;
                Sound.StopPlayingSound();
                Game.MakePayerWait(false);
            }
        }
    }

    IEnumerator MovingRock(Vector3 pos)
    {
        float x = pos.x;
        float y = pos.y;
        float z = pos.z;

        float rockX = self.localPosition.x;
        float rockY = self.localPosition.y;
        float rockZ = self.localPosition.z;

        float translationPerSeconds = 0.065f;

        rockX = (rockX > x) ? Mathf.Max(x, rockX - translationPerSeconds) : (rockX < x) ? Mathf.Min(x, rockX + translationPerSeconds) : rockX;
        rockY = (rockY > y) ? Mathf.Max(y, rockY - translationPerSeconds) : (rockY < y) ? Mathf.Min(y, rockY + translationPerSeconds) : rockY;
        rockZ = (rockZ > z) ? Mathf.Max(z, rockZ - translationPerSeconds) : (rockZ < z) ? Mathf.Min(z, rockZ + translationPerSeconds) : rockZ;

        Vector3 newPos = new Vector3(rockX, rockY, rockZ);

        self.localPosition = newPos;

        if (self.localPosition.x == x && self.localPosition.y == y && self.localPosition.z == z)
        {
            state = STATE.NEXT_MOVEMENT;
        }
        else
        {
            yield return null;
            StartCoroutine(MovingRock(pos));
        }

        yield return null;
    }

    public void StartRockDrop()
    {
        startDroping = true;
    }
}
