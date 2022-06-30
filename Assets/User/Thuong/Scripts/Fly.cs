using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    private int HP = 200;
    public float speed = 5f;
    public GameObject deathEffect;
    private float leftBlock = -11f;
    public string statusPrefab;
    
    
    private void Awake()
    {
        statusPrefab = PlayerStatus.objModeState.ToString();
        if (statusPrefab == "FastStar" )
        {
            speed = 15f;
            
        }
    }
    // Update is called once per frame

    void Update()
    {
        
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        if (transform.position.x < leftBlock)
        {
            Destroy(gameObject);
        }
    }
    
    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (statusPrefab != PlayerStatus.playerModeState.ToString() && !other.gameObject.CompareTag("Bullet"))
        {
              PlayerStatus.HP -= 20;
              Destroy(gameObject);
              Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
    }
}
