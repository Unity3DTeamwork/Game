using UnityEngine;

namespace Assets.Scripts
{
    public class Character : MonoBehaviour
    {
        public static bool Moving;
        public static bool Armed;
        public static bool Arming;
        public static bool Sprinting;
        public static bool Jumping;
        public static bool Attacking;
        public static bool Grounged;
        public static float VerticalSpeed;
        public static float HorizontalSpeed;
        public static bool Jump;

        private void Start()
        {
            Armed = true;
        }

        private void Update()
        {
            SetValues();
        }

        private static void SetValues()
        {
            Sprinting = InputHandler.Sprint && InputHandler.VerticalInput != 0;
            if (!Jumping)
                Jump = InputHandler.Jump;
            VerticalSpeed = Arming
                ? InputHandler.VerticalInput / 2
                : (Sprinting ? InputHandler.VerticalInput * 2 : InputHandler.VerticalInput);
            HorizontalSpeed = Arming ? InputHandler.HorizontalInput / 2 : (Sprinting ? 0 : InputHandler.HorizontalInput);
            if ((InputHandler.VerticalInput > 0 || InputHandler.VerticalInput < 0 || InputHandler.HorizontalInput > 0 ||
                 InputHandler.HorizontalInput < 0))
                Moving = true;
            else Moving = false;
        }
    }
}
