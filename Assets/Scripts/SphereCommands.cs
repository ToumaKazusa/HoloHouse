using UnityEngine;
using System.Collections;

public class SphereCommands : MonoBehaviour {

    void Start()
    {
        //GameObject.Find("floor").GetComponent<Renderer>().enabled = true;
    }
    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        // If the sphere has no Rigidbody component, add one to enable physics.
        // If the sphere has no Rigidbody component, add one to enable physics.
        //GameObject Furniture = GameObject.Find("Button-Furniture");
        //Furniture.SetActive(true);
        if (!this.GetComponent<Rigidbody>())
        {
            GameObject.Find("floor").GetComponent<Renderer>().enabled = true;
            GameObject.Find("wall").GetComponent<Renderer>().enabled = true;
            GameObject.Find("wall 1").GetComponent<Renderer>().enabled = true;
            GameObject.Find("wall 2").GetComponent<Renderer>().enabled = true;
			GameObject.Find("wall 3").GetComponent<Renderer>().enabled = true;
			GameObject.Find("Sphere").GetComponent<Renderer>().enabled = false;
        }
        //GameObject floor = GameObject.Find("floor");
        //floor.SetActive(true);
        //GameObject wall = GameObject.Find("wall");
        //wall.SetActive(true);
        /*environment = GameObject.Find("wall 1");
        environment.SetActive(true);
        environment = GameObject.Find("wall 2");
        environment.SetActive(true);
        environment = GameObject.Find("wall 3");
        environment.SetActive(true);*/
        //GameObject ball = GameObject.Find("Sphere1");
        //ball.SetActive(false);
    }
}
