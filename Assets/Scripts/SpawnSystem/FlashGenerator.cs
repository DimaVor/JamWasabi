using System.Collections.Generic;
using UnityEngine;

public class FlashGenerator : MonoBehaviour
{
    [SerializeField]
    private List<string> _badFiles = new(){
            "КорпоративныйПланРазвития.docx",
            "СтратегическийПартнерскийСоглашение.pdf",
            "ФинансовыйОтчетГодовой.xlsx",
            "КонфиденциальныеДанныеКлиентов.doc",
            "ПроектНовогоПродукта.pptx",
            "ПланМаркетинговыхКампаний.docx",
            "ИсследованиеКонкурентов.pdf",
            "ПатентныеЗаявки.doc",
            "ПланЗакупокМатериалов.xlsx",
            "ЛичныеДосьеСотрудников.docx",
            "ЗакрытыеТендерныеПредложения.pdf",
            "ПроектИнновацийТехнологии.pptx",
            "КорпоративнаяСтратегияРоста.doc",
            "СекретныйОтчётАналитики.pdf",
            "ПолитикаКонфиденциальности.docx",
            "ПроектОбеспеченияБезопасности.pptx",
            "ФинансовыеПланыНаБудущее.xlsx",
            "ИсследованиеРынка.pdf",
            "ЗаговорЗагадочныхДокументов.doc",
            "СуперСекретные_Данные.pdf"
        };
    [SerializeField]
    private List<string> _normalFiles = new(){
            "личные_заметки.txt",
            "фотоальбом_отпуск.jpeg",
            "дневник_2023.docx",
            "план_путешествия.pdf",
            "частное_видео.mp4",
            "персональный_блокнот.rtf",
            "личный_бюджет.xlsx",
            "секретный_дневник.doc",
            "финансовые_записи.xls",
            "аудио_плейлист.mp3",
            "письмо_другу.pdf",
            "фото_семьи.jpg",
            "личные_цели_2023.docx",
            "секретное_исследование.pptx",
            "специальный_проект.doc",
            "закрытые_файлы.zip",
            "важные_документы.pdf",
            "коллекция_книг.txt",
            "личное_видео.avi",
            "дневник_рецептов.pdf",
            "личные_записи_о_путешествиях.rtf",
            "семейные_моменты.doc",
            "фото_природы.jpg",
            "персональный_блокнот_идей.xlsx",
            "личные_записи_о_покупках.xls",
            "важное_видео.mp4",
            "аудио_память.mp3",
            "секретный_проект_исследования.docx",
            "фото_моменты.jpeg",
            "личные_цели_и_планы.pptx",
            "план_путешествия_2023.doc",
            "дневник_заметок_и_идеи.txt",
            "личные_исследования_проектов.pdf",
            "важные_моменты_видео.avi",
            "личный_архив_фотографий_и_видео.zip",
            "финансовые_записи_и_расходы.xlsx",
            "личные_цели_на_год.docx",
            "личный_дневник_путешествий.rtf",
            "секретный_дневник_исследований.doc",
            "важные_документы_и_записи.pdf",
            "личные_рецепты.docx",
            "фото_моменты_семьи.jpg",
            "персональные_цели_и_планы.pptx",
            "личное_видео_записи.mp4",
            "секретный_проект_документации.xls",
            "важные_личные_файлы.zip",
            "коллекция_личных_книг.txt",
            "персональное_видео_дневник.avi",
            "дневник_рецептов_и_кулинарии.pdf",
            "личные_записи_о_путешествиях_2023.rtf",
            "семейные_моменты_и_события.doc",
            "фото_природы_и_пейзажей.jpg",
            "персональный_блокнот_идей_и_планов.xlsx",
            "личные_записи_о_покупках_и_расходах_2023.xls",
            "важное_видео_записи.mp4",
            "аудио_память_и_записи.mp3",
            "секретный_проект_исследования_компании.docx",
            "фото_моменты_и_воспоминания.jpeg",
            "личные_цели_и_планы_на_будущее_2023.pptx",
            "план_путешествия_и_отпуска.doc",
            "дневник_заметок_и_идеи_о_жизни.txt",
            "личные_исследования_проектов_и_эксперименты.pdf",
            "важные_моменты_видео_и_фильмы.avi",
            "личный_архив_фотографий_и_видео_записей.zip",
            "финансовые_записи_и_расходы_2023.xlsx",
            "личные_цели_на_год_и_планы.docx",
            "личный_дневник_путешествий_и_поездок.rtf",
            "секретный_дневник_исследований_и_открытий.doc",
            "важные_документы_и_записи_о_событиях.pdf",
            "личные_рецепты_и_кулинарные_идеи.docx",
            "фото_моменты_семьи_и_друзей.jpg",
            "персональные_цели_и_планы_на_будущее_2023.pptx",
            "личное_видео_записи_и_воспоминания.mp4",
            "секретный_проект_документации_и_отчетов.xls",
            "важные_личные_файлы_и_записи.zip",
            "коллекция_личных_книг_и_чтения.txt",
            "персональное_видео_дневник_и_моменты.avi",
            "дневник_рецептов_и_кулинарии_2023.pdf",
            "личные_записи_о_путешествиях_и_отпуске.rtf",
            "семейные_моменты_и_события_в_жизни.doc",
            "фото_природы_и_пейзажей_и_путешествий.jpg",
            "персональный_блокнот_идей_и_планов_на_будущее.xlsx",
            "личные_записи_о_покупках_и_расходах_и_событиях_2023.xls",
            "важное_видео_записи_и_моменты.mp4"
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
