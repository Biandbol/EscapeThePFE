using System.Collections.Generic;
using JetBrains.Annotations;
using Oculus.Interaction;
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
        WordCheck();
    }

    public void InitializeGroup(LetterGroup group)
    {
        for (int i = 0; i < group.objects.Count; i++)
            group.objects[i].SetActive(i == group.currentIndex);
    }

    public void CycleNext(LetterGroup group)
    {
        if (group.objects.Count == 0) return;

        group.objects[group.currentIndex].SetActive(false);
        group.currentIndex = (group.currentIndex + 1) % group.objects.Count;
        group.objects[group.currentIndex].SetActive(true);
    }

    public void CyclePrevious(LetterGroup group)
    {
        if (group.objects.Count == 0) return;

        group.objects[group.currentIndex].SetActive(false);
        group.currentIndex = (group.currentIndex - 1 + group.objects.Count) % group.objects.Count;
        group.objects[group.currentIndex].SetActive(true);
    }

    public void Firsstgroup(){
        

         CycleNext(firstGroup);
          
    }
    public void secondddgroup(){
        CycleNext(secondGroup);
    }
    public void thirdgroup(){
        CycleNext(thirdGroup);
    }
    public void forthgroup(){
        CycleNext(forthGroup);
    }


    public void WordCheck(){
        Debug.Log(firstGroup.currentIndex+("first wprd"));
        Debug.Log(secondGroup.currentIndex+("second wprd"));
        Debug.Log(thirdGroup.currentIndex+("third wprd"));
        Debug.Log(forthGroup.currentIndex+("forth wprd"));

        if (firstGroup.currentIndex==1 && secondGroup.currentIndex==10 && thirdGroup.currentIndex==5 && forthGroup.currentIndex==3)
        {
            
            Debug.Log("correct");
        }
        
    }



}
