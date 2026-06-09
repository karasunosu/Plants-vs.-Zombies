using System;
using Unity.VisualScripting;
using UnityEngine;

public class Plant : MonoBehaviour, IDamageable
{
    [SerializeField] int starCost;
    [SerializeField] IState currentState;
    [SerializeField] Animator animator;
    [SerializeField] float maxHp = 100f;
    
    [SerializeField] float currentHp;
    public bool isDead = false;

    string animCurrent = "";

    void Start()
    {
        currentHp = maxHp;
    }

    void Update()
    {
        if(currentState != null)
        {
            currentState.Execute();
        }
    }

    public void ChangeState(IState state)
    {
        if(currentState != null && currentState.GetType() == state.GetType()) 
        {
            return;
        }

        if(currentState != null)
        {
            currentState.Exit();
        }
        
        currentState = state;

        if(currentState != null)
        {
            currentState.Enter();
        }
    }

    public void ChangeAnim(string anim)
    {
        if(anim != animCurrent)
        {
            if(!animCurrent.Equals("")) animator.ResetTrigger(animCurrent);
            animCurrent = anim;
            animator.SetTrigger(animCurrent);
        }
    }

    public int GetStarCost()
    {
        return starCost;
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;

        if(currentHp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        Destroy(gameObject);
    }

    public const string PLANT_TAG = "Plant";
    public const string PEA_BULLET_TAG = "Pea Bullet";
    public const string SNOW_PEA_BULLET_TAG = "Snow Pea Bullet";
}
