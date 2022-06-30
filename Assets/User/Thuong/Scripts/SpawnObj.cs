using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    { 
        InvokeRepeating("SpawnRandomObj", StarRepeatingAtTime, Timerepeat);
        
    }

    // Update is called once per frame
    void Update()
    {
        Timerepeat = Random.Range(0, 0.2f);

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
                rateFastStar = Random.Range(0, 3);
                if (rateFastStar == 0)
                {
                    float localY = Random.Range(spawnRangeY, -spawnRangeY);
                    Vector3 SpawnPosFastStars = new Vector3(50f, localY , 0);
                    Vector3 SpawnPosWaring = new Vector3(8.36f, localY, 0);
                    PlayerStatus.objModeState = PlayerStatus.ObjModeState.FastStar;
                    Instantiate(StarObjectPrefab[RandomNum], SpawnPosFastStars, StarObjectPrefab[RandomNum].transform.rotation);
                    Instantiate(warningObj, SpawnPosWaring, warningObj.transform.rotation);
                }
                break;
        }
    }
}
