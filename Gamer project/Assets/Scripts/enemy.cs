using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    float zstart;
    float direction = 1f;
    public float speed = .02f;
    private int enemyHp;
    // Start is called before the first frame update
    void Start()
    {
        zstart = transform.position.z;
        //feel free to change any of the int values, these are just placeholders for the code
        enemyHp = 10;
    }

    // Update is called once per frame
    void Update()
    {
        //controls the movement and speed of the enemies
        transform.Translate(new Vector3(0, 0, direction) * speed);
    }
    void EnemyDeath()
    {
        if (enemyHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
