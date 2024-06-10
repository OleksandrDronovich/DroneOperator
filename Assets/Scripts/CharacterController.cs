using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterState
{
    idle,
    move,
    shoot,
    die
}

public enum CharacterType 
{
    warrior,
    tank,
    drone
}

public class CharacterController : MonoBehaviour
{
    protected CharacterState state;
    [SerializeField]
    protected CharacterType type;
    protected Vector3 movingVector;

    [SerializeField]
    protected float cooldownShooting;

    private float currentCooldownShooting;
    private bool canShoot = true;

    public float GetShootingValue() 
    {
        float value;
        value = currentCooldownShooting / cooldownShooting;
        return value; 
    }

    IEnumerator ShootingReload(float value) 
    {
        currentCooldownShooting = value;
        yield return new WaitForSeconds(0.1f);
        if (currentCooldownShooting > 0.1f)
            StartCoroutine(ShootingReload(currentCooldownShooting - 0.1f));
        else
        {
            state = CharacterState.idle;
            canShoot = true;
        }
    }


    public void Idle()
    {
        
    }

    public void Moving()
    {
        switch (type)
        {
            case CharacterType.warrior:
                break;
            case CharacterType.tank:
                break;
            case CharacterType.drone:
                transform.position += movingVector * -0.1f;
                break;
            default:
                break;
        }
    }

    public void Shooting()
    {
        if (canShoot)
        {
            canShoot = false;
            state = CharacterState.shoot;
            StartCoroutine(ShootingReload(cooldownShooting));
        }
    }

    public void Dying() 
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected void Update()
    {
        switch (state)
        {
            case CharacterState.idle:
                Idle();
                break;
            case CharacterState.move:
                Moving();
                break;
            case CharacterState.shoot:
                Shooting();
                break;
            case CharacterState.die:
                Dying();
                break;
        }
        Debug.Log(state);
    }
}
