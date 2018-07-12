# C# Categories Application

#### By Ryan Putman & Devin Mounts, 07.12.2018

## Description

A web application that explores categories through food, using a many to one database relationship.

## Setup

1. Download and install .NET 1.1.4
1. Clone the repo https://github.com/devinmounts/Categories.Solution.git
1. Navigate into the clone directory
1. Run `dotnet build` from project directory and fix any build errors
1. Run `dotnet test` from the test directory to run the testing suite
1. Alter `DbNameHere` in Startup.cs to connect to the database of your choice

## Usage

* Option available to set up your git pairs file at the root directory
* Option available to create a base C# ASP.NET project that includes:
  * Controllers directory with single HomeController file
  * Views directory with basic index view and Layout partial
  * Models directory with single class file
  * Database.cs file in Models directory
  * ModelTests directory with single test class file
  * ControllerTests directory with single test class file
  * csproj files with ASP.NET, testing packages, MySQL Connector, and 
  * Startup.cs for ASP.NET
  * Program.cs for ASP.NET
  * wwwroot directory for static assets
  * README.md outline
* Initializes git and git pair in project directory
* Installs packages with `dotnet restore` in test directory and project directory

## Contribution Requirements

1. Clone the repo
1. Make a new branch
1. Commit and push your changes
1. Create a PR

## Technologies Used

* .NET 1.1.4
* Bash
* Git

## Links

* [Github Repo] (https://github.com/devinmounts/Categories.Solution.git)

## License

This software is licensed under the MIT license.

Copyright (c) 2018 **Devin Mounts & Ryan Putman**