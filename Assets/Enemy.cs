using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //体力変数
    private int enemyHp;
    // Start is called before the first frame update
    void Start()
    {
        enemyHp = 3;
    }

    public  void    Damage()
    {
        //Enemyの体力を1減らす
        enemyHp = enemyHp - 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHp <=0)
        {
            Destroy(this.gameObject);

            Debug.Log(enemyHp);
        }
    }
}
