using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{   
    [SerializeField] Texture2D building;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void BuildMode(){
        Cursor.SetCursor(building, Vector2.zero, CursorMode.Auto);
        GameManager.Instance.buildMode = true;
    }

    public void Reset() {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            GameManager.Instance.buildMode = false;
        }

}

