using UnityEngine;

public class LevelController : MonoBehaviour
{

    private bool toyElephant;
    private bool toyTurtle;
    private bool toyOwl;

    public void SetElephant(bool val) { toyElephant = val; Debug.Log("Elephant is collected"); }
    public bool GetElephant() { return toyElephant; }
    public void SetTurtle(bool val) { toyTurtle = val; Debug.Log("Turtle is collected"); }
    public bool GetTurtle() { return toyTurtle; }
    public void SetOwl(bool val) { toyOwl = val; Debug.Log("Owl is collected"); }
    public bool GetOwl() { return toyOwl; }
}
