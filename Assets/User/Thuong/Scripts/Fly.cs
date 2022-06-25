using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public int HP = 100;
    public float speed = 5f;
    private float leftBlock = -11f;
    private string statusPrefab;
    public Sprite[] sprites;
    public int SpawnSpriteIndex;

    private void Awake()
    {
        
        statusPrefab = PlayerStatus.objModeState.ToString();
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


        if (statusPrefab != PlayerStatus.playerModeState.ToString())
        {
            Destroy(gameObject);
            if (!other.gameObject.CompareTag("Bullet"))
            {
                PlayerStatus.HP -= 20;
            }
        }
    }
}
