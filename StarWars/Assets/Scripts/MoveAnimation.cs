using UnityEngine;

public class MoveAnimation : MonoBehaviour
{
    private Animator _animator;
    private float _verticalInput;
    private float _horizontalInput;
    private float _rotateSpeed = 10f;
    private bool _runing;
    private bool _moving;
    private bool _jump;

    private void Start()
    {
        //Inicialization
        this._animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //Getting input 
        this._verticalInput = Input.GetAxis("Vertical");
        this._horizontalInput = Input.GetAxis("Horizontal");
        this._runing = Input.GetButton("Sprint");
        this.transform.Rotate(0f, Input.GetAxis("Mouse X") * this._rotateSpeed, 0f);
        this._jump = Input.GetButtonDown("Jump");
    }

    private void FixedUpdate()
    {
        if (this._runing && (this._verticalInput > 0 || this._verticalInput < 0))
        {
            //You cant steer while sprinting
            this._verticalInput *= 2;
            this._horizontalInput = 0;
        }
        if (this._verticalInput > 0 || this._verticalInput < 0 || this._horizontalInput > 0 || this._horizontalInput < 0)
            this._moving = true;
        else this._moving = false;
        Animate();
    }

    private void Animate()
    {
        if (this._jump)
        {
            this._animator.SetTrigger("Jump");
            this._jump = false;
        }
        this._animator.SetBool("Moving", this._moving);
        this._animator.SetFloat("InputY", this._verticalInput);
        this._animator.SetFloat("InputX", this._horizontalInput);
    }
}
