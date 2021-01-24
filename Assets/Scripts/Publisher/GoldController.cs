using UnityEngine;

namespace Publisher {
    public class GoldController : MonoBehaviour {
        int _gold;

        void Awake() {
            EventBroker.OnRestartGame += ResetGold;
        }

        void OnDisable() {
            EventBroker.OnRestartGame -= ResetGold;
        }

        int Gold {
            get => _gold;
            set {
                if (value < 0)
                    value = 0;
                _gold = value;

                EventBroker.OnGoldAmountChanged.Invoke(Gold);
            }
        }

        public void AddGold(int value) {
            Gold += value;
        }

        void ResetGold() {
            Gold = 0;
            EventBroker.OnGoldAmountChanged.Invoke(Gold);
        }
    }
}
