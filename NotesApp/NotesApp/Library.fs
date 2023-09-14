namespace NotesApp

open System
open System.IO

module Notes =
    let initFolder folderName =
        let userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
        let notesFolderPath = Path.Combine(userFolder, folderName)

        if not (Directory.Exists(notesFolderPath)) then
            Directory.CreateDirectory(notesFolderPath)
            printfn "Folder '%s' created in the user's profile folder." folderName
            

    let getNotesFromFolder =
        fun folder ->
            let files = Directory.GetFiles(folder)
            let fileNames = files |> Array.map Path.GetFileNameWithoutExtension
            fileNames

    let readContentFromNote =
        fun file ->
            let path = file + ".txt"
            if File.Exists(path) then
                File.ReadAllText(path)
            else ""

    let createNote = 
        fun folder name ->
            let path = Path.Combine(folder, name)
            if not (File.Exists(path)) then
                File.Create(path)
                "Note created"
            else 
                "Note already exists"

    let deleteNote =
        fun file ->
            let path = file + ".txt"
            if File.Exists(path) then
                File.Delete(path)

    let updateNote =
        fun file text ->
            let path = file + ".txt"
            if File.Exists(path) then
                File.WriteAllText(path, text)