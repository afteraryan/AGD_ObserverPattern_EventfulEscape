using System;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchView : MonoBehaviour, IInteractable
{
    [SerializeField] private List<Light> lightsources = new List<Light>();
    private SwitchState currentState;
    
    public delegate void LightSwitchDelegate(); //Signature
    public event LightSwitchDelegate lightSwitch; //Event

    private void Start() => currentState = SwitchState.Off;

    private void OnEnable()
    {
        lightSwitch = OnLightSwitchToggled;
        lightSwitch += OnLightSwitchSoundEffect;
    }

    public void Interact()
    {
        //Todo - Implement Interaction
        lightSwitch.Invoke();
    }
    private void toggleLights()
    {
        bool lights = false;

        switch (currentState)
        {
            case SwitchState.On:
                currentState = SwitchState.Off;
                lights = false;
                break;
            case SwitchState.Off:
                currentState = SwitchState.On;
                lights = true;
                break;
            case SwitchState.Unresponsive:
                break;
        }
        foreach (Light lightSource in lightsources)
        {
            lightSource.enabled = lights;
        }
    }

    private void OnLightSwitchToggled()
    {
        toggleLights();
        GameService.Instance.GetInstructionView().HideInstruction();
    }

    private void OnLightSwitchSoundEffect()
    {
        GameService.Instance.GetSoundView().PlaySoundEffects(SoundType.SwitchSound);
    }
}
