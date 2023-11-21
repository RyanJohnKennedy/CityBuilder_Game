using UnityEditor.Animations;
using UnityEngine;

namespace Custom.AI
{
[CreateAssetMenu(menuName = "AI/Decisions/Home")]
    public class HomeDecision : Decision
    {
        public override bool Decide(AIStateController controller)
        {
            bool GoHome = Home(controller);
            return GoHome;
        }

        private bool Home(AIStateController controller)
        {
            if (controller.gameController.timeOfDay == TimeOfDay.Night)
            {
                return true;
            }
            return false;
        }
    }
}