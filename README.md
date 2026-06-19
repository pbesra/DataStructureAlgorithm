# Data Structures & Algorithms

This repository contains implementations and exercises for data structures and algorithms in C++ and C#.

Key areas:
- `src/dsa.cpp/` — C++ algorithms, data structures, and problem statements
- `src/dsa.csharp/` — C# solutions, libraries and tests (contains a `.sln` and multiple projects)

Purpose: quick practice, reference implementations, and interview prep.

---

## Repository layout

- `src/dsa.cpp/algorithms/` — sorting, graph algorithms, search
- `src/dsa.cpp/data-structure/` — lists, trees, stacks, queues, heaps
- `src/dsa.cpp/problem-statements/` — solved problems and challenges
- `src/dsa.csharp/` — C# solution, library projects and tests (uses .NET SDK)
- `templates/` — small example templates and starter files

---

## Languages & tooling

- C++: code is plain source files. Build with `g++`/`clang++` or MSVC (Visual Studio).
- C#: projects use the .NET SDK (`dotnet`). Requires .NET 8+ to build/run the included solution.

---

## Quick start — C++ examples

To compile and run a single example (cross-platform with `g++`):

```bash
g++ -std=c++17 -O2 src/dsa.cpp/algorithms/binary-search.cpp -o bin/binary-search
./bin/binary-search
```

On Windows with MSVC (Developer Command Prompt):

```powershell
cl /EHsc /std:c++17 src\dsa.cpp\algorithms\binary-search.cpp /Fe:bin\binary-search.exe
bin\binary-search.exe
```

Notes:
- Many examples are small, standalone programs — compile the single `.cpp` file you want to run.
- If an example depends on other files, compile them together or create a small CMake project.

---

## Quick start — C# projects

Build and run the full solution (recommended):

```bash
cd src/dsa.csharp/dsa.csharp
dotnet build
dotnet run --project dsa.csharp/dsa.csharp.csproj
```

Run tests:

```bash
dotnet test
```

Run a single C# script file (convenient for small snippets):

Option A — using `dotnet-script` (recommended):

```bash
dotnet tool install -g dotnet-script
dotnet script path/to/FileName.cs
```

Option B — using `dotnet` interactive source (requires .NET 8+):

```bash
dotnet run --source path/to/FileName.cs
```

---

## Contribution & style

- Keep implementations small and focused.
- Add tests for non-trivial algorithms in the C# test projects under `dsa.DataStructureTests`.
- Open PRs with clear descriptions and a short test or example demonstrating the change.

---

## Suggested next steps

- Add a small `CMakeLists.txt` for the C++ folder to simplify building multiple examples.
- Add CI (GitHub Actions) to build C++ examples and run `dotnet test` for the C# projects.

---

If you'd like, I can:
- add a `CMakeLists.txt` for `src/dsa.cpp` and a small runner script, or
- create a GitHub Actions workflow that builds C++ and runs the C# tests.
Tell me which you'd prefer and I'll implement it.
