using UnityEngine;

namespace Publisher {
    public class GoldController : MonoBehaviour {
        int _gold;

        void Awake() {
            EventBroker.Instance().SubscribeTo<RestartGameMessage>(ResetGold);
        }

        void OnDisable() {
            EventBroker.Instance().UnSubscribeFrom<RestartGameMessage>(ResetGold);
        }

        int Gold {
            get => _gold;
            set {
                if (value < 0)
                    value = 0;
                _gold = value;
                
                EventBroker.Instance().Send(new GoldAmountChangedMessage(Gold));
            }
        }

        public void AddGold(int value) {
            Gold += value;
        }

        void ResetGold(RestartGameMessage message) {
            Gold = 0;
            EventBroker.Instance().Send(new GoldAmountChangedMessage(Gold));
        }
    }
}
