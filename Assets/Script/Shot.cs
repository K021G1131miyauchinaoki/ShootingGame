using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject Bullet;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Bullet,transform.position,Quaternion.identity);
        }
    }
}
