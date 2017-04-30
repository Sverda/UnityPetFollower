using UnityEngine;

namespace Assets.Scripts.Follow_pet
{
    public static partial class PetFollower
    {
        public static class MoveBehaviour
        {
            public static float speed = 3.0F;
            public static Vector3 distanceLimit;
            private static Vector3 distanceFromTarget;

            public static void UpdateMove()
            {
                if (Mathf.Abs(distanceFromTarget.x) < distanceLimit.x && Mathf.Abs(distanceFromTarget.z) < distanceLimit.z && Mathf.Abs(distanceFromTarget.y) < distanceLimit.y)
                {
                    // TODO: implement run in circle by 'follower'
                    MyTransform.LookAt(Target);
                    StopMove();
                }
                else
                {
                    runTo(Target);
                }
            }

            private static void runTo(Transform t)
            {
                MyTransform.LookAt(t);
                MyTransform.Translate(Vector3.forward * speed * Time.deltaTime);
            }

            public static void StopMove()
            {
                Rb.velocity = Vector3.zero;
                Rb.angularVelocity = Vector3.zero;
            }

            public static void ComputeDistance()
            {
                distanceFromTarget = Target.transform.position - MyTransform.position;
            }
        }
    }
}
