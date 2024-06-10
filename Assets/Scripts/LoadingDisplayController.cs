using System.Collections;
using UnityEngine;

public class LoadingDisplayController : MonoBehaviour
{
    public static LoadingDisplayController Instance;
    public GameObject backgroung;
    
    void Awake()
    {
        if (!Instance)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(this);
        StartCoroutine(Tick(1f));
    }

    public void ShowDiaplay(float seconds) 
    {
        StartCoroutine(Tick(seconds));
    }

    IEnumerator Tick(float seconds) 
    {
        backgroung.SetActive(true);
        yield return new WaitForSeconds(seconds);
        backgroung.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveToSceneFromTime("Scene_Lobby", 1);
        }
    }

    public void MoveToSceneFromTime(string sceneName, float time) 
    {
        StartCoroutine(Tick(time));
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void HideDisplay() 
    {
        backgroung.SetActive(false);
    }
}