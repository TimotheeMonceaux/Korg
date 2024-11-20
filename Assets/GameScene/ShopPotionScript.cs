using UnityEngine;
using UnityEngine.EventSystems;

public class ShopPotionScript : MonoBehaviour, IPointerClickHandler
{
    public PlayerScript PlayerScript;
    public void OnPointerClick(PointerEventData eventData)
    {
        PlayerScript.BuyPotion();
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
