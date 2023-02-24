using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AutoScroll : MonoBehaviour
{

    public float speed;
    Camera cam;
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        if (transform.position.x + transform.localScale.x < -(cam.orthographicSize * cam.aspect))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("ScoreHolder").GetComponent<ScoreHolder>().Score++;
            text = GameObject.FindGameObjectWithTag("Text").GetComponent<TextMeshProUGUI>();
            text.text = "COINS: " + GameObject.FindGameObjectWithTag("ScoreHolder").GetComponent<ScoreHolder>().Score++;
            Destroy(gameObject);
        }
    }

}
