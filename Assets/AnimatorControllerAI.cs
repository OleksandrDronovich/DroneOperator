using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControllerAI : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(animator.runtimeAnimatorController.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
