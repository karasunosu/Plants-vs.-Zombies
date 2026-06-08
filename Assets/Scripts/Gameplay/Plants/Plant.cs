using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] int starCost;
    [SerializeField] IState currentState;
    [SerializeField] Animator animator;

    string animCurrent = "";

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
}
