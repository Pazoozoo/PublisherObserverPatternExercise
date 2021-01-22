using System;
using UnityEngine;

namespace Publisher {
    public class GoldController : MonoBehaviour {
        int _gold;
        RestartController _rs;
    
        public delegate void GoldChangeDelegate(int newGoldAmount);
        public event GoldChangeDelegate GoldAmountChanged;

        void Start() {
            _rs = FindObjectOfType<RestartController>();
            _rs.OnRestartGame += ResetGold;
        }

        void OnDisable() {
            _rs.OnRestartGame -= ResetGold;
        }

        int Gold {
            get => _gold;
            set {
                if (value < 0)
                    value = 0;
                _gold = value;
            
                GoldAmountChanged?.Invoke(Gold);
            }
        }

        public void AddGold(int value) {
            Gold += value;
        }

        void ResetGold() {
            Gold = 0;
            GoldAmountChanged?.Invoke(Gold);
        }
    }
}
