using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float modeCounDownSec = 10f;
   
    public bool lockMode = false;
    public float BlockPush;
    public GameObject ColorMode;
    private AudioSource ModeAudio;
    public AudioClip modeAudioClips;
    private ModeTimer _modeTimer;
    // Start is called before the first frame update
    void Start()
    {
        _modeTimer = GetComponent<ModeTimer>();
        ModeAudio = GetComponent<AudioSource>();
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
            PlayerStatus.HP += 20; // fix HP Bug

            if (collision.gameObject.GetComponent<Fly>().statusPrefab == PlayerStatus.ObjModeState.Red.ToString())
            {
                ModeAudio.PlayOneShot(modeAudioClips, 1f);
                PlayerStatus.playerModeState = PlayerStatus.PlayerModeState.Red;
                ColorMode.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 255);
                //gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 255);
                ColorMode.SetActive(true);
                lockMode = true;
                modeCounDownSec = 10;
                _modeTimer.Being2((int)modeCounDownSec);
            }
            if (collision.gameObject.GetComponent<Fly>().statusPrefab == PlayerStatus.ObjModeState.Yellow.ToString())
            {
                ModeAudio.PlayOneShot(modeAudioClips, 1f);
                PlayerStatus.playerModeState = PlayerStatus.PlayerModeState.Yellow;
                ColorMode.GetComponent<SpriteRenderer>().color = new Color32(255, 235, 4, 255);
                //gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 235, 4, 255);
                ColorMode.SetActive(true);
                lockMode = true;
                modeCounDownSec = 10;
                _modeTimer.Being2((int)modeCounDownSec);
            }
            if (collision.gameObject.GetComponent<Fly>().statusPrefab == PlayerStatus.ObjModeState.Blue.ToString())
            {
                ModeAudio.PlayOneShot(modeAudioClips, 1f);
                PlayerStatus.playerModeState = PlayerStatus.PlayerModeState.Blue;
                ColorMode.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 255, 255);
                //gameObject.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 255, 255);
                ColorMode.SetActive(true);
                lockMode = true;
                modeCounDownSec = 10;
                _modeTimer.Being2((int)modeCounDownSec);
            }
            if (collision.gameObject.GetComponent<Fly>().statusPrefab == PlayerStatus.ObjModeState.Green.ToString())
            {
                ModeAudio.PlayOneShot(modeAudioClips, 1f);
                PlayerStatus.playerModeState = PlayerStatus.PlayerModeState.Green;
                ColorMode.GetComponent<SpriteRenderer>().color = new Color32(0, 255, 0, 255);
                //gameObject.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 255, 255);
                ColorMode.SetActive(true);
                lockMode = true;
                modeCounDownSec = 10;
                _modeTimer.Being2((int)modeCounDownSec);
            }
            //if (collision.gameObject.GetComponent<Fly>().statusPrefab == PlayerStatus.ObjModeState.FastStar.ToString())
            //{
            //    ModeAudio.PlayOneShot(modeAudioClips, 1f);
            //    PlayerStatus.playerModeState = PlayerStatus.PlayerModeState.Blue;
            //    ColorMode.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 255, 255);
            //    //gameObject.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 255, 255);
            //    ColorMode.SetActive(true);
            //    lockMode = true;
            //    modeCounDownSec = 10;
            //}
        }
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
            ColorMode.SetActive(false);
            lockMode = false;
            SetOriginal();
        }
    }

}
