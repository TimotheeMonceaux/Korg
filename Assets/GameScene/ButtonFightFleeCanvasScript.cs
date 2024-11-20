using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonFightFleeCanvasScipt : MonoBehaviour, IPointerClickHandler
{
    public Action Action;
    public RuinsExplorationManagerScript Script;
    public void OnPointerClick(PointerEventData eventData)
    {
        Script.FightOrFlee(Action);
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
