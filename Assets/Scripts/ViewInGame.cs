using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ViewInGame : MonoBehaviour {
    public static ViewInGame instance;
    public Text colorLabel1;
    public Image ammoType1;
    public Text colorLabel2;
    public Image ammoType2;
    public Image[] remainingAmmo1 = new Image[Player1Controller._maxAmmo];
    public Image[] remainingAmmo2 = new Image[Player2Controller._maxAmmo];

    private float imagePosition;
    // Use this for initialization
    void Awake()
    {
        instance = this;
    }
    void Start ()
    {
        //sets Player1 UI
        if (Player1Controller.Instance.color == "blue")
        {       
            colorLabel1.text = "Blue Ammo";
            colorLabel1.color = Color.blue;
        }
        else if (Player1Controller.Instance.color == "pink")
        {
            colorLabel1.text = "Pink Ammo";
            colorLabel1.color = Color.magenta;
        }
        else if (Player1Controller.Instance.color == "red")
        {
            colorLabel1.text = "Red Ammo";
            colorLabel1.color = Color.red;
        }
        else if (Player1Controller.Instance.color == "green")
        {
            colorLabel1.text = "Green Ammo";
            colorLabel1.color = Color.green;
        }

        //Sets Player1 ammo sprites to same color as player
        ammoType1.sprite = Player1Controller.Instance.ballRenderer.sprite;
        for(int i = 0; i < remainingAmmo1.Length; i++)
        {
            remainingAmmo1[i].sprite = ammoType1.sprite;
        }

        //sets Player2 UI
        if (Player2Controller.Instance.color == "blue")
        {
            colorLabel2.text = "Blue Ammo";
            colorLabel2.color = Color.blue;
        }
        else if (Player2Controller.Instance.color == "pink")
        {
            colorLabel2.text = "Pink Ammo";
            colorLabel2.color = Color.magenta;
        }
        else if (Player2Controller.Instance.color == "red")
        {
            colorLabel2.text = "Red Ammo";
            colorLabel2.color = Color.red;
        }
        else if (Player2Controller.Instance.color == "green")
        {
            colorLabel2.text = "Green Ammo";
            colorLabel2.color = Color.green;
        }
        //Sets Player2 ammo sprites to same color as player
        ammoType2.sprite = Player2Controller.Instance.ballRenderer.sprite;
        for (int i = 0; i < remainingAmmo2.Length; i++)
        {
            remainingAmmo2[i].enabled = true;
            remainingAmmo2[i].sprite = ammoType2.sprite;
        }
    }
	
	// Update is called once per frame
	void Update () {
        //colorLabel1.text = Player1Controller.Instance._ammo.ToString();
        //colorLabel2.text = Player2Controller.Instance._ammo.ToString();
	}

    public void Reload(int player, int ammoNumber)
    {
        if(player == 1)
        {

        }
        else if(player == 2)
        {
            remainingAmmo2[ammoNumber].enabled = true;
        }
    }

    public void Fired(int player, int projectileNumber)
    {
        Debug.Log("Fired");
        projectileNumber--; //-1 to account for array position
        if (player == 1)
            remainingAmmo1[projectileNumber].enabled = false;
        else if (player == 2)
            remainingAmmo2[projectileNumber].enabled = false;
    }


}
