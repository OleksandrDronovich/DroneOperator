using UnityEngine;
using UnityEngine.UI;

public class DroneControllerUI : MonoBehaviour
{
    public static DroneControllerUI Instance;
    public Joystick leftStick;
    public Joystick rightStick;

    public Slider zoomSlider;
    public Image shootCooldownImage;
    // Start is called before the first frame update
    void Awake()
    {
        if (!Instance)
            Instance = this;
        else Destroy(gameObject);
    }

    public Vector2 GetLeftStickValues()
    {
        return new Vector2(leftStick.Horizontal, leftStick.Vertical);
    }

    public Vector2 GetRightStickValues()
    {
        return new Vector2(rightStick.Horizontal, rightStick.Vertical);
    }

    public void UpdateShootingImage(float value) 
    {
        shootCooldownImage.fillAmount = value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
