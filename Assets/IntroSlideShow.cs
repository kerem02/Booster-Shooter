using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroSlideShow : MonoBehaviour
{
    public Sprite[] slides;
    public float slideDuration = 2f;
    public string nextSceneName = "Level1";

    private Image image;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(ShowSlides());
    }

    IEnumerator ShowSlides()
    {
        for (int i= 0; i < slides.Length; i++)
        {
            image.sprite = slides[i];
            yield return new WaitForSeconds(slideDuration);
        }

        SceneManager.LoadScene(nextSceneName);
    }
}
