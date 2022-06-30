using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject Gun;
    private float TimeReload = 5f;
    private int bulletSlot = 5;
    public GameObject PlayerObj;
    private GameObject trashEF;
    private GameObject trashEF2;
    public bool AllowShot = true;
    private bool isSE = false;
    private float timecount = 3f;
    private bool lockTimeCount = true;
    private AudioSource GunAudio;
    public AudioClip[] GunAudioClips;
    public GameObject Warning;


    // Start is called before the first frame update
    void Start()
    {
        GunAudio = GetComponent<AudioSource>();
        PlayerStatus.HP = PlayerStatus.maxHP;
        SoundManager.Instance.PlayBGM(0);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) /* && AllowShot */)
        {
            Instantiate(BulletPrefab, Gun.transform.position, BulletPrefab.transform.rotation);
            GunAudio.PlayOneShot(GunAudioClips[0], 1f);
            //bulletSlot -= 1;
            //if(bulletSlot == 0)
            //{
            //    TimeReload = 5;
            //    AllowShot = false;
            //}
           
        }
        //if (AllowShot == false)
        //{
        //    ReLoadGun();
        //}
        CleanEF();
        Die();
    }
    
    void ReLoadGun()
    {
        if(TimeReload > 0)
        {
            TimeReload -= Time.deltaTime;
            Debug.Log(TimeReload);
        }
        if(TimeReload <= 0)
        {
            AllowShot = true;
            bulletSlot = 2;
        }
    }
    public void Die()
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
    void CleanEF()
    {
        Warning = GameObject.Find("Warning(Clone)");
        trashEF = GameObject.Find("EnemyDeathEffect(Clone)");
        trashEF2 = GameObject.Find("ImpactEffect(Clone)");
        Destroy(Warning, 3f);
        Destroy(trashEF2, 1f);
        Destroy(trashEF, 1f);
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



