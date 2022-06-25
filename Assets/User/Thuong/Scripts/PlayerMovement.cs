using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float modeCounDownSec = 10f;
    public bool lockMode = false;
    public float BlockPush;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        SetOriginal();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
        if (lockMode == true)
        {
            CounDown();
        }
       
    }
    void Move()
    {
        float UpDown = Input.GetAxis("Vertical") * PlayerStatus.speed * Time.deltaTime;
        //float RightLeft = Input.GetAxis("Horizontal") * PlayerStatus.speed * Time.deltaTime;
        transform.Translate(0, UpDown, 0);
        if(gameObject.transform.position.y >= 4.6f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 4.6f, 0);           
        }
        else if(gameObject.transform.position.y <= -4.6f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, -4.6f, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerStatus.playerModeState == PlayerStatus.PlayerModeState.None && lockMode == false)
        {
            PlayerStatus.HP += 20;
            if (collision.gameObject.GetComponent<SpriteRenderer>().color == Color.red)
            {
                PlayerStatus.playerModeState = PlayerStatus.PlayerModeState.Red;
                gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 255);
                lockMode = true;
                modeCounDownSec = 10;
            }
            if (collision.gameObject.GetComponent<SpriteRenderer>().color == Color.yellow)
            {
                PlayerStatus.playerModeState = PlayerStatus.PlayerModeState.Yellow;
                gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 235, 4, 255);
                lockMode = true;
                modeCounDownSec = 10;
            }
            if (collision.gameObject.GetComponent<SpriteRenderer>().color == Color.blue);
            {
                PlayerStatus.playerModeState = PlayerStatus.PlayerModeState.Blue;
                gameObject.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 255, 255);
                lockMode = true;
                modeCounDownSec = 10;
            }
        }
    }
    private IEnumerator WaitForTakeDamage(float delay)
    {
        if (gameObject.transform.position.y > 4.6 || gameObject.transform.position.y < -4.6)
        {
            PlayerStatus.HP -= 10;
        }
        yield return new WaitForSeconds(delay);
        

    }
    private void SetOriginal()
    {
        if(lockMode == false)
        {
            PlayerStatus.playerModeState = PlayerStatus.PlayerModeState.None;
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }
    }
    private void CounDown()
    {
        if (modeCounDownSec > 0)
        {
            modeCounDownSec -= Time.deltaTime;
        }
        if (modeCounDownSec <= 0)
        {
            lockMode = false;
            SetOriginal();
        }
    }

}
