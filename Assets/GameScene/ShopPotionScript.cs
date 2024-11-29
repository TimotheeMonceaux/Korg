using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopPotionScript : MonoBehaviour, IPointerClickHandler
{
    public PlayerScript PlayerScript;
    public GameObject Dice;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (PlayerScript.BuyPotion()) 
            StartCoroutine(UsePotion());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator UsePotion() {
        var roll = RollDice();
        yield return new WaitForSeconds(5f);
        PlayerScript.UsePotion(roll);
    }

    private int RollDice() 
        => Instantiate(Dice).GetComponent<DiceScript>().Roll();
}
