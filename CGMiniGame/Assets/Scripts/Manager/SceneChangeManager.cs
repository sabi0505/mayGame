using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneList
{
    Intro,
    Main
}

public static class SceneChangeManager
{
    public static void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public static void ChangeScene(SceneList scene)
    {
        SceneManager.LoadScene((int)scene);
    }
}
