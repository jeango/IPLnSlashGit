using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    [SerializeField]
    string warningMessage = "Greta, save us!";

    int counter;

    // Start is called before the first frame update
    void Start()
    {
        print("Hello World");
        Debug.LogWarning(warningMessage);
    }

    private void OnEnable()
    {
        print("I'm on");
    }
    private void OnDisable()
    {
        print("I'm off");
    }
    private void OnDestroy()
    {
        print("QQ");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            print("Jump");
        print(Input.GetAxisRaw("Horizontal"));
    }
}
