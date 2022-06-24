using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject Gun;
    public float TimeReload = 5f;
    public bool AllowShot = true;
    public GameObject PlayerObj;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerStatus.HP = PlayerStatus.maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && AllowShot)
        {
            Instantiate(BulletPrefab, Gun.transform.position, BulletPrefab.transform.rotation);
            TimeReload = 5;
            AllowShot = false;
        }
        if (AllowShot == false)
        {
            ReLoadGun();
        }
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
        }
    }
    public void Die()
    {
        if (PlayerStatus.HP <= 0)
        {
            Destroy(PlayerObj);
        }
    }

    private void PlayerModeDraw()
    {
        switch (PlayerStatus.playerModeState)
        {
            case PlayerStatus.PlayerModeState.Red:
                PlayerObj.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 255);
                break;
            case PlayerStatus.PlayerModeState.Yellow:
                PlayerObj.GetComponent<SpriteRenderer>().color = new Color32(255, 235, 4, 255);
                break;
            case PlayerStatus.PlayerModeState.Blue:
                PlayerObj.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 255, 255);
                break;
        }
    }
   

}

