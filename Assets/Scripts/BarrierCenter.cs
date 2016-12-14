using UnityEngine;
using System.Collections;

public class BarrierCenter : MonoBehaviour {
    public static BarrierCenter instance;
    private string direction = "up";
    private float yPosition;
    private const float boxEdge = 4;
	// Use this for initialization
	void Start ()
    {
        instance = this;
        yPosition = this.transform.position.y;
        direction = "up";
    }
	
	// Update is called once per frame
	void Update ()
    {
        yPosition = this.transform.position.y;
        if (direction == "up" && yPosition < boxEdge)
        {
            instance.transform.position = new Vector2(0, yPosition++);
        }
        else if (yPosition >= boxEdge)
        {
            direction = "down";
        }
        else if (direction == "down" && yPosition > -boxEdge)
        {
            instance.transform.position = new Vector2(0, yPosition--);
        }
        else if(yPosition <= -boxEdge)
        {
            direction = "up";
        }

	}
}
