using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Publisher {
    public class RestartController : MonoBehaviour {
        public delegate void RestartGameDelegate();
        public RestartGameDelegate OnRestartGame;

        void Start() {
            OnRestartGame?.Invoke();
        }

        public void RestartGame() {
            OnRestartGame?.Invoke();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
