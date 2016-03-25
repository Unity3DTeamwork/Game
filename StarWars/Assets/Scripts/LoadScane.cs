using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class LoadScane : MonoBehaviour {

    public void Load(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}
