using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] PlaneGun primaryGun;
    [SerializeField] PlaneMissileFire rightWing;
    [SerializeField] PlaneMissileFire leftWing;
    [SerializeField] MagneticField emp;
    [SerializeField] PlaneShield shield;
    [SerializeField] GravityHoleSpawner gravityHoleSpawner;
    [SerializeField] HomingMissileSpawner homingMissileSpawner;
    [SerializeField] PlaneCompanion planeCompanion1;
    [SerializeField] PlaneCompanion planeCompanion2;

     
    public void Move(InputAction.CallbackContext ctx)
    {
        
    }

    public void PrimaryFire(InputAction.CallbackContext ctx)
    {
        //primaryGun.Shoot();
    }

    public void RegMissleFire(InputAction.CallbackContext ctx)
    {
        rightWing.ShootMissile();
        leftWing.ShootMissile();
    }

    public void EMP(InputAction.CallbackContext ctx)
    {
        emp.ActivateEMP();
    }

    public void GravityHole(InputAction.CallbackContext ctx)
    {
        gravityHoleSpawner.SpawnGravityHole();
    }

    public void HomingMissile(InputAction.CallbackContext ctx)
    {
        homingMissileSpawner.SpawnHomingMissile();
    }

    public void Shield(InputAction.CallbackContext ctx)
    {
        shield.CastShield();
    }

    public void Dash(InputAction.CallbackContext ctx)
    {

    }
    
    public void PlaneCompanion(InputAction.CallbackContext ctx)
    {
        planeCompanion1.ActivateCompanion();
        planeCompanion2.ActivateCompanion();
    }


}
