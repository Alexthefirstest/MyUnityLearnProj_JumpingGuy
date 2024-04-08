using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundColorManager : MonoBehaviour
{
    private RandomColorManer randomcolorManager = new RandomColorManer();

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChangeColor", 2, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ChangeColor()
    {
        randomcolorManager.SetColor(this.gameObject);
    }
}

class ColorManager
{
    public void SetColor(GameObject go, float r, float g, float b)
    {
        go.GetComponent<Renderer>().material.color = new Color(r, g, b);
    }

    public virtual void SetColor(GameObject go)
    {
        go.GetComponent<Renderer>().material.color = Color.red;
    }


}

class RandomColorManer : ColorManager
{
    public override void SetColor(GameObject go)
    {
        SetColor(go, GetRandRGBFloat(), GetRandRGBFloat(), GetRandRGBFloat());
    }

    private float GetRandRGBFloat()
    {
        return Random.Range(0f, 1f);
    }
}

