using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 class SpawnObj : MonoBehaviour
{
    private float spawnRangeX = 10;
    private float spawnRangeY = 4;
    private float StarRepeatingAtTime = 3f;
    private float Timerepeat = 0.3f; // repeating every 0.3 second;
    private int rateFastStar;
    public GameObject[] StarObjectPrefab;
    public GameObject warningObj;
    private int RandomNum;
    /// <summary>
    /// 
    /// </summary>
    public static bool AllowSpawn;
    public GameObject Secretboard;
    private bool allowUpdate;
    /// <summary>
    /// 
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        allowUpdate = false;
        AllowSpawn = false;
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    public void ButtonOkEvent()
    {
        if (AllowSpawn == false)
        {
            AllowSpawn = true;
            InvokeRepeating(nameof(SpawnRandomObj), StarRepeatingAtTime, Timerepeat);
            Secretboard.gameObject.SetActive(false);
        }
        else
        {
            AllowSpawn = false;
        }
    }
    void SpawnRandomObj()
    {
        RandomNum = Random.Range(0, 5);
        Vector3 Spawnpos = new Vector3(spawnRangeX, Random.Range(spawnRangeY, -spawnRangeY), 0);
        
        switch (RandomNum)
        {
            case 0:
                PlayerStatus.objModeState = PlayerStatus.ObjModeState.Red;
                Instantiate(StarObjectPrefab[RandomNum], Spawnpos, StarObjectPrefab[RandomNum].transform.rotation);
                break;
            case 1:
                PlayerStatus.objModeState = PlayerStatus.ObjModeState.Yellow;
                Instantiate(StarObjectPrefab[RandomNum], Spawnpos, StarObjectPrefab[RandomNum].transform.rotation);
                break;
            case 2:
                PlayerStatus.objModeState = PlayerStatus.ObjModeState.Blue;
                Instantiate(StarObjectPrefab[RandomNum], Spawnpos, StarObjectPrefab[RandomNum].transform.rotation);
                break;
            case 3:
                PlayerStatus.objModeState = PlayerStatus.ObjModeState.Green;
                Instantiate(StarObjectPrefab[RandomNum], Spawnpos, StarObjectPrefab[RandomNum].transform.rotation);
                break;
            case 4:
                rateFastStar = Random.Range(0, 4);
                if (rateFastStar == 0)
                {
                    float localY = Random.Range(spawnRangeY, -spawnRangeY);
                    Vector3 SpawnPosFastStars = new Vector3(70f, localY , 0);
                    Vector3 SpawnPosWaring = new Vector3(8.36f, localY, 0);
                    PlayerStatus.objModeState = PlayerStatus.ObjModeState.FastStar;
                    Instantiate(StarObjectPrefab[RandomNum], SpawnPosFastStars, StarObjectPrefab[RandomNum].transform.rotation);
                    Instantiate(warningObj, SpawnPosWaring, warningObj.transform.rotation);
                }
                break;
        }
    }
}
