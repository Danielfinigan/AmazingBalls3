using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ViewInGame : MonoBehaviour {
    public static ViewInGame instance;
    public Text colorAmmo;
    public Image ammoType;

    private float imagePosition;
	// Use this for initialization
	void Start ()
    {
        if (Player1Controller.Instance.color == "blue")
        {       
            colorAmmo.text = "Blue Ammo";
            colorAmmo.color = Color.blue;
        }
        else if (Player1Controller.Instance.color == "pink")
        {
            colorAmmo.text = "Pink Ammo";
            colorAmmo.color = Color.magenta;
        }
        else if (Player1Controller.Instance.color == "red")
        {
            colorAmmo.text = "Red Ammo";
            colorAmmo.color = Color.red;
        }
        else if (Player1Controller.Instance.color == "green")
        {
            colorAmmo.text = "Green Ammo";
            colorAmmo.color = Color.green;
        }

        ammoType.sprite = Player1Controller.Instance.spriteRenderer.sprite;
    }
	
	// Update is called once per frame
	void Update () {
        colorAmmo.text = Player1Controller.Instance._ammo.ToString();
	}

    public void Reload(int numOfAmmo)
    {
        Image newAmmo;
        for(int i = 1; i < numOfAmmo; i -= 20)
        {

        }
        newAmmo = Instantiate(ammoType);
        newAmmo.transform.SetParent(this.transform, false);
    }

    void Fired()
    {

    }


}
