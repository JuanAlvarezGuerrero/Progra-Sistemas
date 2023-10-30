using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdShoot : ICommand
{
    private IWeapon _weapon;

    public CmdShoot(IWeapon weapon)
    {
        _weapon = weapon;
    }

    public void Do()
    {
        _weapon.Shoot();
    }
}
