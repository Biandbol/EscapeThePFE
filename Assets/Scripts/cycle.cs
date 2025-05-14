using System.Collections.Generic;
using UnityEngine;

public class CycleGameObjects : MonoBehaviour
{
    public Transform firstGroupParent;
    public Transform secondGroupParent;
     public Transform thirdGroupParent;
      public Transform forthGroupParent;
       public Transform fifthGroupParent;
    [System.Serializable]
    public class LetterGroup
    {
        public List<GameObject> objects;
        [HideInInspector] public int currentIndex = 0;
    }

    public LetterGroup firstGroup;
    public LetterGroup secondGroup;
    public LetterGroup thirdGroup;
    public LetterGroup forthGroup;
    public LetterGroup fifthGroup;

    void Start()
    {
         firstGroup.objects = GetChildren(firstGroupParent);
    secondGroup.objects = GetChildren(secondGroupParent);
    thirdGroup.objects = GetChildren(thirdGroupParent);
    forthGroup.objects = GetChildren(forthGroupParent);
    fifthGroup.objects = GetChildren(fifthGroupParent);

    List<GameObject> GetChildren(Transform parent)
{
    List<GameObject> children = new List<GameObject>();
    if (parent == null) return children;

    foreach (Transform child in parent)
        children.Add(child.gameObject);

    return children;
}

        InitializeGroup(firstGroup);
        InitializeGroup(secondGroup);
        InitializeGroup(thirdGroup);
        InitializeGroup(forthGroup);
        InitializeGroup(fifthGroup);
    }

    void Update()
    {
        // First group: Up/Down arrows
        if (Input.GetKeyDown(KeyCode.UpArrow))
            CycleNext(firstGroup);
        if (Input.GetKeyDown(KeyCode.DownArrow))
            CyclePrevious(firstGroup);

        // Second group: Right/Left arrows
        if (Input.GetKeyDown(KeyCode.RightArrow))
            CycleNext(secondGroup);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            CyclePrevious(secondGroup);
    }

    void InitializeGroup(LetterGroup group)
    {
        for (int i = 0; i < group.objects.Count; i++)
            group.objects[i].SetActive(i == group.currentIndex);
    }

    void CycleNext(LetterGroup group)
    {
        if (group.objects.Count == 0) return;

        group.objects[group.currentIndex].SetActive(false);
        group.currentIndex = (group.currentIndex + 1) % group.objects.Count;
        group.objects[group.currentIndex].SetActive(true);
    }

    void CyclePrevious(LetterGroup group)
    {
        if (group.objects.Count == 0) return;

        group.objects[group.currentIndex].SetActive(false);
        group.currentIndex = (group.currentIndex - 1 + group.objects.Count) % group.objects.Count;
        group.objects[group.currentIndex].SetActive(true);
    }
}
