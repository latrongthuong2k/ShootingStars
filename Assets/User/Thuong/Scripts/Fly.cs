using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    private int HP = 200;
    public float speed = 6f;
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
            switch (statusPrefab)
            {
                case"Red":
                    if (PlayerStatus.playerModeState == PlayerStatus.PlayerModeState.Red)
                    {
                        PlayerStatus.ScoreRed++;
                    }
                    else
                    {
                        PlayerStatus.ScoreRed--;
                    }
                    break;
                case "Yellow":
                    if (PlayerStatus.playerModeState == PlayerStatus.PlayerModeState.Yellow)
                    {
                        PlayerStatus.ScoreYellow++;
                    }
                    else
                    {
                        PlayerStatus.ScoreYellow--;
                    }
                    break;
                case "Blue":
                    if (PlayerStatus.playerModeState == PlayerStatus.PlayerModeState.Blue)
                    {
                        PlayerStatus.ScoreBlue++;
                    }
                    else
                    {
                        PlayerStatus.ScoreBlue--;
                    }
                    break;
                case "Green":
                    if (PlayerStatus.playerModeState == PlayerStatus.PlayerModeState.Green)
                    {
                        PlayerStatus.ScoreGreen++;
                    }
                    else
                    {
                        PlayerStatus.ScoreGreen--;
                    }
                    break;
            }
            Destroy(gameObject);
            Instantiate(deathEffect, transform.position, Quaternion.identity);
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
