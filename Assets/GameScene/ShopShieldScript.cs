using UnityEngine;
using UnityEngine.EventSystems;

public class ShopShieldScript : MonoBehaviour, IPointerClickHandler
{
    public PlayerScript PlayerScript;
    public void OnPointerClick(PointerEventData eventData)
    {
        PlayerScript.BuyShield();
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
