using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandController : MonoBehaviour
{
    [SerializeField] private Board _board;

    private void Start()
    {
        XRDirectInteractor interactor = GetComponent<XRDirectInteractor>();
        interactor.selectEntered.AddListener(call =>
        {
            if (Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit, Mathf.Infinity))
            {
                 Vector2 textCoord = hit.textureCoord;
                 _board.Paint(textCoord);
            }
        });
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform.TryGetComponent<Board>(out Board board))
                {
                    Vector2 textCoord = hit.textureCoord;
                    _board.Paint(textCoord);
                }
            }
        }
    }
}
