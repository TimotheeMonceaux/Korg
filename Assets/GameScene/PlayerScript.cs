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
        Application.targetFrameRate = 60;
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
        if (Shields > 0) return UseShield();
        if (Armor) dmg = Mathf.Min(0, dmg - 1);
        SetLife(Life - dmg);
        NotificationScript.DamageAnimation(dmg);
        return Life <= 0;
    }

    public bool GetGold(int gold)
    {
        SetGold(Mathf.Min(99, Gold + gold));
        NotificationScript.GainGoldAnimation(gold);
        return true;
    }

    public bool BuyRope() 
    {
        if (Gold < 2) {
            NotificationScript.CustomAnimation("Not enough gold");
            return false;
        }
        SetGold(Gold - 2);
        ++Ropes;
        NotificationScript.SpendGoldAnimation(2);
        return true;
    }

    public bool BuyCaltrops() 
    {
        if (Gold < 2) {
            NotificationScript.CustomAnimation("Not enough gold");
            return false;
        }
        SetGold(Gold - 2);
        ++Caltrops;
        NotificationScript.SpendGoldAnimation(2);
        return true;
    }

    public bool BuyShield() 
    {
        if (Gold < 3) {
            NotificationScript.CustomAnimation("Not enough gold");
            return false;
        }
        SetGold(Gold - 3);
        ++Shields;
        NotificationScript.SpendGoldAnimation(1);
        return true;
    }

    public bool BuyPotion() 
    {
        if (Gold < 4) {
            NotificationScript.CustomAnimation("Not enough gold");
            return false;
        }
        SetGold(Gold - 4);
        ++Potions;
        NotificationScript.SpendGoldAnimation(4);
        return true;
    }

    public bool BuySword() 
    {
        if (Sword) {
            NotificationScript.CustomAnimation("Out of stock");
            return false;
        }   
        if (Gold < 5) {
            NotificationScript.CustomAnimation("Not enough gold");
            return false;
        }
        SetGold(Gold - 5);
        Sword = true;
        NotificationScript.SpendGoldAnimation(5);
        return true;
    }

    public bool BuyArmor() 
    {
        if (Armor) {
            NotificationScript.CustomAnimation("Out of stock");
            return false;
        }   
        if (Gold < 10) {
            NotificationScript.CustomAnimation("Not enough gold");
            return false;
        }
        SetGold(Gold - 10);
        Armor = true;
        NotificationScript.SpendGoldAnimation(10);
        return true;
    }

    public bool UseCaltrops() 
    {
        if (Caltrops < 1) {
            NotificationScript.CustomAnimation("Not enough caltrops");
            return false;
        }
        --Caltrops;
        NotificationScript.UseCaltropsAnimation();
        return true;
    }

    public bool UseRope() 
    {
        if (Ropes < 1) {
            NotificationScript.CustomAnimation("Not enough ropes");
            return false;
        }
        --Ropes;
        NotificationScript.UseRopeAnimation();
        return true;
    }

    public bool UseShield() 
    {
        if (Shields < 1) {
            return false;
        }
        --Shields;
        NotificationScript.UseShieldAnimation();
        return true;
    }

    public bool UsePotion(int roll) 
    {
        if (Potions < 1) {
            NotificationScript.CustomAnimation("Not enough potions");
            return false;
        }
        --Potions;
        SetLife(Mathf.Min(50, Life + roll));
        NotificationScript.HealAnimation(roll);
        return true;
    }

    public bool HasSword() => Sword;
    public bool HasArmor() => Armor;
}
