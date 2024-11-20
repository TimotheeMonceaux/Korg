using UnityEngine;
using UnityEngine.EventSystems;

public class ShopArmorScript : MonoBehaviour, IPointerClickHandler
{
    public PlayerScript PlayerScript;
    public void OnPointerClick(PointerEventData eventData)
    {
        PlayerScript.BuyArmor();
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
