using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Custom.AI
{
    [CreateAssetMenu (menuName = "AI/Actions/ReturnHome")]
    public class ReturnHomeAction : Action
    {
        public override void Act(AIStateController controller)
        {
            ReturnHome(controller);
        }

        private void ReturnHome(AIStateController controller)
        {
            controller.navMeshAgent.destination = controller.nPCController.home.gameObject.transform.position;
            controller.navMeshAgent.isStopped = false;
        }
    }
}