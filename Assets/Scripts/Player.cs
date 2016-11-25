using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    #region Fields

    #region Public 
    public int Goal;
    public float Speed = 10;
    public List<string> ListCollected;
    public Text GuiTextCollected;
    public Text GoalText;
    #endregion

    #region Private
    private Rigidbody rb;
    #endregion

    #endregion

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GuiTextCollected.text = string.Empty;
        GoalText.text = "Your goal is:" + Goal.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        float moveHorizontaly = Input.GetAxis("Horizontal");
        float moveVerticaly = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontaly, 0.0f, moveVerticaly);

        rb.AddForce(movement * Speed);
    }

    public void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            //Pick up item
            case "PickUp":
                Pickup(other);
                break;
         
            //Exit the level 
            case "Gateway":
                break;

            default:
                break;
        }
    }

    private void Pickup(Collider other)
    {
        //Get the text of the colided item
        string strTemp = other.GetComponent<TextMesh>().text;

        //Remove collided from the GUI
        other.gameObject.SetActive(false);

        //Add the text to the collected items list
        ListCollected.Add(strTemp);

        //Adds the text to the collected text
        //Items have to be picked according to their order in the equation
        if (System.Math. ListCollected.Count)
        {

        }
        if (string.IsNullOrEmpty(GuiTextCollected.text))
            GuiTextCollected.text = strTemp;
        else
            GuiTextCollected.text = GuiTextCollected.text + strTemp; 
    }
}
