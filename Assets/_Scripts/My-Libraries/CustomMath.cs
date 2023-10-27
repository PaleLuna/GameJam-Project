using UnityEngine;

namespace PaleLuna.Math
{
    public static class CustomMath
    {
        public static float DirectionToAngle(Vector3 direction, Vector3 axis)
        {
            if (axis.Equals(Vector3.right))
                return angleAroundX(direction);
            if (axis.Equals(Vector3.up))
                return angleAroundY(direction);
            if (axis.Equals(Vector3.forward))
                return angleAroundZ(direction);

            return 0;
        }

        private static float angleAroundX(Vector3 direction) => Mathf.Atan2(direction.y, direction.z) * Mathf.Rad2Deg;
        private static float angleAroundY(Vector3 direction) => Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        private static float angleAroundZ(Vector3 direction) => Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
    }
}