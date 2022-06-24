using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int Damage = 100;
    public float speed = 8f;
    private float rightBlock = 11f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        if (transform.position.x > rightBlock)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D hitPoint)
    {
        Fly fly = hitPoint.GetComponent<Fly>();
        if(fly != null)
        {
            fly.TakeDamage(Damage);
        }
        Destroy(gameObject);
    }
}
