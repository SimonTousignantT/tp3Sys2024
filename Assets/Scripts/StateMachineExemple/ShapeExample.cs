using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeExample : MonoBehaviour
{
    void Start()
    {
        Shape someShape = new Square(5);
        Debug.Log(someShape.GetArea());

        Shape someOtherShape = new Triangle();
        Debug.Log(someOtherShape.GetArea());

        someOtherShape = new Rectangle();
        someOtherShape.GetArea();
    }
}

public abstract class Shape
{
    public virtual float GetArea()
    {
        return 0;
    }
}

public class Square : Shape
{
    private float sideSize;

    public Square(float side)
    {
        sideSize = side;
    }

    public override float GetArea()
    {
        return sideSize * sideSize;
    }
}

public class Triangle : Shape
{
    private float baseSize;
    private float height;

    public override float GetArea()
    {
        return (baseSize * height) / 2;
    }
}

public class Rectangle : Shape
{
    private float baseSize;
    private float height;
}