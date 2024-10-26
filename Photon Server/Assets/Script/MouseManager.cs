using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseManager : MonoBehaviour
{
    [SerializeField] Texture2D texture2D;

    private static MouseManager instance;

    public static MouseManager Instance { get { return instance; } }

    private void Awake()
    {
        Cursor.SetCursor(texture2D, Vector2.zero, CursorMode.ForceSoftware);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void SetMouse(bool state)
    {
        Cursor.visible = state;
        Cursor.lockState = (CursorLockMode)Convert.ToInt32(!state);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        switch (scene.buildIndex)
        {
            case 2:
                SetMouse(false);
                break;
            default:
                SetMouse(true);
                break;

        }
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}