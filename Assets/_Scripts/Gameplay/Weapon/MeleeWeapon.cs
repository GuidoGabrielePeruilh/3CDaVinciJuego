using Game.Gameplay.Weapon;
using System.Diagnostics;
using UnityEngine;


public class MeleeWeapon : Weapon
{
    [SerializeField] GameObject _damaging;
    [SerializeField] Animator _ani;
    bool _canAttack = true;

    void Awake()
    {
        type = Type.MELEE;
        _damaging.SetActive(false);

    }

    public void ANIM_EVENT_MELEE(string context)
    {
        switch (context)
        {
            case "start_heatbox":
                StartHeatbox();
                break;
            case "end_heatbox":
                EndHeatbox();
                break;
            case "finish_ani":
                FinishAni();
                break;
            default:
                break;
        }

    }
    public override bool CanAttack()
    {
        return _canAttack;
    }
    private void FinishAni()
    {
        _canAttack = true;
    }

    private void EndHeatbox()
    {
        _damaging.SetActive(false);
    }

    private void StartHeatbox()
    {
        _damaging.SetActive(true);
    }

    public override void ShootBullet()
    {
        _canAttack = false;

    }

    public override void ReloadWeapon()
    {

    }
}

