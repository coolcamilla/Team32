using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerDig))]
public class PlayerAnimator : MonoBehaviour
{
    public static PlayerAnimator Instance { get; private set; }

    private Animator _animator;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _animator = GetComponent<Animator>();
        }
        else
        {
            Destroy(gameObject);
        }

        GetComponent<PlayerDig>().OnVerticalDirectionChange += ChangeVerticalDirection;
        GetComponent<PlayerDig>().OnAnyDig += SetMiningTrigger;
    }

    public static void ChangeInstrument(ItemType itemType)
    {
        if (Instance != null)
            Instance._animator.SetInteger("ToolKey", (int)itemType);
    }

    public static void SetMiningTrigger()
    {
        if (Instance != null)
            Instance._animator.SetTrigger("Mining");
    }

    public static void ChangeWalkingState(bool isWalking)
    {
        if (Instance != null)
            Instance._animator.SetBool("IsWalking", isWalking);
    }

    public static void ChangeVerticalDirection(float direction)
    {
        if (Instance != null)
            Instance._animator.SetInteger("Vertical direction", (int)direction);
    }

    public static void ChangeClimbingState(bool isClimbing)
    {
        if (Instance != null)
            Instance._animator.SetBool("IsClimbing", isClimbing);
    }

    public static void ChangeGroundedState(bool isGrounded)
    {
        if (Instance != null)
            Instance._animator.SetBool("IsGrounded", isGrounded);
    }
}