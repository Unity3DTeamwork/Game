using UnityEngine;

public class MoveAnimation : MonoBehaviour
{
    private Animator _animator;
    private float _rotateSpeed = 10f;
    private bool _moving;

    private void Start()
    {
        this._animator = GetComponent<Animator>();
    }

    private void Update()
    {
        this.transform.Rotate(0f, InputHandler.MouseXAxis * this._rotateSpeed, 0f);
    }

    private void FixedUpdate()
    {
         if(InputHandler.VerticalInput > 0 || InputHandler.VerticalInput < 0 || InputHandler.HorizontalInput > 0 || InputHandler.HorizontalInput < 0)
            this._moving = true;
        else this._moving = false;
        Animate();
    }

    private void Animate()
    {
        if (InputHandler.Jumping)
        {
            this._animator.SetTrigger("Jump");
            InputHandler.Jumping = false;
        }
        this._animator.SetBool("Moving", this._moving);
        this._animator.SetFloat("InputY", InputHandler.VerticalInput);
        this._animator.SetFloat("InputX", InputHandler.HorizontalInput);
    }
}
