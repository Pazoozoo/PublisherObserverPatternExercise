using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Publisher;
using UnityEngine;
using UnityEngine.UI;

namespace Observer {
    public class AchievementHandler : MonoBehaviour {
        public List<Achievement> achievements;
        public GameObject textPrefab;

        void Awake() {
            EventBroker.Instance().SubscribeTo<GoldAmountChangedMessage>(UpdateGoldAmount);
        }

        void OnDisable() {
            foreach (var a in achievements) {
                a.Completed = false;
            }
            EventBroker.Instance().UnSubscribeFrom<GoldAmountChangedMessage>(UpdateGoldAmount);
        }

        void UpdateGoldAmount(GoldAmountChangedMessage message) {
            foreach (var a in achievements.Where(a => message.GoldAmount >= a.goal && !a.Completed)) {
                ActivateAchievement(a.goal, a.displayDuration);
                a.Completed = true;
            }
        }

        void ActivateAchievement(int goal, float displayDuration) {
            var prefab = Instantiate(textPrefab, transform);
            prefab.GetComponent<Text>().text = $"ACHIEVEMENT! You've earned {goal} gold!";
            StartCoroutine(DestroyAfterSeconds(displayDuration, prefab));
        }

        IEnumerator DestroyAfterSeconds(float seconds, Object item) {
            yield return new WaitForSeconds(seconds);
            Destroy(item);
        }
    }
}
