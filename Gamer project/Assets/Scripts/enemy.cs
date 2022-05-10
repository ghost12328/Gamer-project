using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class enemy : MonoBehaviour
{
    float zstart;
    float direction = 1f;
    private Animator animator;
    public float speed = .02f;
    public int enemyHp;
    private int enemy;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        zstart = transform.position.z;
        //feel free to change any of the int values, these are just placeholders for the code
        enemyHp = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        EnemyDeath();
    }
    void EnemyDeath()
    {
        
        if (enemyHp <= 0)
        {
            //Animation
            animator.SetInteger("Hp", 0);
            Destroy(this.gameObject, 2);
        }
    }
    void Move()
    {
        if(enemyHp > 0)
        {
            //controls the movement and speed of the enemies
            transform.Translate(new Vector3(0, 0, direction) * speed);

            //Animation
            animator.SetFloat("speed", speed);
        }
    }
 public void enemyHasDied()
    {
        enemyLeft--;
        print("enemyLeft");
        if (enemyLeft == 0)
        {
            {
                SceneManager.LoadScene("Victory");
            }
        }
    }

}
