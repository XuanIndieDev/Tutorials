using UnityEngine;

public class CannotSelected : MonoBehaviour
{
    public Player player;
    [SerializeField] GameObject obj;
    [SerializeField] bool isHit;

    private void Awake()
    {
        isHit = !isHit;
    }

    public void Hit()
    {
        if (!isHit) return;
        player.Subtract();
        print("!");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isHit = !isHit;
            obj.SetActive(!isHit);
        }
    }
}
