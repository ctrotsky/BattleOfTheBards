using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

    public float max_Health;
    public float cur_Health = 0f;
    public float attack;
    public float defense;
    public string target;
    public GameObject healthBar;
    public static Boss Instance;

    public GameObject attackDebuffIcon;
    public GameObject defenseDebuffIcon;
    public CardManager cardManager;

    private float attackDebuff;
    private float defenseDebuff;

    private int attackDebuffTurns;
    private int defenseDebuffTurns;

    public bool taunted = false;

    // Use this for initialization
    void Start()
    {
        cur_Health = max_Health;
        ChooseTarget();
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

    public void ChooseTarget()
    {
        int rand = Random.Range(1, 4);
        if (rand == 1)
        {
            target = "warrior";
        }
        else if (rand == 2)
        {
            target = "mage";
        }
        else if (rand == 3)
        {
            target = "healer";
        }

        if (taunted)
        {
            target = "warrior";
        }
        
    }

    //BOSS ABILITIES
    public void Attack(float amount, float mod)
    {
        //TODO Implement Provoke

        Debug.Log("boss attacking " + target + " with attack " + attack);
        if (target == "warrior")
        {
            Warrior.Instance.TakeDamage(attack - attackDebuff);
        }
        else if (target == "mage")
        {
            Mage.Instance.TakeDamage(attack - attackDebuff);
        }
        else if (target == "healer")
        {
            Healer.Instance.TakeDamage(attack - attackDebuff);
        }
    }

    public void DebuffAttack(float amount, float mod)
    {
        amount *= -mod;
        if (target == "warrior")
        {
            Warrior.Instance.ModAttack(amount);
        }
        else if (target == "mage")
        {
            Mage.Instance.ModAttack(amount);
        }
        else if (target == "healer")
        {
            Healer.Instance.ModAttack(amount);
        }
    }

    public void DebuffDefense(float amount, float mod)
    {
        amount *= -mod;
        if (target == "warrior")
        {
            Warrior.Instance.ModDefense(amount);
        }
        else if (target == "mage")
        {
            Mage.Instance.ModDefense(amount);
        }
        else if (target == "healer")
        {
            Healer.Instance.ModDefense(amount);
        }
    }

    public void DebuffMyAttack(int turns, float amount)
    {      
        attackDebuffTurns = turns;
        attackDebuff = amount;
        attackDebuffIcon.SetActive(true);
    }

    public void DebuffMyDefense(int turns, float amount)
    {  
        defenseDebuffTurns = turns;
        defenseDebuff = amount;
        defenseDebuffIcon.SetActive(true);
    }

    public void Heal(float amount, float mod)
    {
        amount *= mod;
        Boss.Instance.HealDamage(amount);
    }

    public void Defend(float amount, float mod)
    {
        amount *= mod;
        Boss.Instance.ModDefense(amount);
    }



    //STATS
    // Update is called once per frame
    public void TakeDamage(float amount)
    {
        if ((amount - defense) > 0)
        {
            Debug.Log("Boss takes " + (amount - defense + defenseDebuff) + " damage");
            cur_Health -= (amount - defense + defenseDebuff);
            if (cur_Health <= 0)
            {
                //win
                cardManager.Win();
            }
        }
    }

    public void HealDamage(float amount)
    {
        cur_Health += amount;
    }

    public void ModAttack(float amount)
    {
        attack += amount;
    }

    public void ModDefense(float amount)
    {
        defense += amount;
    }

    public void TakeTurn()
    {
        if (attackDebuffTurns > 0)
        {
            attackDebuffTurns--;
        }
        if (defenseDebuffTurns > 0)
        {
            defenseDebuffTurns--;
        }
        if (attackDebuffTurns == 0)
        {
            attackDebuff = 0;
            attackDebuffIcon.SetActive(false);
        }
        if (defenseDebuffTurns == 0)
        {
            defenseDebuff = 0;
            defenseDebuffIcon.SetActive(false);
        }

        taunted = false;
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
