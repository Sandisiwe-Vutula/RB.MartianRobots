# RB.MartianRobots - .NET 8 Martian Robots Console Application

### CI Badge - Clear visibility of the state of our Build and Unit Tests still pass

![.NET Build Status](https://github.com/Sandisiwe-Vutula/RB.MartianRobots/actions/workflows/dotnet.yml/badge.svg)


## Problem Overview

This project simulates a fleet of robots navigating the surface of Mars on a rectangular grid. Robots follow a set of instructions `L`, `R`, and `F` to rotate or move forward. If a robot moves beyond the grid boundaries, it's considered **LOST**, but it leaves a **scent** behind to warn future robots from following the same path off the edge.

Each robot executes its instructions **sequentially** and independently. The final output reflects the robot's last position and orientation appending `LOST` if it fell off the grid.

This solution was implemented for the Martian Robots challenge for **Red Badger** using **.NET 8**, focusing on clean, modularity, testability, and maintainability.

---

## Project Architecture

```text
RB.MartianRobots/
	RB.MartianRobots.App/
	      - Program.cs                  # Main entry point
	      - Input/
                 - SampleInput.txt          # Input file
              - Models/                     # Domain models: Grid, Robot, Direction
              - Commands/                   
		   - Contract		    # Interface to extend any new Command type			
		   - Implimentation	    # L, R, F implemented as commands
              - Services/                   # Instruction parser from input
        RB.MartianRobots.Tests/             # Unit tests
```

---

## Getting Started

### Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/download)
- Git CLI
- Visual Studio 2022 or VS Code

---

### Run Locally

```bash
# 1. Clone the repository
git clone https://github.com/Sandisiwe-Vutula/RB.MartianRobots.git
cd RB.MartianRobots

# 2. Build the solution
dotnet build

# 3. dotnet run --project RB.MartianRobots
```

### Sample Input

The sample input data is located in: RB.MartianRobots/Input/SampleInput.txt

---

## Running Tests

The solution includes unit tests using `xUnit`.

```bash
dotnet test
```
---

## Tech Stack & Libraries

### `Component				Purpose`
```
     .NET 8 Console App			Lightweight, fast, no UI required

     xUnit				        Unit testing framework

     Clean Architecture			Promotes separation of concerns

     Command Pattern			Supports future extensibility of commands

     GitHub Actions			    CI pipeline for builds/tests
```

### `Why these choices?`
```
Console app: The problem does not require UI. Keeping it minimal supports the "Keep It Simple" principle.

Command Pattern: Instructions like `L`, `R`, and `F` are modeled as commands, making the application open for extension.

Clean Architecture: Each component (model, command, service) is isolated, testable, and easy to maintain.

xUnit + CI: Automated testing and validation via GitHub Actions builds confidence in code quality.

```

---

## Design Decisions

**Single Responsibility:** Each class does one thing — parsing, simulating, or executing instructions.

**Open/Closed Principle:** Commands implement a shared interface, allowing easy addition of new command types.

**Sequential Execution:** Robots are processed one at a time in isolation, as per the challenge requirements.


---

## Continuous Integration (CI)

GitHub Actions automatically builds and tests the solution for every push to the `main` branch.

CI file: `.github/workflows/dotnet.yml`

```yaml
- dotnet restore
- dotnet build --configuration Release
- dotnet test --configuration Release
```

---

## Author:

**Sandisiwe Vutula**   
sandisiwevutula28@gmail.com  
Cape Town, South Africa  
[LinkedIn Profile](https://www.linkedin.com/in/sandisiwe-vutula-20421b97/)

---