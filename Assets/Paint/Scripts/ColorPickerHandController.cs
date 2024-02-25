using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ColorPickerHandController : MonoBehaviour
{
    [SerializeField] private GameObject _colorPickerObj;

    private void Start()
    {
        XRDirectInteractor interactor = GetComponent<XRDirectInteractor>();
        interactor.selectEntered.AddListener(call => _colorPickerObj.SetActive(true));
        interactor.selectExited.AddListener(call => _colorPickerObj.SetActive(false));

        _colorPickerObj.SetActive(false);
    }

    private void Update()
    {

    }
}
