using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOpener : MonoBehaviour
{
    public void OpenGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void BackTotitle()
    {
        SceneManager.LoadScene("Placeholder");
    }
}
