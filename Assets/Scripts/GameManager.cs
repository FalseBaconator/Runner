using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject platform;
    public GameObject coin;
    GameObject player;

    public float coinHeight;
    public float coinHeight2;

    public float platormLengthMin;
    public float platormLengthMax;

    public float spawnHeightVariance;
    public float spawnHeightMinDist;
    private float lastSpawnHeight = 0;
    private float spawnX;

    private float platTimer;
    public float minTime;
    public float maxTime;
    private float coinTimer;
    public float coinTime;

    public float lossDist;

    GameObject lastPlatform;

    public int lossSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        Camera cam = Camera.main;
        spawnX = cam.orthographicSize * cam.aspect;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        platTimer -= Time.deltaTime;
        coinTimer -= Time.deltaTime;
        if(platTimer <= 0)
        {
            SpawnPlatform();
            platTimer = Random.Range(minTime, maxTime);
        }

        if(coinTimer <= 0)
        {
            coinTimer = coinTime;
            GameObject newCoin = Instantiate(coin);
            newCoin.transform.parent = null;
            int rand = Random.Range(0, 2);
            if(rand == 0)
                newCoin.transform.position = new Vector2(spawnX, lastSpawnHeight + coinHeight);
            else if (rand == 1)
                newCoin.transform.position = new Vector2(spawnX, lastSpawnHeight + coinHeight2);
        }

        if(Vector2.Distance(player.transform.position, lastPlatform.transform.position) > lossDist)
        {
            SceneManager.LoadScene(lossSceneIndex);
        }
    }

    void SpawnPlatform()
    {
        GameObject plat = GameObject.Instantiate(platform);
        float dif = Random.Range(-spawnHeightVariance, spawnHeightVariance);
        if (Mathf.Abs(dif) < spawnHeightMinDist)
        {
            if (dif < 0)
                dif = -spawnHeightMinDist;
            else if (dif >= 0)
                dif = spawnHeightMinDist;
        }
        plat.transform.localScale = new Vector3(Random.Range(platormLengthMin, platormLengthMax), plat.transform.localScale.y, plat.transform.localScale.z);
        plat.transform.position = new Vector2(spawnX + plat.transform.localScale.x / 2, lastSpawnHeight + dif);
        plat.transform.parent = null;
        lastSpawnHeight += dif;
        lastPlatform = plat;
    }

}
