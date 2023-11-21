using UnityEngine;

namespace Custom.AI
{
    [CreateAssetMenu(menuName = "AI/Stats")]
    public class AIStats : ScriptableObject
    {
        public float moveSpeed = 1;
        public float lookShereCastRadius = 2;
        public float ActionRate = 3;
        public float ActionRange = 2;
    }
}