using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIUtils
{
    
    public static bool HasVisionOfPlayer(Transform self, Transform player)
    {
        Vector3 dir = player.transform.position - self.position;

        if (Physics.Raycast(self.position, dir, out RaycastHit hit, Constants.AIVisionDistance) && !Game.IsGameOver())
        {
            return hit.collider.gameObject.transform.Equals(player);
        }

        //return (Mathf.Abs(Vector3.Angle(dir, self.forward)) < Constants.AIVisionCone) && !UI.IsGameOver();
        return false;
    }
}
