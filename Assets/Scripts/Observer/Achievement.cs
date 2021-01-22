using System.Collections;
using Publisher;
using UnityEngine;
using UnityEngine.UI;

namespace Observer {
    public abstract class Achievement : MonoBehaviour {
        GoldController _gc;
        public GameObject textPrefab;
        readonly int _goal;
        readonly float _displayDuration;
        
        protected Achievement(int goal, float displayDuration) {
            _displayDuration = displayDuration;
            _goal = goal;
        }
    
        void Start() {
            _gc = FindObjectOfType<GoldController>();
            _gc.GoldAmountChanged += UpdateGoldAmount;
        }
    
        void UpdateGoldAmount(int gold) {
            if (gold >= _goal)
                AchievementGained();
        }

        void AchievementGained() {
            var prefab = Instantiate(textPrefab, transform);
            prefab.GetComponent<Text>().text = $"ACHIEVEMENT! You've earned {_goal} gold!";
            StartCoroutine(DestroyAfterSeconds(_displayDuration, prefab));
            _gc.GoldAmountChanged -= UpdateGoldAmount;
        }

        IEnumerator DestroyAfterSeconds(float seconds, Object item) {
            yield return new WaitForSeconds(seconds);
            Destroy(item);
        }
    }
}
