using UnityEngine;

public class PlayerMovementLogic
{
    public float Speed { get; set; } = 5f;
    public float JumpForce { get; set; } = 2f;
    public float ClimbSpeed { get; set; } = 5f;
    public float RotationSpeed { get; set; } = 90f;
    public float BaseGravityScale { get; set; } = 1.5f;

    public bool IsClimbing { get; private set; }
    public bool IsGrounded { get; set; }
    public float CurrentAngle { get; private set; }

    public float HorizontalInput { get; private set; }
    public float VerticalInput { get; private set; }

    public void SetHorizontalDirection(float dir)
    {
        HorizontalInput = dir;
    }
    public void SetVerticalDirection(float dir)
    {
        VerticalInput = dir;
    }

    public bool ToggleClimbMode(bool canStart)
    {
        if (!IsClimbing && !canStart) return false;

        IsClimbing = !IsClimbing;

        if (!IsClimbing) CurrentAngle = 0f;

        return true;
    }

    public void Tick(float deltaTime)
    {
        if (IsClimbing)
        {
            float rotationDelta = HorizontalInput * RotationSpeed * deltaTime;
            CurrentAngle = Mathf.Clamp(CurrentAngle + rotationDelta, -90f, 90f);
        }
    }

    public float GetTargetGravityScale()
    {
        return IsClimbing ? 0f : BaseGravityScale;
    }

    public Vector2 CalculateMovementVelocity()
    {
        if (!IsClimbing)
        {
            return new Vector2(HorizontalInput * Speed, 0f);
        }

        float rad = CurrentAngle * Mathf.Deg2Rad;
        Vector2 forwardDir = new Vector2(Mathf.Sin(rad), Mathf.Cos(rad));

        return forwardDir * VerticalInput * ClimbSpeed;
    }

    public bool IsMoving()
    {
        if (IsClimbing) return Mathf.Abs(VerticalInput) > 0.1f;
        return Mathf.Abs(HorizontalInput) > 0.1f;
    }

    public bool ShouldFlipX()
    {
        if (IsClimbing) return false;
        return HorizontalInput > 0;
    }

    public bool CanJump()
    {
        return !IsClimbing && IsGrounded;
    }

    public Vector2 GetJumpForceVector()
    {
        return Vector2.up * JumpForce;
    }

    public void ForceStopClimbing()
    {
        IsClimbing = false;
        CurrentAngle = 0f;
    }
}
