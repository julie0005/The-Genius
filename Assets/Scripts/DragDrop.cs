using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DragDrop : MonoBehaviour
{
    static int pdropcount = 0;
    private bool isDragging = false;
    private bool isOverDropZone = false;
    private GameObject dropZone;
    private Vector2 startPosition;
    private GameObject Canvas;
    private GameObject startParent;
    private Transform movingParent;
    GameObject placeHolder=null;

    private void Awake()
    {
        Canvas = GameObject.Find("Main Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            int newSiblingIndex = startParent.transform.childCount;
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(Canvas.transform, true); // 뒤에 속성 true, worldPosition 유지.
            
            for(int i=0; i < startParent.transform.childCount; i++)
            {
                if (transform.position.x < startParent.transform.GetChild(i).position.x)
                {
                    newSiblingIndex = i;
                    if (placeHolder.transform.GetSiblingIndex() < newSiblingIndex)
                        newSiblingIndex--;
                    break;
                }
            }

            placeHolder.transform.SetSiblingIndex(newSiblingIndex);

        }

           
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOverDropZone = true;
        dropZone = collision.gameObject;
        pdropcount++;
       
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
     
        isOverDropZone = false;
        dropZone = null;
        pdropcount--;
    }

    public void StartDrag()
    {
        startParent = transform.parent.gameObject;
        startPosition = transform.position;
        if (startParent != GameObject.Find("PlayerDropZone")) //낙장불입 ㅎㅅㅎ. 
        {
            isDragging = true;

            placeHolder = new GameObject();
            placeHolder.transform.SetParent(this.transform.parent);
            LayoutElement le = placeHolder.AddComponent<LayoutElement>();
            le.preferredHeight = this.GetComponent<Image>().preferredHeight;
            le.preferredWidth = this.GetComponent<Image>().preferredWidth;
            le.flexibleHeight = 0;
            le.flexibleWidth = 0;

            placeHolder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        }
    }

    public void EndDrag()
    {   

        isDragging = false;
        if (startParent != GameObject.Find("PlayerDropZone"))
        {
            if (isOverDropZone && pdropcount <= 1)
            {
                transform.SetParent(dropZone.transform, false); //WorldPosition 이동. move to the dropzone.
            }
            else
            {
                transform.position = startPosition;
                transform.SetParent(startParent.transform, false); //WorldPosition 이동. move to the start zone.
            }
            transform.SetSiblingIndex(placeHolder.transform.GetSiblingIndex());
            Destroy(placeHolder);
        }
    }
}
