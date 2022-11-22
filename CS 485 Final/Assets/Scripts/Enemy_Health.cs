using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    //Enemy Current Health
    public int Health = 100;

    //The Enemy Object
    public GameObject itself;

    //Enemy Collider
    public Collider2D m_Collider;
    //For if it is dead
    public bool isDead = false;

    //Player Animator
    public Animator enemyAnimator;

    //Enemy Attack Value
    public int AtkVal = 20;

    //Rigidbody
    public Rigidbody2D rb;

    bool isInvincible = false;

    void Awake()
    {
        m_Collider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        if (this.tag == "Enemy")
        {
            enemyAnimator = GetComponent<Animator>();
        }
    }

    //For Taking Damage
    public void isHit(int atkValue)
    {
        if(isDead == false)
        {
            if(isInvincible == false)
            {
                if(Health > 0)
                {
                    enemyAnimator.SetTrigger("isHit");
                    Health -= atkValue;
                }
                if(Health <= 0)
                {
                    enemyAnimator.SetTrigger("isDead");
                    isDead = true;
                    rb.constraints = RigidbodyConstraints2D.FreezePosition;
                    m_Collider.enabled = false;
                    Destroy(itself,2f);
                    //FindObjectOfType<AudioManager>().Play("enemyDeath");
                }
            }
        }
    }

    //returns damage value
    public int returnDamVal()
    {
        return AtkVal;
    }

    public void InvincibleSwitch()
    {
        isInvincible = !isInvincible;
    }
}
