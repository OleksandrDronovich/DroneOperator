using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DroneType 
{
    MAVIC,
    FPV,
    PLANER
}

public class DroneController : CharacterController
{
    private DroneControllerUI ui;
    [SerializeField]
    private DroneType droneType;
    [SerializeField]
    private Transform mainCamera;
    [SerializeField]
    private int bullets;
    private Vector3 mainCameraStartingPos;
    private Quaternion mainCameraStartingRot;
    private bool goDown;
    // Start is called before the first frame update
    void Start()
    {
        ui = DroneControllerUI.Instance;
        mainCameraStartingPos = mainCamera.localPosition;
        mainCameraStartingRot = mainCamera.localRotation;
    }


    void Update()
    {
        base.Update();
        if (ui.GetLeftStickValues() != Vector2.zero || ui.GetRightStickValues() != Vector2.zero) 
        {
            movingVector = new Vector3(-ui.GetRightStickValues().x, 0, -ui.GetRightStickValues().y) ;
            state = CharacterState.move;
        }
        else
            state = CharacterState.idle;

        if(GetShootingValue() > 0)
            ui.UpdateShootingImage(GetShootingValue());

        switch (droneType)
        {
            case DroneType.MAVIC:
                switch (state)
                {
                    case CharacterState.idle:
                        if (mainCamera.transform.localRotation != mainCameraStartingRot)
                            mainCamera.localRotation = Quaternion.Lerp(mainCamera.localRotation, mainCameraStartingRot, 0.05f);
                        mainCamera.transform.localPosition = Vector3.MoveTowards(mainCamera.transform.localPosition, mainCameraStartingPos + Vector3.forward, 0.01f * (goDown ? 1 : -1));

                        if (Vector3.Distance(mainCamera.transform.localPosition, mainCameraStartingPos) > 2)
                        {
                            goDown = !goDown;
                        }
                        break;
                    case CharacterState.move:
                        mainCamera.transform.localRotation = Quaternion.Euler(-10 + ui.GetRightStickValues().y * 3, -ui.GetRightStickValues().x * 3, 0);
                        break;
                    case CharacterState.shoot:
                        
                        break;
                    case CharacterState.die:
                        break;
                }
                break;
            case DroneType.FPV:
                break;
            case DroneType.PLANER:
                break;
            default:
                break;
        }
    }
}