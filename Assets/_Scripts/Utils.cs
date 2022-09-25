using System;
using UnityEngine;

namespace Game
{
    public static class Utils
    {
        public static Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
        {
            angleInDegrees += eulerY;
        
            return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
        }

        public static bool IsInRangeOfVision(
            Vector3 positionA, Vector3 positionB, float maxDistanceXZ, float maxDistanceY
            )
        {
            var distanceY = Math.Abs(positionB.y - positionA.y);
            positionB.y = positionA.y = 0;
            var distanceXZ = Vector3.Distance(positionB, positionA);

            return distanceXZ <= maxDistanceXZ && distanceY <= maxDistanceY;
        }
    }
}