using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BrushHandController : MonoBehaviour
{
    [SerializeField] private Board _board;

    private void Start()
    {
        XRRayInteractor rayInteractor = GetComponent<XRRayInteractor>();
        rayInteractor.selectEntered.AddListener(call => _board = call.interactableObject.transform.GetComponent<Board>());
        rayInteractor.selectExited.AddListener(call => _board = null);
    }

    private void Update()
    {
        if (_board != null)
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
            {
                Vector2 textCoord = hit.textureCoord;
                _board.Paint(textCoord);
            }
        }


        //if (Input.GetMouseButton(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    if (Physics.Raycast(ray, out RaycastHit hit))
        //    {
        //        if (hit.transform.TryGetComponent<Board>(out Board board))
        //        {
        //            Vector2 textCoord = hit.textureCoord;
        //            _board.Paint(textCoord);
        //        }
        //    }
        //}
    }

}
