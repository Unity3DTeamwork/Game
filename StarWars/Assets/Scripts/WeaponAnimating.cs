using UnityEngine;

public class WeaponAnimating : MonoBehaviour
{
    [SerializeField] private Transform _pants;
    [SerializeField] private Transform _hand;
    [SerializeField] private Transform _lightSaber;

    private Animator _anim;
    private bool _armed;
    private bool _moving;
    private bool _attacking;
    private GameObject _lightsaberBlade;

    private void Start()
    {
        this._anim = GetComponent<Animator>();
        this._armed = true;
        this._anim.SetBool("Armed", this._armed);
        this._lightsaberBlade = this._lightSaber.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (InputHandler.Arming && !this._attacking && !this._moving)
        {
            this._armed = !this._armed;
            this._anim.SetTrigger(this._armed ? "Arming" : "Disarming");
            this._anim.SetBool("Armed", this._armed);
            this._moving = true;
        }
        if (!InputHandler.Attacking || this._attacking || !this._armed || this._moving) return;
        this._attacking = true;
        this._anim.SetTrigger("Attack");
    }

    public void FinishedAttacking()
    {
        this._attacking = false;
    }

    public void FinishedArmingDisarming()
    {
        this._moving = false;
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
