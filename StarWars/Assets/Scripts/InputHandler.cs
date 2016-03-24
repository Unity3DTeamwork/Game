using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public static bool Arming;
    public static bool Sprinting;
    public static bool Jumping;
    public static bool Attacking;
    public static float VerticalInput;
    public static float HorizontalInput;
    public static float MouseXAxis;
    public static float MouseYAxis;

	void Update ()
	{
        VerticalInput = Input.GetAxis("Vertical");
        HorizontalInput = Input.GetAxis("Horizontal");
        Sprinting = Input.GetButton("Sprint") && VerticalInput != 0;
        Jumping = Input.GetButtonDown("Jump");
	    Arming = Input.GetButtonDown("Arming");
	    Attacking = Input.GetMouseButtonDown(0);
	    MouseXAxis = Input.GetAxis("Mouse X");
	    MouseYAxis = Input.GetAxis("Mouse Y");
	    if (!Sprinting) return;
	    VerticalInput *= 2;
	    HorizontalInput = 0;
	}
}
