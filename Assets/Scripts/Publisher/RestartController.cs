using UnityEngine;
using UnityEngine.SceneManagement;

namespace Publisher {
    public class RestartController : MonoBehaviour {

        void Start() {
            EventBroker.InvokeOnRestartGame();
        }

        public void RestartGame() {
            EventBroker.InvokeOnRestartGame();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
