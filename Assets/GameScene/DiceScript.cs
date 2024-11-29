using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour
{
    private int Value = 1;
    private bool AnimationTrigger = false;
    public Sprite Sprite1;
    public Sprite Sprite2;
    public Sprite Sprite3;
    public Sprite Sprite4;
    public Sprite Sprite5;
    public Sprite Sprite6;
    public SpriteRenderer Renderer;
    private Dictionary<int, Sprite> _spriteDict;

    // Start is called before the first frame update
    void Start()
    {
        _spriteDict = new Dictionary<int, Sprite> {
            {1, Sprite1}, {2, Sprite2}, {3, Sprite3},
            {4, Sprite4}, {5, Sprite5}, {6, Sprite6}
        };
    }

    // Update is called once per frame
    void Update() 
    {
        if (AnimationTrigger) {
            AnimationTrigger = false;
            StartCoroutine(RollAnimation());
        }
    }

    public int Roll() 
    {
        Value = Random.Range(1,7);
        AnimationTrigger = true;
        return Value;
    }

    private IEnumerator RollAnimation() 
    {
        float elapsedTime = 0f;
        gameObject.transform.position = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), gameObject.transform.position.z);
        while(elapsedTime < 1f) {
            elapsedTime += Time.deltaTime;
            Renderer.sprite = _spriteDict[Random.Range(1,7)];
            yield return null;
        }
        float timeInterval = 0.05f;
        while(elapsedTime < 2f) {
            elapsedTime += timeInterval;
            Renderer.sprite = _spriteDict[Random.Range(1,7)];
            timeInterval += 0.05f;
            yield return new WaitForSeconds(timeInterval);
        }
        Renderer.sprite = _spriteDict[Value];
        yield return new WaitForSeconds(2f);
        Renderer.sprite = null;
        DestroyImmediate(gameObject);
    }
}
