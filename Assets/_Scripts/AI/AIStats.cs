using UnityEngine;

namespace Custom.AI
{
    [CreateAssetMenu(menuName = "AI/Stats")]
    public class AIStats : ScriptableObject
    {
        public float moveSpeed = 1;
        public float lookShereCastRadius = 2;
    }
}