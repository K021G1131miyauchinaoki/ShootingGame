using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    //発生されるパーティクルを設定
    public GameObject particle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            GameObject[] enemyBulletObjects =
                GameObject.FindGameObjectsWithTag("EnemyBullet");
            for (int i = 0; i < enemyBulletObjects.Length; i++)
            {
                Destroy(enemyBulletObjects[i].gameObject);
            }
            //パーティクルを持ったオブジェクトを生成する
            Instantiate(particle, Vector3.zero, Quaternion.identity);
        }
    }
}
