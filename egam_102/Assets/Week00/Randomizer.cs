using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    public bool isCritique = false;

    [System.Serializable]
    public class StudentData
    {
        public string name;
        public bool isPresent;
    }

    public StudentData[] students = null;

    void Start()
    {
        // Build a new list
        List<StudentData> studentList = new List<StudentData>();
        for (int i = 0; i < students.Length; i++)
        {
            if (students[i].isPresent)
            {
                studentList.Add(students[i]);
            }
        }

        // Then randomize the values
        List<StudentData> finalList = new List<StudentData>();
        while (studentList.Count > 0)
        {
            int randomIndex = Random.Range(0, studentList.Count);
            finalList.Add(studentList[randomIndex]);
            studentList.RemoveAt(randomIndex);
        }

        // Output the list
        string output = string.Empty;
        for (int i = 0; i < finalList.Count; i++)
        {
            output += $"#{i + 1}\n"; 

            // This student
            output += $"Presenter: {finalList[i].name}\n"; 

            // Plus the next one
            if (isCritique)
            {
                int nextIndex = (i + 1) % finalList.Count;
                output += $"Playtester: {finalList[nextIndex].name}\n"; 
            }

            output += $"\n"; 
        }

        Debug.Log(output);
    }
}
