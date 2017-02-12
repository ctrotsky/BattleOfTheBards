using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour {
    public ParticleSystem warriorAttackEffect;
    public ParticleSystem defendEffect;
    public ParticleSystem provokeEffect;

    public ParticleSystem lightningEffect;
    public ParticleSystem gustEffect;
    public ParticleSystem explosionEffect;

    public ParticleSystem warriorHealEffect;
    public ParticleSystem mageHealEffect;
    public ParticleSystem healerHealEffect;
    public ParticleSystem powerUpEffect;

    public GameObject warrior;
    public GameObject mage;
    public GameObject healer;

    private Animator warriorAnim;
    private Animator mageAnim;
    private Animator healerAnim;


    void Start()
    {
        warriorAnim = warrior.GetComponent<Animator>();
        mageAnim = mage.GetComponent<Animator>();
        healerAnim = healer.GetComponent<Animator>();
    }


    public void WarriorAttack()
    {
        warriorAttackEffect.Play();
        warriorAnim.Play("WarriorAttack");
    }

    public void Defend()
    {
        defendEffect.Play();
    }
    public void Provoke()
    {
        provokeEffect.Play();
    }

    public void Lightning()
    {
        mageAnim.Play("MageAttack");
        lightningEffect.Play();
    }
    public void Gust()
    {
        mageAnim.Play("MageAttack");
        gustEffect.Play();
    }
    public void Explosion()
    {
        mageAnim.Play("MageAttack");
        explosionEffect.Play();
    }

    public void WarriorHeal()
    {
        healerAnim.Play("HealerAttack");
        warriorHealEffect.Play();
    }
    public void MageHeal()
    {
        healerAnim.Play("HealerAttack");
        mageHealEffect.Play();
    }
    public void HealerHeal()
    {
        healerAnim.Play("HealerAttack");
        healerHealEffect.Play();
    }
    public void PowerUp()
    {
        healerAnim.Play("HealerAttack");
        powerUpEffect.Play();
    }






    public void WarriorHurt()
    {
        warriorAnim.Play("WarriorHurt");
    }

    public void MageHurt()
    {
        mageAnim.Play("MageHurt");
    }

    public void HealerHurt()
    {
        healerAnim.Play("HealerHurt");
    }

}
