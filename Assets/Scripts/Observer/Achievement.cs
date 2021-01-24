using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Observer {
    public abstract class Achievement : MonoBehaviour {
        public GameObject textPrefab;
        readonly int _goal;
        readonly float _displayDuration;
        
        protected Achievement(int goal, float displayDuration = 2f) {
            _displayDuration = displayDuration;
            _goal = goal;
        }
    
        void Start() {
            EventBroker.OnGoldAmountChanged += UpdateOnGoldAmount;
        }
    
        void UpdateOnGoldAmount(int gold) {
            if (gold >= _goal)
                AchievementGained();
        }

        void AchievementGained() {
            EventBroker.OnGoldAmountChanged -= UpdateOnGoldAmount;
            var prefab = Instantiate(textPrefab, transform);
            prefab.GetComponent<Text>().text = $"ACHIEVEMENT! You've earned {_goal} gold!";
            StartCoroutine(DestroyAfterSeconds(_displayDuration, prefab));
        }

        IEnumerator DestroyAfterSeconds(float seconds, Object item) {
            yield return new WaitForSeconds(seconds);
            Destroy(item);
        }
    }
}
