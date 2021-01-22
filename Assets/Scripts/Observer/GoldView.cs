using Publisher;
using UnityEngine;
using UnityEngine.UI;

namespace Observer {
    public class GoldView : MonoBehaviour {
        Text _goldAmountText;
        GoldController _gc;
    
        void Start() {
            _goldAmountText = GetComponent<Text>();
            _gc = FindObjectOfType<GoldController>();
            _gc.GoldAmountChanged += UpdateGoldText;
        }

        void OnDisable() {
            _gc.GoldAmountChanged -= UpdateGoldText;
        }

        void UpdateGoldText(int goldAmount) {
            _goldAmountText.text = goldAmount.ToString();
        }
    }
}