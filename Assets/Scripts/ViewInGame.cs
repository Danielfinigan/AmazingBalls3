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

    private float imagePosition;
	// Use this for initialization
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
        //ammoType1.sprite = Player1Controller.Instance.spriteRenderer.sprite;

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
        //ammoType2.sprite = Player1Controller.Instance.spriteRenderer.sprite;
    }
	
	// Update is called once per frame
	void Update () {
        colorLabel1.text = Player1Controller.Instance._ammo.ToString();
        colorLabel2.text = Player2Controller.Instance._ammo.ToString();
	}

    public void Reload(int numOfAmmo)
    {
        Image newAmmo;
        for(int i = 1; i < numOfAmmo; i -= 20)
        {

        }
        newAmmo = Instantiate(ammoType1);
        newAmmo.transform.SetParent(this.transform, false);
    }

    void ammoLabel()
    {

    }

    void Fired()
    {

    }


}
