using UnityEngine;
using System.Collections;

public class WeaponAnimating : MonoBehaviour
{
    private const int AttackAnimationLength = 55;
    [SerializeField] private Transform _pants;
    [SerializeField] private Transform _hand;
    [SerializeField] private Transform _lightSaber;


    private Animator _anim;
    private bool _armed;
    private int _frame;
    private bool _moving;
    private bool _attacking;
    private int _attackCounter;

    private void Start()
    {
        this._anim = GetComponent<Animator>();
        this._armed = true;
        this._anim.SetBool("Armed", this._armed);
        this._attackCounter = AttackAnimationLength;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Arming") && !this._attacking)
        {
            this._armed = !this._armed;
            if (this._armed)
                this._anim.SetTrigger("Arming");
            else
            {
                this._anim.SetTrigger("Disarming");
                this._lightSaber.GetChild(0).gameObject.SetActive(this._armed);
            }
            this._anim.SetBool("Armed", this._armed);
            this._moving = true;
            this._frame = 0;
        }
        if (this._moving)
        {
            if (this._armed && this._frame == 11)
            {
                this._lightSaber.SetParent(this._hand);
                this._lightSaber.localPosition = Vector3.zero;
                this._lightSaber.localRotation = Quaternion.identity;
            }
            if (!this._armed && this._frame == 16)
            {
                this._lightSaber.SetParent(this._pants);
                this._lightSaber.localPosition = Vector3.zero;
                this._lightSaber.localRotation = Quaternion.identity;
                this._moving = false;
            }
            if (this._armed && this._frame == 35)
            {
                this._lightSaber.GetChild(0).gameObject.SetActive(this._armed);
                this._moving = false;
            }
            this._frame++;
        }
        if (Input.GetMouseButtonDown(0) && !this._attacking && this._armed)
        {
            this._attacking = true;
            this._anim.SetTrigger("Attack");
            this._attackCounter = 0;
        }
        this._attackCounter++;
        this._attacking = this._attackCounter < AttackAnimationLength;
    }
}
