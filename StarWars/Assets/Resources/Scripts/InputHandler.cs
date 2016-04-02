using UnityEngine;

namespace Assets.Scripts
{
    public class InputHandler : MonoBehaviour
    {
        public static float VerticalInput;
        public static float HorizontalInput;
        public static float MouseXAxis;
        public static float MouseYAxis;
        public static bool Sprint;
        public static bool Jump;
        public static bool Arm;
        public static bool Attack;


        private void Update()
        {
            Sprint = Input.GetButton("Sprint");
            Jump = Input.GetButtonDown("Jump");
            Arm = Input.GetButtonDown("Arm");
            Attack = Input.GetMouseButtonDown(0);
            MouseXAxis = Input.GetAxis("Mouse X");
            MouseYAxis = Input.GetAxis("Mouse Y");
            VerticalInput = Input.GetAxis("Vertical");
            HorizontalInput = Input.GetAxis("Horizontal");
        
        }
    }
}