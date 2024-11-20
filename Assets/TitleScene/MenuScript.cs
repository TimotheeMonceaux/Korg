using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public TMP_Text StartGameText;
    public TMP_Text OptionsText;
    public TMP_Text ExitText;
    public SpriteRenderer Selector;
    public float FadeInStartDelay;
    public float FadeInDuration;
    private int Selected = 0;

    private Color SelectedColor = new Color(1f, 1f, 1f, 1f);
    private Color NotSelectedColor = new Color(0.5f, 0.5f, 0.5f, 1f);

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeIn(FadeInStartDelay, FadeInDuration));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && Selected < 2)
            UpdateColors(++Selected);
        else if (Input.GetKeyDown(KeyCode.UpArrow) && Selected > 0)
            UpdateColors(--Selected);
        else if (Input.GetKeyDown(KeyCode.Return))
            OnReturnPressed();
    }

    private IEnumerator FadeIn(float startDelay, float duration) 
    {
        yield return new WaitForSeconds(startDelay);
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            NotSelectedColor.a = Mathf.Clamp01(elapsedTime / duration);
            StartGameText.color = NotSelectedColor;
            OptionsText.color = NotSelectedColor;
            ExitText.color = NotSelectedColor;
            yield return null;
        }
        UpdateColors(Selected);
        Selector.color = SelectedColor;
    }

    private void UpdateColors(int selected) 
    {
        StartGameText.color = selected == 0 ? SelectedColor : NotSelectedColor;
        OptionsText.color = selected == 1 ? SelectedColor : NotSelectedColor;
        ExitText.color = selected == 2 ? SelectedColor : NotSelectedColor;
        Selector.transform.position = new Vector3(-4.5f + (0.5f * Selected), -1 - (1.5f * Selected), Selector.transform.position.z);
    }

    private void OnReturnPressed() 
    {
        if (Selected == 0) {
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }
        else if (Selected == 2) {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
    }
}
