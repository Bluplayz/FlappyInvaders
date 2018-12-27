using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCollectorScript : MonoBehaviour {

    GameObject[] backgrounds;
    GameObject[] grounds;

    float lastBackgroundX;
    float lastGroundX;

	// Use this for initialization
	void Start ()
    {
        backgrounds = GameObject.FindGameObjectsWithTag("Background");
        grounds = GameObject.FindGameObjectsWithTag("Underground");

        RefreshObjects();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void RefreshObjects()
    {
        lastBackgroundX = backgrounds[0].transform.position.x;
        lastGroundX = grounds[0].transform.position.x;

        for(int i = 1; i < backgrounds.Length; i++)
        {
            if (lastBackgroundX <= backgrounds[i].transform.position.x)
            {
                lastBackgroundX = backgrounds[i].transform.position.x;
            }
        }

        for (int i = 1; i < grounds.Length; i++)
        {
            if (lastGroundX <= grounds[i].transform.position.x)
            {
                lastGroundX = grounds[i].transform.position.x;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Background")
        {
            Vector3 position = other.transform.position;
            Vector2 boxColliderSize = other.GetComponent<BoxCollider2D>().size;
            position.x = lastBackgroundX + (boxColliderSize.x * other.transform.localScale.x) - 0.01f;
            other.transform.position = position;
            RefreshObjects();
        }
        else if (other.tag == "Underground")
        {
            Vector3 position = other.transform.position;
            Vector2 boxColliderSize = other.GetComponent<BoxCollider2D>().size;
            position.x = lastGroundX + (boxColliderSize.x * other.transform.localScale.x) - 0.01f;
            other.transform.position = position;
            RefreshObjects();
        }
    }
}
