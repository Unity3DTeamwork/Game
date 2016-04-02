using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class LoadScane : MonoBehaviour {

        public void Load()
        {
            SceneManager.LoadScene("GameScene");
        }

        public void Exit()
        {
            Application.Quit();
            Debug.Log("Exit");
        }
    }
}