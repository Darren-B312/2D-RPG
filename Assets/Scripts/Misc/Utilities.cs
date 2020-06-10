using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    // Return a list of vector points in a a square pattern about an origin at a given radius.
    public static List<Vector3> CalculateSquarePerimeterPoints(Vector3 origin, float radius)
    {
        List<Vector3> patrolPoints = new List<Vector3>
        {
            new Vector3(origin.x, origin.y),
            new Vector3(origin.x + radius, origin.y + radius),
            new Vector3(origin.x + radius, origin.y - radius),
            new Vector3(origin.x - radius, origin.y - radius),
            new Vector3(origin.x - radius, origin.y + radius)
        };

        return patrolPoints;
    }
}
