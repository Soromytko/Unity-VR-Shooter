using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ColorPickerHandController : MonoBehaviour
{
    [SerializeField] private GameObject _colorPickerObj;

    private void Start()
    {
        XRRayInteractor rayInteractor = GetComponent<XRRayInteractor>();
        rayInteractor.selectEntered.AddListener(call => _colorPickerObj.SetActive(true));
        rayInteractor.selectExited.AddListener(call => _colorPickerObj.SetActive(false));

        _colorPickerObj.SetActive(false);
    }

}
