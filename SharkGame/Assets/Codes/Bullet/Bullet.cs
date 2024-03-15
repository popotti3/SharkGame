using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float currentSpeed = 5f;

private float lifespan = 2.5f;
    private float lifeTimer;
    
    void OnEnable()
    {
        lifeTimer = lifespan;
    }
    

    // Update is called once per frame
    void Update()
    {
        transform. Translate(Vector3.down * currentSpeed * Time.deltaTime);
        lifeTimer -= Time.deltaTime;
        if(lifeTimer <= 0)
        {
            BulletPoolManager.Instance.ReturnBullet(gameObject);
        }
    }
}
