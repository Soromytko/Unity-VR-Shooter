using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticInteractable : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField] private float _intensity = 0.7f;
    [SerializeField] private float _duration = 0.3f;

    private void Start()
    {
        // XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();
        // interactable.activated.AddListener(eventArgs =>
        // {
        //     if (eventArgs.interactorObject is XRBaseControllerInteractor controllerInteractor)
        //     {
        //         TriggerHatpic(controllerInteractor.xrController);
        //     }
        // });
    }

    public void TriggerHatpic(XRBaseController controller)
    {
        controller.SendHapticImpulse(_intensity, _duration);
    }
 
}
