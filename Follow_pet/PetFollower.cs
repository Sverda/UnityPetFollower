using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Follow_pet
{
    public static class PetFollower
    {
        public static Rigidbody Rb;
        public static Transform Target;
        public static Transform MyTransform;

        public static class MoveBehaviour
        {
            private static float speed = 3.0F;
            private static Vector3 distanceLimit = new Vector3(2.0F, 2.0F, 2.0F);
            private static Vector3 distanceFromTarget;

            public static void UpdateMove()
            {
                if (Mathf.Abs(distanceFromTarget.x) < distanceLimit.x && Mathf.Abs(distanceFromTarget.z) < distanceLimit.z && Mathf.Abs(distanceFromTarget.y) < distanceLimit.y)
                {
                    // TODO: implement run in circle by 'follower'
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
