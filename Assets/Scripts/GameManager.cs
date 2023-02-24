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

    private float timer;
    public float minTime;
    public float maxTime;

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
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            SpawnPlatform();
            timer = Random.Range(minTime, maxTime);
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
        plat.transform.position = new Vector2(spawnX, lastSpawnHeight + dif);
        plat.transform.parent = null;
        plat.transform.localScale = new Vector3(Random.Range(platormLengthMin, platormLengthMax), plat.transform.localScale.y, plat.transform.localScale.z);
        lastSpawnHeight += dif;
        lastPlatform = plat;
    }

}
