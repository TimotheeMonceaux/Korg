using System.Collections;
using TMPro;
using UnityEngine;

public class NotificationScript : MonoBehaviour
{
    public TMP_Text NotificationText;
    private static TMP_Text _notificationText;
    private static GameObject _parent;
    // Start is called before the first frame update
    void Start()
    {
        _notificationText = NotificationText;
        _parent = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void GainGoldAnimation(int gold) 
    {
        _notificationText.text = $"+ {gold} gold";
        _notificationText.color = new Color(0.631f,0.49f,0.106f);
        Instantiate(_notificationText, _parent.transform);
    }

    public static void SpendGoldAnimation(int gold) 
    {
        _notificationText.text = $"- {gold} gold";
        _notificationText.color = new Color(0.631f,0.49f,0.106f);
        Instantiate(_notificationText, _parent.transform);
    }

    public static void DamageAnimation(int dmg) 
    {
        _notificationText.text = $"- {dmg} hp";
        _notificationText.color = new Color(0.867f,0.0706f,0.0627f);
        Instantiate(_notificationText, _parent.transform);
    }

    public static void UseRopeAnimation() 
    {
        _notificationText.text = "- 1 rope";
        _notificationText.color = Color.white;
        Instantiate(_notificationText, _parent.transform);
    }

    public static void UseCaltropsAnimation() 
    {
        _notificationText.text = "- 1 rope";
        _notificationText.color = Color.white;
        Instantiate(_notificationText, _parent.transform);
    }

    public static void CustomAnimation(string customText) 
    {
        _notificationText.text = customText;
        _notificationText.color = Color.white;
        Instantiate(_notificationText, _parent.transform);
    }
}
