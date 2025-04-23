# TaskClip

**TaskClip** is a lightweight command-line task manager built with C# and .NET. It allows users to add, list, update, delete, and mark tasks directly from the terminal. All data is stored locally in a JSON file—no external libraries or database needed.

---

## ✨ Features

- Add new tasks with a description  
- List all tasks  
- Update a task's description  
- Delete a task by ID  
- Mark a task as `Pending`, `InProgress`, or `Done`  
- Store tasks in a human-readable JSON file  
- Simple and fast CLI interface

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)

### Build the project

```bash
dotnet build

./bin/Debug/net8.0/TaskClip.exe add "Read a book"
./bin/Debug/net8.0/TaskClip.exe list
./bin/Debug/net8.0/TaskClip.exe update 1 "Read another book"
./bin/Debug/net8.0/TaskClip.exe mark 1 Done
./bin/Debug/net8.0/TaskClip.exe delete 1
