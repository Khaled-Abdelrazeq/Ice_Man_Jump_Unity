using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private GameObject speedPlatformPrefab;

    //public int numberOfPlatform;

    private float levelWidth = 2;
    private float levelMaxHeight = 1.5f;
    private float levelMinHeight = 0.5f;
    private float numberOfSpeedPlatform;

    private bool generateSpeed = false;

    private void Awake()
    {
        randomizeSpeedPlatform();
    }

    void Start()
    {        
        //numberOfPlatform = PlayerPrefs.GetInt("Level " + GameManager.instance.levelNumber, 100);
        generatePlatform();        
    }

    void Update()
    {
        destroyPlayform();
    }


    private void randomizeSpeedPlatform()
    {
        numberOfSpeedPlatform = Random.Range(0, 100);
        if (numberOfSpeedPlatform > 96)
            generateSpeed = true;
        else
            generateSpeed = false;

        print(numberOfSpeedPlatform);
    }

    private void generatePlatform()
    {
        Vector3 spawnPoints = new Vector3();

        for(int i=0; i<GameManager.instance.numberOfPlatforms; i++)
        {
            spawnPoints.x = Random.Range(-levelWidth, levelWidth);
            spawnPoints.y += Random.Range(levelMinHeight, levelMaxHeight);
            
            GameObject platform = Instantiate(platformPrefab, spawnPoints, Quaternion.identity);
            GameManager.instance.platforms.Add(platform);

            if (generateSpeed)
            {
                spawnPoints.x = Random.Range(-levelWidth, levelWidth);
                spawnPoints.y += Random.Range(levelMinHeight, levelMaxHeight);

                Instantiate(speedPlatformPrefab, spawnPoints, Quaternion.identity);                
            }

            randomizeSpeedPlatform();

        }
        GameManager.instance.platforms[GameManager.instance.numberOfPlatforms - 1].transform.tag = "LastPlatform";

        
    }

    private void destroyPlayform()
    {
        for(int i=0; i< GameManager.instance.platforms.Count; i++)
        {
            if (GameManager.instance.platforms[i] != null)
            {
                if (Mathf.Abs(Camera.main.transform.position.y) - Mathf.Abs(GameManager.instance.platforms[i].transform.position.y) > 4)
                {
                    Destroy(GameManager.instance.platforms[i]);
                }
            }
        }
    }
}
