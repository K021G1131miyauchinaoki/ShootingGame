using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyForwardShot : MonoBehaviour
{
    //プレイヤー
    private GameObject player;
    //弾のゲームオブジェクトを入れる
    public GameObject bullet;
    //打ち出す間隔を決める
    public float time = 1;
    //最初に打ち出すまでの時間を決める
    public float delayTime = 1;
    //現在のタイマー時間
    float nowtime = 0;

    //弾生成
    private void CreateShotObject(float axis)
    {
        //ベクトルを取得
        var direction = player.transform.position - transform.position;

        //ベクトルのｙを初期化
        direction.y = 0;

        //向きを取得する
        var lookRotation = Quaternion.LookRotation(direction, Vector3.up);

        //弾を生成
        GameObject bulletClone = 
            Instantiate(bullet, transform.position, Quaternion.identity);

        //EnemyBulletのゲットコンポーネントを変数として保存
        var bulletObject = bulletClone.GetComponent<EnemyBullet>();

        //弾を打ち出したオブジェクトの情報を渡す
        bulletObject.SetCharacterObject(gameObject);

        //弾を打ち出す角度を変更する
        bulletObject.SetForwardAxis(lookRotation * Quaternion.AngleAxis(axis, Vector3.up));
    }


    //スタート関数
    void Start()
    {
        nowtime = delayTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        nowtime -= Time.deltaTime;

        if (nowtime <= 0)
        {
            //弾生成
            CreateShotObject(-transform.localEulerAngles.y);

            //タイマーを初期化
            nowtime = time;
        }
    }
}
