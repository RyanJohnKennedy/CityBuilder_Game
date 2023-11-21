using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Custom.AI
{
    [CreateAssetMenu(menuName = "AI/Actions/Attack")]
    public class ChopWoodAction : Action
    {
        public override void Act(AIStateController controller)
        {
            ChopWood(controller);
        }

        private void ChopWood(AIStateController controller)
        {
            RaycastHit hit;

            Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized * controller.stats.ActionRange, Color.green);

            if(Physics.SphereCast(controller.eyes.position, controller.stats.lookShereCastRadius, controller.eyes.forward, out hit, controller.stats.ActionRange) 
                && hit.collider.CompareTag("Tree"))
            {
                if(controller.CheckIfCountDownElapsed(controller.stats.ActionRate))
                {
                    
                }
            }
        }
    }
}
