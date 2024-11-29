using System.Collections;
using TMPro;
using UnityEngine;

public class NotificationTextScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AnimationCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator AnimationCoroutine()
    {
        var text = gameObject.GetComponent<TMP_Text>();
        var up = new Vector3(0, 0.02f, 0);
        gameObject.transform.position = new Vector3(Random.Range(-2f,2f), gameObject.transform.position.y, gameObject.transform.position.z);
        gameObject.SetActive(true);
        var elapsedTime = 0f;
        while (elapsedTime < 2f) {
            elapsedTime += Time.deltaTime;
            gameObject.transform.position += up;
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - 0.005f);
            yield return null;
        }
        DestroyImmediate(gameObject);
    }
}
