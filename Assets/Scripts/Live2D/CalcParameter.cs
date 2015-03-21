using UnityEngine;
using System.Collections;

public class CalcParameter {

    float targetParam;
    float maxVelocity;

     public CalcParameter()
    {
        targetParam = 0;
        maxVelocity = 0;
    }

    public CalcParameter(float t, float v)
    {
        targetParam = t;
        maxVelocity = v;
    }


}
