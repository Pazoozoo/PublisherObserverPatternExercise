using Publisher;
using UnityEngine;
using UnityEngine.UI;

namespace Observer {
    public class GoldView : MonoBehaviour {
        Text _goldAmountText;
    
        void Awake() {
            _goldAmountText = GetComponent<Text>();
            EventBroker.Instance().SubscribeTo<GoldAmountChangedMessage>(UpdateGoldText);
        }

        void OnDisable() {
            EventBroker.Instance().UnSubscribeFrom<GoldAmountChangedMessage>(UpdateGoldText);
        }

        void UpdateGoldText(GoldAmountChangedMessage message) {
            _goldAmountText.text = message.GoldAmount.ToString();
        }
    }
}