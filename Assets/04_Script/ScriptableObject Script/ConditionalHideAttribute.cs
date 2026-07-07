using UnityEngine;

public class ConditionalHideAttribute : PropertyAttribute
{
    public string propertyName;
    public int enumValue;

    public ConditionalHideAttribute(string propertyName, int enumValue)
    {
        this.propertyName = propertyName;
        this.enumValue = enumValue;
    }
}