using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    //This makes it PUBLIC to other applications and methods, not just in the uodate method. It will also be in Unity as a value you can manipulate.
    // note this value will not really save in unity properly
    public float speed;
    public float minY, maxY, minX, maxX;
    public GameObject lazer, lazerSpawn;
    public float fireRate = 0.25f;
    private float timer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //note the public speed is here and visual studio doesnt complain. 
    }

    // Update is called once per frame
    void Update()
    {
       
        float horiz, vert;


        horiz = Input.GetAxis("Horizontal"); //listens to my input
        vert = Input.GetAxis("Vertical");
        //(dont need the Debug part right now because it just shows us the value being used for x and y movement):
        //Debug.Log("H: " + horiz + ", V: " + vert); //prints out number. But Uity and visual studio work to display this is Unity.
        //use velocity to reflect input next
        //specifying component in unity to manipulate here
        //velocity is speed and direction. Vector 2 a container for two pieces of data x and y(they are combined. vert and horiz are the x and y
        //so just feed them to the Vector2 as values.

        Vector2 newVelocity = new Vector2(horiz, vert);
        GetComponent<Rigidbody2D>().velocity = newVelocity * speed;
        //We just adjusted the code above (made it shorter) because
        //now we can adjust it easier eg newVelocity times 5 for example
        float newY, newX;


        newY = Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, minY, maxY);
        newX = Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, minX, maxX);
        Debug.Log($"Clamped Y: {newY} Clamped X: {newX}");

        GetComponent<Rigidbody2D>().position = new Vector2(newX, newY);



        //add lazer fire code
        //check if the "Fire1" is pressed
        //&& means and
        if (Input.GetAxis("Fire1") > 0 && timer > fireRate)
        {
            //if yes, spawn the lazer
            //Instantiation(cloning an object in our case the lazer): What do I instantiate? Where is it instatiated? What is its rotation?
            GameObject gObj;
            gObj = GameObject.Instantiate(lazer, lazerSpawn.transform.position, lazerSpawn.transform.rotation);
            gObj.transform.Rotate(new Vector3(0, 0, 90));

            //reset timer
            timer = 0;
        }

        timer += Time.deltaTime; //timer = timer + Time.deltaTime;
    }
}   
