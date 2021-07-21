using UnityEngine;

[CreateAssetMenu(fileName = "New Object", menuName = "Interaction Objects")]
public class InteractionObject : ScriptableObject
{
    public string objectName;
    public string requireObjectName;
}
