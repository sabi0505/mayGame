using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneMove : MonoBehaviour
{
    public string name;
    public void Button()
    {
        SceneManager.LoadScene(name);
    }
}
