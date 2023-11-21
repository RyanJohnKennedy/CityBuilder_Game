using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Custom.AI
{
    public abstract class Decision : ScriptableObject
    {
        public abstract bool Decide(AIStateController controller);
    }
}