using UnityEngine;
using UnityEngine.SceneManagement;

namespace Publisher {
    public class RestartController : MonoBehaviour {

        void Start() {
            EventBroker.OnRestartGame.Invoke();
        }

        public void RestartGame() {
            EventBroker.OnRestartGame.Invoke();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
