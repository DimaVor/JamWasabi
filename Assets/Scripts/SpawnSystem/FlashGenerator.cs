using System.Collections.Generic;
using UnityEngine;

public class FlashGenerator : MonoBehaviour
{
    [SerializeField]
    private List<string> _badFiles = new(){
            "�������������������������.docx",
            "�����������������������������������.pdf",
            "����������������������.xlsx",
            "������������������������������.doc",
            "��������������������.pptx",
            "�������������������������.docx",
            "�����������������������.pdf",
            "���������������.doc",
            "���������������������.xlsx",
            "����������������������.docx",
            "����������������������������.pdf",
            "�������������������������.pptx",
            "���������������������������.doc",
            "�����������������������.pdf",
            "��������������������������.docx",
            "�����������������������������.pptx",
            "������������������������.xlsx",
            "�����������������.pdf",
            "���������������������������.doc",
            "��������������_������.pdf"
        };
    [SerializeField]
    private List<string> _normalFiles = new(){
            "������_�������.txt",
            "����������_������.jpeg",
            "�������_2023.docx",
            "����_�����������.pdf",
            "�������_�����.mp4",
            "������������_�������.rtf",
            "������_������.xlsx",
            "���������_�������.doc",
            "����������_������.xls",
            "�����_��������.mp3",
            "������_�����.pdf",
            "����_�����.jpg",
            "������_����_2023.docx",
            "���������_������������.pptx",
            "�����������_������.doc",
            "��������_�����.zip",
            "������_���������.pdf",
            "���������_����.txt",
            "������_�����.avi",
            "�������_��������.pdf",
            "������_������_�_������������.rtf",
            "��������_�������.doc",
            "����_�������.jpg",
            "������������_�������_����.xlsx",
            "������_������_�_��������.xls",
            "������_�����.mp4",
            "�����_������.mp3",
            "���������_������_������������.docx",
            "����_�������.jpeg",
            "������_����_�_�����.pptx",
            "����_�����������_2023.doc",
            "�������_�������_�_����.txt",
            "������_������������_��������.pdf",
            "������_�������_�����.avi",
            "������_�����_����������_�_�����.zip",
            "����������_������_�_�������.xlsx",
            "������_����_��_���.docx",
            "������_�������_�����������.rtf",
            "���������_�������_������������.doc",
            "������_���������_�_������.pdf",
            "������_�������.docx",
            "����_�������_�����.jpg",
            "������������_����_�_�����.pptx",
            "������_�����_������.mp4",
            "���������_������_������������.xls",
            "������_������_�����.zip",
            "���������_������_����.txt",
            "������������_�����_�������.avi",
            "�������_��������_�_���������.pdf",
            "������_������_�_������������_2023.rtf",
            "��������_�������_�_�������.doc",
            "����_�������_�_��������.jpg",
            "������������_�������_����_�_������.xlsx",
            "������_������_�_��������_�_��������_2023.xls",
            "������_�����_������.mp4",
            "�����_������_�_������.mp3",
            "���������_������_������������_��������.docx",
            "����_�������_�_������������.jpeg",
            "������_����_�_�����_��_�������_2023.pptx",
            "����_�����������_�_�������.doc",
            "�������_�������_�_����_�_�����.txt",
            "������_������������_��������_�_������������.pdf",
            "������_�������_�����_�_������.avi",
            "������_�����_����������_�_�����_�������.zip",
            "����������_������_�_�������_2023.xlsx",
            "������_����_��_���_�_�����.docx",
            "������_�������_�����������_�_�������.rtf",
            "���������_�������_������������_�_��������.doc",
            "������_���������_�_������_�_��������.pdf",
            "������_�������_�_����������_����.docx",
            "����_�������_�����_�_������.jpg",
            "������������_����_�_�����_��_�������_2023.pptx",
            "������_�����_������_�_������������.mp4",
            "���������_������_������������_�_�������.xls",
            "������_������_�����_�_������.zip",
            "���������_������_����_�_������.txt",
            "������������_�����_�������_�_�������.avi",
            "�������_��������_�_���������_2023.pdf",
            "������_������_�_������������_�_�������.rtf",
            "��������_�������_�_�������_�_�����.doc",
            "����_�������_�_��������_�_�����������.jpg",
            "������������_�������_����_�_������_��_�������.xlsx",
            "������_������_�_��������_�_��������_�_��������_2023.xls",
            "������_�����_������_�_�������.mp4"
        };

    [SerializeField] private int _minFiles;
    [SerializeField] private int _maxFiles;

    [SerializeField] private List<int> _badFilesPrecentage = new();


    [SerializeField] DragFlash _flashPrefab;
    [SerializeField] List<RectTransform> _flashPlaces;


    public Flash GenerateFlash()
    {
        int numOfBadFiles;
        int rand = Random.Range(0, 100);
        if (rand < _badFilesPrecentage[0])
        {
            numOfBadFiles = 0;
        }
        else if (rand < _badFilesPrecentage[1])
        {
            numOfBadFiles = 1;
        }
        else if (rand < _badFilesPrecentage[2])
        {
            numOfBadFiles = 2;
        }
        else
        {
            numOfBadFiles = 3;
        }
        List<string> files = new();
        for (int i = 0; i < Random.Range(_minFiles, _maxFiles + 1); i++)
        {
            files.Add(_normalFiles[Random.Range(0, _normalFiles.Count)]);
        }

        List<int> usedIndexes = new();

        for (int i = 0; i < numOfBadFiles; i++)
        {
            int index;
            do
            {
                index = Random.Range(0, files.Count);
            } while (usedIndexes.Contains(index));

            files[index] = _badFiles[Random.Range(0, _badFiles.Count)];
            usedIndexes.Add(index);
        }

        return new Flash(numOfBadFiles, files);
    }

    public void SpawnFlashes(List<Flash> flashes)
    {
        List<RectTransform> places = new(_flashPlaces);
        for(int i = 0; i < flashes.Count; i++)
        {
            int index = Random.Range(0, places.Count);
            var flash = Instantiate(_flashPrefab, places[0].parent);
            flash.GetComponent<RectTransform>().anchoredPosition = places[index].anchoredPosition;
            flash.SetModel(flashes[i]);
            places.RemoveAt(index);
        }
    }

}
