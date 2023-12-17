using UnityEngine;
using static UnityEngine.Mathf;

public static class FunctionLibrary
{

    public delegate Vector3 Function(float u, float v, float t);

    public enum FunctionName                {Wave, MultiWave, Ripple, Sphere, Torus, Special};

    private static Function[] function =    {Wave, MultiWave, Ripple, Sphere, Torus, Special};

    public static Function GetFunction (FunctionName name)
    {
        return function[(int)name];
    }
    
    public static FunctionName GetNextFunctionName(FunctionName name)
    {
        if((int)name < function.Length - 1)
        {
            return name + 1;
        }
        else
        {
            return 0;
        }
    }

    public static FunctionName GetRandomFunctionName()
    {
        var choice = (FunctionName)Random.Range(0,function.Length);
        return choice;
    }

    public static FunctionName GetRandomFunctionNameOtherThan(FunctionName name)
    {
        var choice = (FunctionName)Random.Range(1,function.Length);
        if(choice == name) return 0;
        else return choice;
    }



    public static Vector3 Wave(float u, float v, float t)
    {
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (u + v + t));
        p.z = v;
        return p;
    }

    public static Vector3 MultiWave(float u, float v, float t)
    {
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (u + (t * 0.5f)));
        p.y += Sin(2f * PI * (v + t)) * 0.5f;
        p.y += Sin(PI * (u + v + (0.25f * t)));
        p.y *= (2f/3f);
        p.z = v;
        return p;
    }

    public static Vector3 Ripple(float u, float v, float t)
    {
        float d = Sqrt(u * u + v * v);
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * ((4f * d) - t));
        p.y /= 1f + (10f * d);
        p.z = v;
        return p;
    }

    public static Vector3 Sphere(float u, float v, float t)
    {
        float r = 0.9f + 0.1f * Sin(PI * (6f * u + 4f * v + t));
        float s = r * Cos(0.5f * PI * v);
        Vector3 p;
        p.x = s * Sin(PI * u);
        p.y = r * Sin(PI * 0.5f * v);
        p.z = s * Cos(PI * u);
        return p;
    }

    public static Vector3 Torus(float u, float v, float t)
    {
		float r1 = 0.7f + 0.1f * Sin(PI * (6f * u + 0.5f * t));
		float r2 = 0.15f + 0.05f * Sin(PI * (8f * u + 4f * v + 2f * t));
        float s = r1 + r2 * Cos(PI * v);
        Vector3 p;
        p.x = s * Sin(PI * u);
        p.y = r2 * Sin(PI * v);
        p.z = s * Cos(PI * u);
        return p;
    }

    public static Vector3 Special(float u,float v, float t)
    {
        Vector3 p;
        p.x = Sin(PI * (u*(1f/17f) + v*(1f/19f) + t*(1f/23f)));
        p.y = Sin(PI * (u*(1f/13f) + v*(1f/11f) + t*(1f/7f)));
        p.z = Sin(PI * (u*(1f/2f) + v*(1f/3f) + t*(1f/5f)));
        return p;
    }

    public static Vector3 Morph(float u, float v, float t, Function from, Function to, float progress)
    {
        return Vector3.LerpUnclamped(from(u,v,t),to(u,v,t), SmoothStep(0f,1f,progress));
    }
}
