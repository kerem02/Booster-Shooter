
using UnityEngine;

public class LaserShrink : MonoBehaviour
{
    
    [SerializeField] private float shrinkDuration = 2f;


    private float elapsedTime = 0f;
    [SerializeField] private Vector3 originalScale = new Vector3(1, 50, 1);
    private bool shrinking = false;
    [SerializeField] private GameObject LaserPivot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    

    void OnEnable()
    {
        
        transform.localScale = originalScale;
        shrinking = false;
    }

    void Update()
    {
        if (shrinking)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / shrinkDuration);
            float newY = Mathf.Lerp(originalScale.y, 0f, t);
            transform.localScale = new Vector3(originalScale.x, newY, originalScale.z);

            if (t >= 1f)
            {
                shrinking = false;
                Debug.Log("Shrink bitti");
                LaserPivot.SetActive(false);
            }
        }
    }

    public void StartShrink()
    {
        Debug.Log("Shrink baþladý");
        shrinking = true;
        elapsedTime = 0f;
    }
}
