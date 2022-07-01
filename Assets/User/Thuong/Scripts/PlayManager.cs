using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayManager : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject Gun;
    public float TimeReload;
    private int bulletSlot = 15;
    public GameObject PlayerObj;
    private GameObject trashEF;
    private GameObject trashEF2;
    private Timer2 Timer2;
    public bool AllowShot = true;
    private bool isSE = false;
    private AudioSource GunAudio;
    public AudioClip[] GunAudioClips;
    private GameObject Warning;
    public List<Text> Score4 = new List<Text>();

    // Start is called before the first frame update
    void Start()
    {
        Timer2 = GetComponent<Timer2>();
        GunAudio = GetComponent<AudioSource>();
        PlayerStatus.HP = PlayerStatus.maxHP;
        SoundManager.Instance.PlayBGM(0);

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && AllowShot )
        {
            Instantiate(BulletPrefab, Gun.transform.position, BulletPrefab.transform.rotation);
            GunAudio.PlayOneShot(GunAudioClips[0], 1f);
            bulletSlot -= 1;
            if (bulletSlot == 0)
            {
                TimeReload = 5f;
                AllowShot = false;
                Timer2.Being((int)TimeReload);
            }

        }
        if (AllowShot == false)
        {
            ReLoadGun();
        }
        UpdateTextScore();
        CleanEF();
        Die();
        ClearGame();
    }

    //---------------
    
    private void ReLoadGun()
    {
        if(TimeReload > 0 )
        {
            TimeReload -= Time.deltaTime;
        }
        if(TimeReload <= 0)
        {
            AllowShot = true;
            bulletSlot = 15;
        }
    }
    private void Die()
    {
        if (PlayerStatus.HP <= 0)
        {
            Destroy(PlayerObj);
            if (!isSE)
            {
                SoundManager.Instance.PlaySE(2);
                isSE = true;
            }
            SoundManager.Instance.StopBGM();
            FadeContoller.Instance.LoadScene(0.2f, GameScene.GameOver);
        }

    }
    private void ClearGame()
    {
        if(PlayerStatus.ScoreRed >= 5 && PlayerStatus.ScoreYellow >= 5 && PlayerStatus.ScoreBlue >= 5 && PlayerStatus.ScoreGreen >= 5 || Input.GetKey(KeyCode.A))
        {
            CleanScore();
            if (!isSE)
            {
                SoundManager.Instance.PlaySE(5);
                isSE = true;
            }
            SoundManager.Instance.StopBGM();
            FadeContoller.Instance.LoadScene(0.2f, GameScene.GameClear);
        }
    }
    private void CleanEF()
    {
        Warning = GameObject.Find("Warning(Clone)");
        trashEF = GameObject.Find("EnemyDeathEffect(Clone)");
        trashEF2 = GameObject.Find("ImpactEffect(Clone)");
        Destroy(Warning, 3f);
        Destroy(trashEF2, 1f);
        Destroy(trashEF, 1f);
    }
    private void UpdateTextScore()
    {
        Score4[0].text = PlayerStatus.ScoreRed.ToString();
        Score4[1].text = PlayerStatus.ScoreYellow.ToString();
        Score4[2].text = PlayerStatus.ScoreBlue.ToString();
        Score4[3].text = PlayerStatus.ScoreGreen.ToString();
    }
    private void CleanScore()
    {
        PlayerStatus.ScoreBlue = 0;
        PlayerStatus.ScoreRed = 0;
        PlayerStatus.ScoreYellow = 0;
        PlayerStatus.ScoreGreen = 0;
    }
       
}


    //private void PlayerModeDraw()
    //{
    //    switch (PlayerStatus.playerModeState)
    //    {
    //        case PlayerStatus.PlayerModeState.Red:
    //            PlayerObj.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 255);
    //            break;
    //        case PlayerStatus.PlayerModeState.Yellow:
    //            PlayerObj.GetComponent<SpriteRenderer>().color = new Color32(255, 235, 4, 255);
    //            break;
    //        case PlayerStatus.PlayerModeState.Blue:
    //            PlayerObj.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 255, 255);
    //            break;
    //    }
    //}



