using UnityEngine;
using System.Collections;

public class CustomCursor : MonoBehaviour {

    public Texture2D cursor1;
    public Texture2D cursor2;
    public float switchSpeed;

	// Use this for initialization
	void Start () {
        //ursor.visible = false;
        StartCoroutine("animateCursor");
	}

    IEnumerator animateCursor() {
        while (true) {
            Cursor.SetCursor(this.cursor1, Vector2.zero, CursorMode.Auto);
            yield return new WaitForSeconds(this.switchSpeed);
            Cursor.SetCursor(this.cursor2, Vector2.zero, CursorMode.Auto);
            yield return new WaitForSeconds(this.switchSpeed);
            yield return null;
        }
    }
	
	// Update is called once per frame
	void OnGUI () {
        
	}
}
