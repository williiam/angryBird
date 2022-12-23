using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class level4 : MonoBehaviour
{
    public AudioClip btnClick;
    public AudioSource btnPlayer;
    private float btnClickTime = 0.261f;
    private GameObject bgm;
    // Start is called before the first frame update
    void Start()
    {
        btnPlayer = GetComponent<AudioSource>();
        bgm = GameObject.FindWithTag("bgm");
        GetComponent<Button>().onClick.AddListener(startcoroutine);
    }

    private void startcoroutine() {
        btnPlayer.PlayOneShot(btnClick);
        StartCoroutine(LoadLevel4());
    }

    IEnumerator LoadLevel4() {
        yield return new WaitForSeconds(btnClickTime);
        if(PlayerPrefs.GetInt("levelUnlock", 0) >= 4) {
            bgm.GetComponent<AudioSource>().Stop();
            SceneManager.LoadScene(5);
        }
        yield return null;
    }
}
