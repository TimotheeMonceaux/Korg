using TMPro;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private int Life;
    public int StartingLife;
    public TMP_Text LifeText;
    public int StartingGold;
    private int Gold;
    public TMP_Text GoldText;
    private int Ropes = 0;
    private int Caltrops = 0;
    private int Shields = 0;
    private int Potions = 0;
    private bool Sword = false;
    private bool Armor = false;



    // Start is called before the first frame update
    void Start()
    {
        SetLife(StartingLife);
        SetGold(StartingGold);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void SetLife(int newLife) 
    {
        Life = newLife;
        LifeText.SetText($"{Life}");
    }

    private void SetGold(int newGold) 
    {
        Gold = newGold;
        GoldText.SetText($"{Gold}");
    }

    public bool TakeDmg(int dmg)
    {
        if (Armor) dmg = Mathf.Min(0, dmg - 1);
        SetLife(Life - dmg);
        return Life <= 0;
    }

    public bool GetGold(int gold)
    {
        SetGold(Mathf.Min(99, Gold + gold));
        return true;
    }

    public bool BuyRope() 
    {
        if (Gold < 2) return false;
        SetGold(Gold - 2);
        ++Ropes;
        return true;
    }

    public bool BuyCaltrops() 
    {
        if (Gold < 2) return false;
        SetGold(Gold - 2);
        ++Caltrops;
        return true;
    }

    public bool BuyShield() 
    {
        if (Gold < 3) return false;
        SetGold(Gold - 3);
        ++Shields;
        return true;
    }

    public bool BuyPotion() 
    {
        if (Gold < 4) return false;
        SetGold(Gold - 4);
        ++Potions;
        return true;
    }

    public bool BuySword() 
    {
        if (Sword || Gold < 5) return false;
        SetGold(Gold - 5);
        Sword = true;
        return true;
    }

    public bool BuyArmor() 
    {
        if (Armor || Gold < 10) return false;
        SetGold(Gold - 10);
        Armor = true;
        return true;
    }

    public bool UseCaltrops() 
    {
        if (Caltrops < 1) return false;
        --Caltrops;
        return true;
    }

    public bool UseRope() 
    {
        if (Ropes < 1) return false;
        --Ropes;
        return true;
    }

    public bool HasSword() => Sword;
    public bool HasArmor() => Armor;
}
