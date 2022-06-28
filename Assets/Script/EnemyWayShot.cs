using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWayShot : MonoBehaviour
{
    //プレイヤー
    private GameObject player;
    //弾のゲームオブジェクトを入れる
    public GameObject bullet;
    //一回で打ち出す弾数を決める
    public int bulletWayNum = 3;
    //打ち出す弾の間隔を調節する
    public float bulletWaySpace = 30;
    //打ち出す弾の角度を調節する
    public float bulletWayAxis = 0;
    //打ち出す間隔を決める
    public float time = 1;
    //最初に打ち出すまでの時間を決める
    public float delayTime = 1;
    //現在のタイマー時間
    float nowtime = 0;

    private void CreateShotObject(float axis)
    {
        //弾を生成
        GameObject bulletClone = Instantiate(bullet, transform.position, Quaternion.identity);

        //EnemyBulletのゲットコンポーネントを変数として保存
        var bulletObject = bulletClone.GetComponent<EnemyBullet>();

        //弾を打ち出したオブジェクトの情報を渡す
        bulletObject.SetCharacterObject(gameObject);

        //弾を打ち出す角度を変更する
        bulletObject.SetForwardAxis(Quaternion.AngleAxis(axis, Vector3.up));
    }

    // Start is called before the first frame update
    void Start()
    {
        nowtime = delayTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (player==null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        nowtime -= Time.deltaTime;

        if (nowtime <= 0)
        {
            //角度調節
            float bulletWaySpaceSplit = 0;

            for (int i = 0; i < bulletWayNum; i++)
            {
                //弾生成
                CreateShotObject(
                    bulletWaySpace - bulletWaySpaceSplit + bulletWayAxis - transform.localEulerAngles.y);

                bulletWaySpaceSplit+=(bulletWaySpace/(bulletWayNum-1))*2;
            }
            //タイマーを初期化
            nowtime = time;
        }
    }
}
