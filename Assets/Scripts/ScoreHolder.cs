using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHolder : MonoBehaviour
{
    public int Score;

    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] obs = GameObject.FindGameObjectsWithTag(gameObject.tag);
        if (obs.Length > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }

}
