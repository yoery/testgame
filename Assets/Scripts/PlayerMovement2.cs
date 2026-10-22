using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement2 : MonoBehaviour
{
    public float speed = 5f;

    [SerializeField] private Animator animator;

    void Update()
    {
        float horizontal = 0f;
        float vertical = 0f;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
                horizontal = -1f;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
                horizontal = 1f;
            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
                vertical = -1f;
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
                vertical = 1f;
        }

        Vector3 movement = new Vector3(horizontal, vertical, 0f).normalized;
        transform.Translate(movement * speed * Time.deltaTime);

        bool isMoving = movement.sqrMagnitude > 0f;
        animator.SetBool("IsRunning", isMoving);

        if (isMoving)
        {
            if (Mathf.Abs(horizontal) >= Mathf.Abs(vertical))
            {
                animator.SetFloat("MoveX", horizontal);
                animator.SetFloat("MoveY", 0f);
            }
            else
            {
                animator.SetFloat("MoveX", 0f);
                animator.SetFloat("MoveY", vertical);
            }
        }
    }
}