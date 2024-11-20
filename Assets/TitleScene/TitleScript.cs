using System.Collections;
using UnityEngine;
using TMPro;

public class TitleScript : MonoBehaviour
{
    public TMP_Text tmpText;
    public float FadeInStartDelay;
    public float FadeInDuration;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeIn(FadeInStartDelay, FadeInDuration));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator FadeIn(float startDelay, float duration) 
    {
        yield return new WaitForSeconds(startDelay);
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            tmpText.color = new Color(tmpText.color.r, tmpText.color.g, tmpText.color.b, Mathf.Clamp01(elapsedTime / duration));
            tmpText.outlineColor = new Color(tmpText.outlineColor.r, tmpText.outlineColor.g, tmpText.outlineColor.b, Mathf.Clamp01(elapsedTime / duration));
            yield return null;
        }
    }
}
