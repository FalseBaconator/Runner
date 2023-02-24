using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void SwitchScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void ResetScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        SwitchScene(0);
    }
}
