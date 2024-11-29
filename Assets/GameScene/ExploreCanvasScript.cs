using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ExploreCanvasScript : MonoBehaviour, IPointerClickHandler
{
    public GameObject Prefab;
    public PlayerScript PlayerScript;
    public void OnPointerClick(PointerEventData eventData)
    {
        var go = Instantiate(Prefab);
        var script = go.transform.GetComponent<RuinsExplorationManagerScript>();
        script.PlayerScript = PlayerScript;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
