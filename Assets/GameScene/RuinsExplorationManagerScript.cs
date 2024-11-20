using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;

public class RuinsExplorationManagerScript : MonoBehaviour
{
    public GameObject Dice;
    public GameObject Parent;
    public PlayerScript PlayerScript;
    public SpriteRenderer MonsterSpriteRenderer;
    public TMP_Text MonsterName;
    public TMP_Text MonsterStats;
    public Sprite PitTrapSprite;
    public Sprite SkeletonSprite;
    public Sprite GoblinSprite;
    public Sprite WraithSprite;
    public Sprite OgreSprite;
    public Sprite DemonSprite;
    public int DiceValue;
    public Enemy CurrentEnemy;
    private Dictionary<int, Enemy> _enemiesDict;
    public ExplorationState State = ExplorationState.Idle;
    
    void Start() 
    {
        _enemiesDict = new Dictionary<int, Enemy> {
            {1, new Enemy {Sprite = PitTrapSprite, Name = "Pit Trap", Atk = 3, Def = null, Effect = "Take 3 DMG", Gold = 0}},
            {2, new Enemy {Sprite = SkeletonSprite, Name = "Skeleton", Atk = 2, Def = 2, Effect = null, Gold = 1}},
            {3, new Enemy {Sprite = GoblinSprite, Name = "Goblin", Atk = 2, Def = 3, Effect = null, Gold = 2}},
            {4, new Enemy {Sprite = WraithSprite, Name = "Wraith", Atk = 2, Def = 5, Effect = null, Gold = 4}},
            {5, new Enemy {Sprite = OgreSprite, Name = "Ogre", Atk = 4, Def = 4, Effect = null, Gold = 7}},
            {6, new Enemy {Sprite = DemonSprite, Name = "Demon", Atk = 4, Def = 6, Effect = null, Gold = 10}},
        };
        State = ExplorationState.ToDrawEnemy;
    }

    void Update() {
        switch(State) {
            case ExplorationState.Idle:
                break;
            case ExplorationState.ToDrawEnemy:
                StartCoroutine(DrawNewEnemy());
                break;
            case ExplorationState.ToFight:
                State = ExplorationState.Idle;
                StartCoroutine(FightEnemy());
                break;
        }
    }

    public void FightOrFlee(Action action)
    {
        if (State == ExplorationState.Idle) {
            if (action == Action.Fight) State = ExplorationState.ToFight;
            else {
                if ((CurrentEnemy.Def == null && PlayerScript.UseRope()) || PlayerScript.UseCaltrops()) 
                    DestroyImmediate(Parent);
            }
        }
    }

    private IEnumerator DrawNewEnemy() 
    {
        State = ExplorationState.Rolling;
        DiceValue = RollDice();
        yield return new WaitForSeconds(5f);
        CurrentEnemy = _enemiesDict[DiceValue];
        MonsterSpriteRenderer.sprite = CurrentEnemy.Sprite;
        MonsterName.text = CurrentEnemy.Name;
        MonsterStats.text = CurrentEnemy.Def != null ? $"ATK: {CurrentEnemy.Atk}\nDEF: {CurrentEnemy.Def}" : CurrentEnemy.Effect;
        State = ExplorationState.Idle;
    }

    private IEnumerator FightEnemy() 
    {

        if (CurrentEnemy.Def == null)
        {
            PlayerScript.TakeDmg(CurrentEnemy.Atk);
            MonsterSpriteRenderer.sprite = null;
            MonsterName.text = "";
            MonsterStats.text = "";
            State = ExplorationState.ToDrawEnemy;
            yield break;
        }
        State = ExplorationState.Rolling;
        DiceValue = RollDice();
        yield return new WaitForSeconds(5f);
        if (DiceValue >= CurrentEnemy.Def - (PlayerScript.HasSword() ? 1 : 0)) {
            MonsterSpriteRenderer.sprite = null;
            MonsterName.text = "";
            MonsterStats.text = "";
            PlayerScript.GetGold(CurrentEnemy.Gold);
            yield return new WaitForSeconds(1f);
            State = ExplorationState.ToDrawEnemy;
        }
        else {
            PlayerScript.TakeDmg(CurrentEnemy.Atk);
            State = ExplorationState.Idle;
        }
    }

    private int RollDice() 
        => Instantiate(Dice).GetComponent<DiceScript>().Roll();
    

    public enum ExplorationState
    {
        Idle,
        Rolling,
        ToDrawEnemy,
        ToFight
    }

    public record Enemy 
    {
        public Sprite Sprite;
        public string Name;
        public int Atk;
        public int? Def;
        public string Effect;
        public int Gold;
    }
}