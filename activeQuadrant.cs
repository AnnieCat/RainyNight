using UnityEngine;
using System.Collections;

public class activeQuadrant : MonoBehaviour {

    public ControlScript[] myEyes;

    
    void OnMouseEnter()
    {
        foreach (ControlScript x in myEyes){
            if (collider.name == "quadrant_1_1") { x.activeQuadrant = ControlScript.Quadrant.q1_1; }
            if (collider.name == "quadrant_1_2") { x.activeQuadrant = ControlScript.Quadrant.q1_2; }
            if (collider.name == "quadrant_1_3") { x.activeQuadrant = ControlScript.Quadrant.q1_3; }

            if (collider.name == "quadrant_2_1") { x.activeQuadrant = ControlScript.Quadrant.q2_1; }
            if (collider.name == "quadrant_2_2") { x.activeQuadrant = ControlScript.Quadrant.q2_2; }
            if (collider.name == "quadrant_2_3") { x.activeQuadrant = ControlScript.Quadrant.q2_3; }

            if (collider.name == "quadrant_3_1") { x.activeQuadrant = ControlScript.Quadrant.q3_1; }
            if (collider.name == "quadrant_3_2") { x.activeQuadrant = ControlScript.Quadrant.q3_2; }
            if (collider.name == "quadrant_3_3") { x.activeQuadrant = ControlScript.Quadrant.q3_3; }
        }
    }
}
