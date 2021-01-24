using UnityEngine;
using UnityEngine.UI;

namespace Observer {
    public class GoldView : MonoBehaviour {
        Text _goldAmountText;
    
        void Awake() {
            _goldAmountText = GetComponent<Text>();
            EventBroker.OnGoldAmountChanged += UpdateOnGoldText;
        }

        void OnDisable() {
            EventBroker.OnGoldAmountChanged -= UpdateOnGoldText;
        }

        void UpdateOnGoldText(int goldAmount) {
            _goldAmountText.text = goldAmount.ToString();
        }
    }
}