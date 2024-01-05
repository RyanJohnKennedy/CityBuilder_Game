using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Custom.AI
{
    [CreateAssetMenu(menuName = "AI/Actions/Wonder")]
    public class WonderAction : Action
    {
        private float randomWonder = 0;
        public override void Act(AIStateController controller)
        {
            DelayWonder(controller);
        }

        private void Wonder(AIStateController controller)
        {
            Debug.Log("Run");
            float radius = 20;

            Vector3 randomDirection = Random.insideUnitSphere * radius;
            randomDirection += controller.nPCController.home.transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, radius, 1);
            Vector3 finalPosition = hit.position;

            controller.navMeshAgent.destination = finalPosition;
        }

        private void DelayWonder(AIStateController controller)
        {
            if (randomWonder == 0)
                randomWonder = Random.Range(1, 15);

            if (controller.CheckIfCountDownElapsed(randomWonder))
            {
                Wonder(controller);
                controller.stateTimeElapsed = 0;
                randomWonder = 0;
            }
        }
    }
}