using UnityEngine;
using System.Collections;
using System.Net.Mime;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Collisions : MonoBehaviour {

    public Text scoreLbl;

    private int playerHealth = 100;

    private int score = 0;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == 8 && transform.tag != "Saber")
        {
            this.playerHealth -= 10;
            if (this.playerHealth <=0)
            {
                SceneManager.LoadScene("GameOver");
            }
            Debug.Log("Player hit " + this.playerHealth);
        }
        else if (col.gameObject.layer == 9 && transform.tag != "EnemySaber")
        {
            score++;
            Destroy(col.gameObject);

            Debug.Log("Enemy hit " + col.gameObject.layer + " " + col.gameObject.tag);
            scoreLbl.text = string.Format("Score : {0}", score.ToString());
        }
    }
}