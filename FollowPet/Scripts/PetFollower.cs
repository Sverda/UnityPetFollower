using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Follow_pet
{
    public class PetFollower
    {
        private Transform target;
        private NavMeshObstacle targetObstacle;
        private float distanceLimit;
        private NavMeshAgent agent;

        public PetFollower(Transform target, NavMeshAgent agent, float maxDistance, float minDistance)
        {
            this.target = target;
            this.distanceLimit = maxDistance;
            this.agent = agent;

            //Add NavMeshObstacle component on the fly
            targetObstacle = target.gameObject.AddComponent<NavMeshObstacle>() as NavMeshObstacle;
            targetObstacle.carving = true;
            targetObstacle.shape = NavMeshObstacleShape.Capsule;
            targetObstacle.size *= minDistance;
        }

        public void UpdateMove()
        {
            runTo(target.position);
        }

        private void runTo(Vector3 target)
        {
            Vector3 randomDirection = UnityEngine.Random.insideUnitSphere;
            randomDirection *= distanceLimit;
            randomDirection += target;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, distanceLimit, NavMesh.AllAreas);
            Vector3 finalPosition = hit.position;
            agent.SetDestination(finalPosition);
        }
    }
}
