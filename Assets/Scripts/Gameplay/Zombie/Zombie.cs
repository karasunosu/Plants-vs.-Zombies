using Unity.VisualScripting;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] IState currentState;
    [SerializeField] Animator animator;

    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    string currentAnim = "";

    void Update()
    {
        if(currentState != null)
        {
            currentState.Execute();
        }
    }

    public void ChangeState(IState state)
    {
        // if(currentState != null && currentState.GetType() == state.GetType()) { return; }

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
        if(anim != currentAnim)
        {
            if(!currentAnim.Equals("")) animator.ResetTrigger(currentAnim);
            currentAnim = anim;
            animator.SetTrigger(currentAnim);
        }
    }

    public bool IsAttackable(float y)
    {
        return Mathf.Abs(transform.position.y - y) < 0.01f;
    }

    public const string Zombie_Tag = "Zombie";
}
