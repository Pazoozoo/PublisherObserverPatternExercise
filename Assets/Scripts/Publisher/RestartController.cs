using UnityEngine;
using UnityEngine.SceneManagement;

namespace Publisher {
    public class RestartController : MonoBehaviour {

        void Start() {
            EventBroker.Instance().Send(new RestartGameMessage());
        }

        public void RestartGame() {
            EventBroker.Instance().Send(new RestartGameMessage());
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
