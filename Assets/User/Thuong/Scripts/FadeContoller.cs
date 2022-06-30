using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeContoller : SingletonMonoBehaviour<FadeContoller>
{
    private static Canvas canvas;

    private static Image image;

    private bool _canLoadScene = true;

    private static void Init()
    {
        GameObject canvasObject = new GameObject("CanvasFade");
        canvas = canvasObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = 100;
        canvasObject.AddComponent<GraphicRaycaster>();

        image = new GameObject("ImageFade").AddComponent<Image>();
        image.transform.SetParent(canvas.transform, false);
        image.rectTransform.anchoredPosition = Vector3.zero;
        Camera camera = Camera.main;
        image.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        image.color = Color.clear;
        image.raycastTarget = false;

        DontDestroyOnLoad(canvas.gameObject);
        DontDestroyOnLoad(Instance.gameObject);
        canvasObject.AddComponent<FadeContoller>();
    }
    private void Start()
    {
        Init();
    }

     public void LoadScene(float interval, GameScene gamescene)
     {
         if (_canLoadScene)
         {
             StartCoroutine(Fade(interval, gamescene.ToString()));
         }
     }

    public IEnumerator Fade(float interval, string taransition2)
    {
        yield return FadeOut(interval, taransition2);

        yield return SceneManager.LoadSceneAsync(taransition2);

        yield return FadeIn(interval, taransition2);
    }

    public IEnumerator FadeOut(float interval,string sceneName)
    {
        _canLoadScene = false;
        float time = 0f;
        if (sceneName == "Game")
        {
            time = -1f;
        }else { time = 0f; }
        canvas.enabled = true;

        while (time <= interval)
        {
            float fadeAlpha = Mathf.Lerp(0f, 1f, time / interval);
            image.color = new Color(0.0f, 0.0f, 0.0f, fadeAlpha);
            time += Time.deltaTime;
            yield return null;
        }
    }

    public IEnumerator FadeIn(float interval, string sceneName)
    {
        _canLoadScene = true;
        float time = 0f;
        if (sceneName == "Game")
        {
            time = -1f;
        }
        else { time = 0f; }
        while (time <= interval)
        {
            float fadeAlpha = Mathf.Lerp(1f, 0f, time / interval);
            image.color = new Color(0.0f, 0.0f, 0.0f, fadeAlpha);
            time += Time.deltaTime;
            yield return null;
        }
        canvas.enabled = false;
    }


}