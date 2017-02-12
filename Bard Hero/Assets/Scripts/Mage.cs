using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : MonoBehaviour {

    public float max_Health;
    public float cur_Health = 0f;
    public float attack;
    public float defense;
    public GameObject healthBar;
    public static Mage Instance;

    public GameObject attackBuffIcon;
    public GameObject defenseBuffIcon;

    public AnimationManager animationManager;
    public CardManager cardManager;

    private int attackBuffTurns;
    private int defenseBuffTurns;

    private float attackBuff = 0.0f;
    private float defenseBuff = 0.0f;

    // Use this for initialization
    void Start()
    {
        cur_Health = max_Health;
        Instance = this;
        //InvokeRepeating("decreaseHealth", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.transform.localScale = new Vector2(cur_Health / max_Health, healthBar.transform.localScale.y);
        //Display Defense Buff (Shield)
        //Dispay Attack Buff (Sword)
    }

    //WARRIOR ABILITIES
    public void DebuffAttack(float amount, float mod)
    {
        Boss.Instance.DebuffMyAttack(3, amount * mod);
    }

    public void DebuffDefense(float amount, float mod)
    {
        Boss.Instance.DebuffMyDefense(3, amount * mod);
    }

    public void Attack(float amount, float mod)
    {
        Boss.Instance.TakeDamage(amount + attackBuff * mod);
    }


    //STATS
    // Update is called once per frame
    public void TakeDamage(float amount)
    {
        if ((amount - defense) > 0)
        {
            cur_Health -= (amount - defense - defenseBuff);
            animationManager.MageHurt();
        }
        if (cur_Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        cur_Health = 0;
        cardManager.mageCardInHand.SetActive(false);
        cardManager.deadHands.Add(1);
        transform.gameObject.SetActive(false);
    }

    public void HealDamage(float amount)
    {
        cur_Health += amount;
        if (cur_Health > 100)
        {
            cur_Health = 100;
        }
    }

    public void ModAttack(float amount)
    {
        attack += amount;
    }

    public void ModDefense(float amount)
    {
        defense += amount;
    }

    public void BuffMyAttack(int turns, float buff)
    {
        attackBuff = buff;
        attackBuffTurns = turns;
        attackBuffIcon.SetActive(true);
    }

    public void BuffMyDefense(int turns, float buff)
    {
        defenseBuff = buff;
        defenseBuffTurns = turns;
        defenseBuffIcon.SetActive(true);
    }

    public void TakeTurn()
    {
        if (attackBuffTurns > 0)
        {
            attackBuffTurns--;
        }
        if (defenseBuffTurns > 0)
        {
            defenseBuffTurns--;
        }
        if (attackBuffTurns == 0)
        {
            attackBuff = 0;
            attackBuffIcon.SetActive(false);
        }
        if (defenseBuffTurns == 0)
        {
            defenseBuff = 0;
            defenseBuffIcon.SetActive(false);
        }
    }


    //FOR TESTING
    /*
    void decreaseHealth()
    {
        cur_Health -= 2f;
        float calc_Health = cur_Health / max_Health;
    }
    */
}
