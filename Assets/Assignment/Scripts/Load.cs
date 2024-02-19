using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    public void loadSceneNum(int i)
    {
        SceneManager.LoadScene(i);
    }
}
