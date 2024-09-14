// See https://aka.ms/new-console-template for more information

using System;
using System.IO;
using System.Collections;
using System.Security.AccessControl;

// Convertit un tableau quelconque en liste
List<T> ConvertArrayToList<T> (T[] elem)
{
    var res = new List<T>();
    foreach (var co in elem)
    {
        res.Add(co);
    }
    return res;
}

// Permet d'énumérer tous les fichiers pour chaque lecteur
void AllFiles()
{
    DriveInfo[] hdd = DriveInfo.GetDrives();
    foreach (DriveInfo hd in hdd)
    {
        SubDirectory(hd.Name);
    }
}

// Pour un dossier donné, capable d'afficher 
void SubDirectory(string path)
{
    try
    {
        if (Directory.GetFiles(path).Length != 0)
        {
            List<string> files = new List<string>();
            var tmp = Directory.GetFiles(path);
            foreach (string file in tmp)
            {
                Console.WriteLine(file);
            }
            files.AddRange(tmp);
        }
        if (Directory.GetDirectories(path).Length != 0)
        {
            var tmpDir = Directory.GetDirectories(path);
            foreach (var dir in tmpDir)
            {
                SubDirectory(dir);
            }
        }
    }
    catch (Exception ex)
    {

    }

}


AllFiles();