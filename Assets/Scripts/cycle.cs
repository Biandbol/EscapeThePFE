using System.Collections.Generic;
using JetBrains.Annotations;
using Oculus.Interaction;
using Unity.Mathematics;
using Unity.Services.Authentication;
using UnityEngine;
using UnityEngine.ProBuilder;

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
    public GameObject nidel;
    private bool nidelspawned = false;
    public Transform nidelpos;
    public Transform grinder1;
    public Transform grinder2;
    public Transform grinder3;
    public Transform grinder4;
    public float Grinder1Y, Grinder2Y, Grinder3Y, Grinder4Y, Rotationration = 15f;

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
        Grinder1Y = grinder1.eulerAngles.y;
        Grinder2Y = grinder2.eulerAngles.y;
        Grinder3Y = grinder3.eulerAngles.y;
        Grinder4Y = grinder4.eulerAngles.y;
    }

    void Update()
    {
        WordCheck();
        nextcharecter(grinder1, ref Grinder1Y,firstGroup);
        nextcharecter(grinder2, ref Grinder2Y,secondGroup);
        nextcharecter(grinder3, ref Grinder3Y,thirdGroup);
        nextcharecter(grinder4, ref Grinder4Y,forthGroup);

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

    public void Firsstgroup()
    {


        CycleNext(firstGroup);

    }
    public void secondddgroup()
    {
        CycleNext(secondGroup);
    }
    public void thirdgroup()
    {
        CycleNext(thirdGroup);
    }
    public void forthgroup()
    {
        CycleNext(forthGroup);
    }


    public void WordCheck()
    {
        Debug.Log(firstGroup.currentIndex + ("first wprd"));
        Debug.Log(secondGroup.currentIndex + ("second wprd"));
        Debug.Log(thirdGroup.currentIndex + ("third wprd"));
        Debug.Log(forthGroup.currentIndex + ("forth wprd"));

        if (firstGroup.currentIndex == 1 && secondGroup.currentIndex == 10 && thirdGroup.currentIndex == 5 && forthGroup.currentIndex == 23 && nidelspawned == false)
        {
            Instantiate(nidel, nidelpos.position, quaternion.identity);
            nidelspawned = true;

            Debug.Log("correct");
        }


    }
    public void nextcharecter(Transform grinder, ref float lastY, LetterGroup group)
    {
        float currentY = grinder.eulerAngles.y;
        float deltaY = Mathf.DeltaAngle(lastY, currentY);

        if (Mathf.Abs(deltaY) >= Rotationration)
        {
            if (deltaY > 0)
            {
                CycleNext(group);
            }
            else
            {
                CyclePrevious(group);
            }

                lastY = currentY;
            }






        }
    } 



