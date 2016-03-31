using UnityEngine;

namespace Assets.Scripts
{
    public class CharacterMovement : MonoBehaviour
    {
        private CharacterController _controller;
        private Vector3 _desiredMove;
        [SerializeField]
        private float _mouseSensitivity = 10f;
    

        private void Start()
        {
            this._controller = GetComponent<CharacterController>();
        }

        private void Update()
        {
            Character.Grounged = this._controller.isGrounded;
            this._desiredMove = Vector3.zero;
            if (this._controller.isGrounded && Character.Moving)
            {
                this._desiredMove = this.transform.forward * Character.VerticalSpeed / (Character.Armed ? 10 : 5)+
                                    this.transform.right * Character.HorizontalSpeed / (Character.Armed ? 10 : 5);
            }
            this._desiredMove.y = -10;
            this._controller.Move(this._desiredMove);
            this.transform.Rotate(0f, InputHandler.MouseXAxis * this._mouseSensitivity, 0f);
        }
    }
}