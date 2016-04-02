using UnityEngine;

namespace Assets.Scripts
{
    public class WeaponAnimating : MonoBehaviour
    {
        [SerializeField]
        private Transform _pants;
        [SerializeField]
        private Transform _hand;
        [SerializeField]
        private Transform _lightSaber;

        private Animator _anim;
        private GameObject _lightsaberBlade;

        private void Start()
        {
            this._anim = GetComponent<Animator>();
            this._anim.SetBool("Armed", Character.Armed);
            this._lightsaberBlade = this._lightSaber.GetChild(0).gameObject;
        }

        private void Update()
        {
            if (InputHandler.Arm && !Character.Attacking && Character.Grounged && !Character.Arming && !Character.Jumping)
            {
                Arm();
            }
            if (!InputHandler.Attack || Character.Attacking || !Character.Armed || Character.Arming) return;
            Attack();
        }

        private void Arm()
        {
            Character.Armed = !Character.Armed;
            this._anim.SetTrigger(Character.Armed ? "Arm" : "Disarm");
            this._anim.SetBool("Armed", Character.Armed);
            Character.Arming = true;
        }

        private void Attack()
        {
            Character.Attacking = true;
            this._anim.SetTrigger("Attack");
        }

        public void FinishedAttacking()
        {
            Character.Attacking = false;
        }

        public void FinishedArmingDisarming()
        {
            Character.Arming = false;
        }

        public void GetLeaveLightsaber()
        {
            this._lightSaber.SetParent(this._lightSaber.parent == this._hand ? this._pants : this._hand);
            this._lightSaber.localPosition = Vector3.zero;
            this._lightSaber.localRotation = Quaternion.identity;
        }
        public void TurnLightsaberOnOff()
        {
            this._lightsaberBlade.SetActive(!this._lightsaberBlade.activeSelf);
        }
    }
}
