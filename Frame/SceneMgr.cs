using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour {


    //单例
    private static readonly GameObject instance = new GameObject("SceneMgr");
    private static SceneMgr component;

    public static SceneMgr GetSingleton()
    {
        if(!component)
        {
            component = instance.AddComponent<SceneMgr>();
            if(!component)
                throw new System.NullReferenceException();
            DontDestroyOnLoad(instance);
        }
        return component;
    }

	// Use this or initialization
	void Start () {
		
	}
	
    /// <summary>
    /// 加载主场景
    /// </summary>
    public void LoadMainScene()
    {
        SceneManager.LoadSceneAsync((int)Scenelag.SCENE_MAIN, LoadSceneMode.Single);
    }

    /// <summary>
    /// IOS登录返回
    /// </summary>
    void IOSLoginBack(string strLogin)
    {
        Debug.Log ("----------------------IOSLoginBack  "+strLogin);
        SceneManager.LoadSceneAsync((int)Scenelag.SCENE_LOGIN, LoadSceneMode.Single);
    }

    /// <summary>
    /// 加载登录场景
    /// </summary>
    public void LoadLoginScene()
    {
        SceneManager.LoadSceneAsync((int)Scenelag.SCENE_LOGIN, LoadSceneMode.Single);
    }

    /// <summary>
    /// 加载AR场景
    /// </summary>
    /// <returns>The AR scene.</returns>
    public void LoadARScene()
    {
        SceneManager.LoadSceneAsync((int)Scenelag.SCENE_AR, LoadSceneMode.Single);
    }

}
