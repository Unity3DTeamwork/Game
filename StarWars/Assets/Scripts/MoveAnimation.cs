using UnityEngine;

namespace Assets.Scripts
{
    public class MoveAnimation : MonoBehaviour
    {
        private Animator _animator;

        private void Start()
        {
            this._animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            Animate();
        }
        private void Animate()
        {
            if (Character.Jump)
            {
                this._animator.SetTrigger("Jump");
                Character.Jumping = true;
                Character.Jump = false;
            }
            this._animator.SetBool("Moving", Character.Moving);
            this._animator.SetFloat("InputY", Character.VerticalSpeed);
            this._animator.SetFloat("InputX", Character.HorizontalSpeed);
        }

        public void FinishedJumping()
        {
            Character.Jumping = false;
            Debug.Log("a");
        }
    }
}