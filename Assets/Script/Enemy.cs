using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //�̗͕ϐ�
    private int enemyHp;
    // Start is called before the first frame update
    void Start()
    {
        enemyHp = 3;
    }

    public  void    Damage()
    {
        //Enemy�̗̑͂�1���炷
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
