using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObj : MonoBehaviour
{
    private float spawnRangeX = 10;
    private float spawnRangeY = 4;
    private float StarRepeatingAtTime = 2f;
    private float Timerepeat = 0.3f; // repeating every 0.3 second;
    public GameObject StarObjectPrefab;
   

    // Start is called before the first frame update
    void Start()
    { 
        
        InvokeRepeating("SpawnRandomObj", StarRepeatingAtTime, Timerepeat);
        
    }

    // Update is called once per frame
    void Update()
    {
       Timerepeat = Random.Range(0, 0.2f);
        SetColorMode();
        ObjModeDraw();

    }
    void SpawnRandomObj()
    {
        Vector3 Spawnpos = new Vector3(spawnRangeX, Random.Range(spawnRangeY, -spawnRangeY), 0);
        Instantiate(StarObjectPrefab, Spawnpos, StarObjectPrefab.transform.rotation);
    }
    
    void SetColorMode()
    {
        int RandomNum = Random.Range(0, 3);
        switch(RandomNum)
        {
            case 0:
                PlayerStatus.objModeState = PlayerStatus.ObjModeState.Red;
                break;
            case 1:
                PlayerStatus.objModeState = PlayerStatus.ObjModeState.Yellow;
                break;
            case 2:
                PlayerStatus.objModeState = PlayerStatus.ObjModeState.Blue;
                break;

        }
       
    }
    private void ObjModeDraw()
    {
        switch (PlayerStatus.objModeState)
        {
            case PlayerStatus.ObjModeState.Red:
                StarObjectPrefab.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 255);
                break;
            case PlayerStatus.ObjModeState.Yellow:
                StarObjectPrefab.GetComponent<SpriteRenderer>().color = new Color32(255, 235, 4, 255);
                break;
            case PlayerStatus.ObjModeState.Blue:
                StarObjectPrefab.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 255, 255);
                break;
        }
    }

}
