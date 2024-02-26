using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPoints : MonoBehaviour
{
    [SerializeField] private int _points = 5;

    [SerializeField] private PointsCanvas _pointsCanvasPrefab;

    public void GivePoints()
    {
        PointsCanvas pointsCanvas = Instantiate(_pointsCanvasPrefab);
        pointsCanvas.transform.position = transform.position;
        pointsCanvas.Points = _points;

        GameObject.FindObjectOfType<ScoreManager>().Score += _points;
    }
}
