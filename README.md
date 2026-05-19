# HabiCheck11

HabiCheck11 is a C# and HTML-based application (MAUI project) for cross-platform usage.

## Features
- Multi-platform UI built with .NET MAUI (Android, iOS, Windows, MacCatalyst)
- Local data storage using SQLite
- MVVM architecture using CommunityToolkit.Mvvm

## Installation
1. Ensure you have a supported .NET SDK installed (the project targets .NET 10).
2. Clone the repository:
   git clone <repo-url>
3. Restore and build the solution using the provided .slnx file (replace HabiCheck1.slnx if renamed):
   dotnet restore HabiCheck1.slnx
   dotnet build HabiCheck1.slnx

If you have renamed the solution to match the repository (HabiCheck11.slnx), use that filename instead.

## Technologies Used
- .NET 10 / .NET MAUI
- C#
- XAML
- SQLite (sqlite-net-pcl)
- CommunityToolkit.Maui, CommunityToolkit.Mvvm

## Project structure
- HabiCheck1/ (project folder; consider renaming to HabiCheck11/)
  - HabiCheck1.csproj
  - Views/, ViewModels/, Models/, Services/, Platforms/, Resources/

## Notes
- A .gitignore file has been added to prevent tracking of .vs, /bin, /obj and other development artifacts.
- If you rename the solution/project files, follow the "Naming standardization" steps below to safely update references.

## Contact
For development questions, open an issue on the repository.
