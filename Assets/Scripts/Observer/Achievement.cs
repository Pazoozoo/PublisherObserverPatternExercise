using UnityEngine;

namespace Observer {
    [CreateAssetMenu]
    public class Achievement : ScriptableObject {
        public int goal;
        public float displayDuration;
        public bool Completed { get; set; }
    }
}
