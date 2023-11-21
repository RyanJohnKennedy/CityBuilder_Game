using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Custom.AI
{
    [CreateAssetMenu (menuName = "AI/Decisions/DayTime")]
    public class DayTimeDecision : Decision
    {
        public override bool Decide(AIStateController controller)
        {
            bool isDayTime = CheckTime(controller);
            return isDayTime;
        }

        private bool CheckTime(AIStateController controller)
        {
            if (controller.gameController.timeOfDay.Equals(TimeOfDay.Night))
                return false;
            return true;
        }
    }
}