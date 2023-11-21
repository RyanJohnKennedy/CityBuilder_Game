using UnityEngine;

namespace Custom.AI
{
    public abstract class Action : ScriptableObject
    {
        public abstract void Act(AIStateController controller);
    }
}