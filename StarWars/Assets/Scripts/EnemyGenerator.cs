using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {
    
    public GameObject enemy;

    private int score = 0;

  //  private float time = 100f;

    private float timeDelta;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", 0, 10);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawn()
    {
        int spawnX = Random.Range(600, 2000);

        int spawnz = Random.Range(1500, 2100);
        Instantiate(enemy, new Vector3(spawnX, 300, spawnz), transform.rotation);
    }
}