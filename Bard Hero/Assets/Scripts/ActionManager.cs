using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour {

    public CardManager cardManager;
    public AnimationManager animationManager;

    public Warrior warrior;
    public Mage mage;
    public Healer healer;

    public void doAction(string cardTitle, float percentHit)
    {
        Debug.Log("Doing action: " + cardTitle);
        Debug.Log("Percent hit: " + percentHit);

        switch (cardTitle)
        {
            case "Attack":
                warrior.Attack(10.0f, percentHit);
                animationManager.WarriorAttack();
                break;
            case "Defend":
                //dont give buff if they suck
                if (percentHit > 0.5)
                {
                    animationManager.Defend();
                    warrior.Defend(5.0f, percentHit);
                }
                break;
            case "Provoke":
                warrior.Provoke();
                animationManager.Provoke();
                break;
            case "Lightning":
                animationManager.Lightning();
                mage.Attack(8.0f, percentHit);
                if (percentHit > 0.5)
                {
                    mage.DebuffAttack(8.0f, percentHit);
                }
                break;
            case "Gust":
                animationManager.Gust();
                mage.Attack(8.0f, percentHit);
                if (percentHit > 0.5)
                {          
                    mage.DebuffDefense(8.0f, percentHit);
                }
                break;
            case "Explosion":
                mage.Attack(14.0f, percentHit);
                animationManager.Explosion();
                break;
            case "Heal":
                healer.Heal(20.0f, percentHit);
                break;
            case "Healing Ballad":
                healer.GroupHeal(15.0f, percentHit);
                break;
            case "Power Up":
                if (percentHit > 0.5)
                {
                    animationManager.PowerUp();
                    healer.BuffAttack(6.0f, percentHit);
                }
                break;
        }

        Boss.Instance.ChooseTarget();
        Boss.Instance.Attack(10.0f, 1.0f);

        Warrior.Instance.TakeTurn();
        Mage.Instance.TakeTurn();
        Healer.Instance.TakeTurn();
        Boss.Instance.TakeTurn();



        //let the player select cards once action is done.
        cardManager.gameObject.SetActive(true);
    }
}
