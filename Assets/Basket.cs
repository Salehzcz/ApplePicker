using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public TextMesh scoreGT;
    // Start is called before the first frame update
    void Start()
    {
        // Find a reference to ScoreCounter GameObject
        GameObject scoreGo = GameObject.Find("ScoreCounter");
        // get the GUIText component of the GameObject
        scoreGT = scoreGo.GetComponent<TextMesh>();
        // set the starting number of points to 0
        scoreGT.text = "0";
         
    }

    // Update is called once per frame
    void Update()
    {
        // Get current screen position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;

        // The camer's position sets how far to push the mouse
        mousePos2D.z = -Camera.main.transform.position.z;

        // Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // Move the x position of this basket to the x position of the mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
    void OnCollisionEnter(Collision coll)
    {
        // Find out what hit this basket
        GameObject collideWith = coll.gameObject;
        if (collideWith.tag == "Apple")
        {
            Destroy(collideWith);
            // parce the text of the scoreGT into an int
            int score = int.Parse(scoreGT.text);
            // add points for catching the Apple
            score += 100;
            scoreGT.text = score.ToString();
            // Track our high score
            if (score> HighScore.score)
               HighScore.score = score;
           
        }
    }


}
