<a name="readme-top"></a>

<br />
<div align="center">
<a href="https://github.com/martinbassi/gameofdrones">
    <img src="logo.png" alt="Game of Drones Logo" width="131" height="108">
  </a>
<h3 align="center">Game of Drones</h3>

<p align="center">
    A special mini game
</p>
</div>

<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#installation">Installation</a></li>
        <li><a href="#running-project">Running Project</a></li>
        <li><a href="#code-styles-and-formatting">Code Styles and Formatting</a></li>
        <li><a href="#test">Test</a></li>
      </ul>
    </li>
    <li><a href="#contributing">Contributing</a></li>
  </ol>
</details>


## About The Project

The project was generated using the [Clean.Architecture.Solution.Template](https://github.com/jasontaylordev/CleanArchitecture) version 8.0.6.
<br><br>

<p align="right">(<a href="#readme-top">back to top</a>)</p>


### Built With

* [![SQLServer][SQLServer]][SQLServer-url]
* [![FluentValidation][FluentValidation]][FluentValidation-url]
* [![Mediatr][Mediatr]][Mediatr-url]


<p align="right">(<a href="#readme-top">back to top</a>)</p>


## Getting Started

To get a local copy up and running follow these steps.

### Installation

1. Clone the repo
   ```bash
   git clone https://github.com/martinbassi/gameofdrones.git
   ```
2. Run Migrations
   <br><br>
   We have the migrations into the "Infrastructure" project. So, at the root of the subdirectory *src\Infrastructure*, you have to run Migrations for this context.
   <br><br>
   
     ```bash
     dotnet ef database update --project . -- "Server=(localdb)\MSSQLLocalDB;Database=GameOfDronesDB;Trusted_Connection=True;"
     ```
     <br>

### Running Project

```bash
cd .\src\Web\
dotnet watch run
```

Navigate to https://localhost:5001. The application will automatically reload if you change any of the source files.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

### Code Styles and Formatting

The template includes [EditorConfig](https://editorconfig.org/) support to help maintain consistent coding styles for multiple developers working on the same project across various editors and IDEs. The **.editorconfig** file defines the coding styles applicable to this solution.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

### Test

The solution contains unit, integration and functional tests.

To run the unit, integration, and functional tests:
```bash
dotnet test
```

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Contributing

Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please clone the repo and create a pull request. Thanks again!

1. Create your Feature Branch (`git checkout -b feature/amazing-feature`)
2. Commit your Changes (`git commit -m 'Add some Amazing Feature'`)
3. Push to the Branch (`git push origin feature/amazing-feature`)
4. Open a Pull Request

<p align="right">(<a href="#readme-top">back to top</a>)</p>


[SQLServer]: https://img.shields.io/badge/SQL_Server-F7F7F7?style=for-the-badge&logo=microsoftsqlserver&logoColor=96434E
[SQLServer-url]: https://www.microsoft.com/es-es/sql-server/sql-server-2019
[FluentValidation]: https://img.shields.io/badge/Fluent_Validation-4A4A55?style=for-the-badge&logo=diaspora&logoColor=FF0000
[FluentValidation-url]: https://fluentvalidation.net/
[Mediatr]: https://img.shields.io/badge/MediatR-FF2D20?style=for-the-badge&logo=macys&logoColor=white
[Mediatr-url]: https://github.com/jbogard/MediatR