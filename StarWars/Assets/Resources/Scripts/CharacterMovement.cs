using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class CharacterMovement : MonoBehaviour
    {
        private CharacterController _controller;
        private Vector3 _desiredMove;
        [SerializeField]
        private float _mouseSensitivity = 10f;
        [SerializeField]
        private float _gravity = 10f;
        private Animator _animator;


        private void Start()
        {
            this._controller = GetComponent<CharacterController>();
            this._animator = GetComponent<Animator>();
        }


        private void Update()
        {
            AnimateMovement();
        }
        private void FixedUpdate()
        {
            Character.Grounged = this._controller.isGrounded;
            this._desiredMove = Vector3.zero;
            if (this._controller.isGrounded)
            {
                if (Character.Jump )
                {
                    Jump();
                }
                else
                {
                    Run();
                }
            }

            if (!Character.Jumping)
                this._desiredMove.y = -this._gravity;

            this._controller.Move(this._desiredMove);
            this.transform.Rotate(0f, InputHandler.MouseXAxis * this._mouseSensitivity, 0f);
        }

        private void Jump()
        {
            Character.Jumping = true;
            Character.Jump = false;
            this._animator.SetTrigger("Jump");
        }

        private void Run()
        {
            this._desiredMove = this.transform.forward * Character.VerticalSpeed /
                                (Character.Armed ? 10 : 5) +
                                this.transform.right * Character.HorizontalSpeed /
                                (Character.Armed ? 10 : 5);
        }

        private void AnimateMovement()
        {
            this._animator.SetBool("Moving", Character.Moving);
            this._animator.SetFloat("InputY", Character.VerticalSpeed);
            this._animator.SetFloat("InputX", Character.HorizontalSpeed);
        }
        public void FinishedJumping()
        {
            Character.Jumping = false;
        }
    }
}