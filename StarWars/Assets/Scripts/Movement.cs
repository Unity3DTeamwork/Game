using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 _desiredMove;

    private void Start()
    {
        this._controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (this._controller.isGrounded)
        {
            this._desiredMove = this.transform.forward * InputHandler.VerticalInput +
                                this.transform.right * InputHandler.HorizontalInput;
        }
        this._desiredMove.y = -10;
        this._controller.Move(this._desiredMove);
    }
}
