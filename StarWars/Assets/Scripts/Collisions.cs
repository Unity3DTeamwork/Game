using UnityEngine;
using System.Collections;
using System.Net.Mime;

using Assets.Scripts;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Collisions : MonoBehaviour {

    public Text scoreLbl;

    public Text health;

    private int playerHealth = 100;

    private int score = 0;
    void OnTriggerEnter(Collider col)
    {
        if (transform.gameObject.layer == 8 && col.tag == "EnemySaber")
        {
            this.playerHealth -= 5;
            this.health.text = string.Format("Health : {0}", this.playerHealth.ToString());
           // this.health.text = string.Format("Health : {0}", this.playerHealth.ToString());
          
            if (this.playerHealth <=0)
            {
                SceneManager.LoadScene("GameScene");
            }
           
            Debug.Log("Player hit");
        }
        else if (col.gameObject.layer == 9)
        {
            score++;
            Destroy(col.gameObject);

            Debug.Log("Enemy hit");
            scoreLbl.text = string.Format("Score : {0}", score.ToString());
        }
    }
}