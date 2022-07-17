# :page_with_curl: CsvParser

<div id="header" align="center">
  <img src="https://media.giphy.com/media/vXZJBKjb0UtpFWzvpQ/giphy.gif" width="100"/> 
</div>
</br>

## :link: Table of contents
1. [Introduction](#introduction)
2. [Application Overview](#applicationOverview)
   1. [Technologies Used](#technologiesUsed)
   2. [API Reference](#APIReference)
3. [Pre-requisites](#prerequisites)
4. [Getting Started](#gettingStarted)
   1. [Application Setup](#applicationsetup)
   2. [Restore Dependencies](#restoredependencies)
   3. [Run Application](#runapplication)
   4. [Running Tests](#runningtests)
   5. [Main Entry Point](#mainentrypoint)



## Introduction :wave: <a name="introduction"></a>
An API app designed to parse a CSV file and return records based on a set of criteria. 

## :computer: Application Overview <a name="applicationOverview"></a>

### ⚒️ Technologies Used <a name="technologiesUsed"></a>

<div>
<img align="left" alt="C#" title="C-Sharp" src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white" />
<img align="left" alt=".NET 6" title=".NET 6" src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
<img align="left" alt="ASP.NET MVC 6 (Web API)" title="ASP.NET MVC 6 (Web API)" src="https://img.shields.io/badge/-ASP.NET%20Core-fff?style=for-the-badge&logo=.net&logoColor=blue" />
<img align="left" alt="EntityFramework" title="MS EntityFramework Core 6" src="https://img.shields.io/badge/-Entity_Framework_Core-fff?style=for-the-badge&logo=Microsoft&logoColor=0078D7" />
  <img align="left" alt="Swagger"  src="https://img.shields.io/badge/-Swagger-%23Clojure?style=for-the-badge&logo=swagger&logoColor=white" />
</div>
</br></br>

### 🔄 API Reference <a name="APIReference"></a>

#### Load data from CSV file

```http
  POST /api/v1/parser
```

| Usage                  | ReturnType | Description                                                                 |
| :----------------------| :----------| :---------------------------------------------------------------------------|
| `Load all people data` | `int`      | Reads data from file and persists to database, returns count of rows loaded |

#### Get all people

```http
  GET /api/v1/people[action]
```

| Action                                  | ReturnType     | Description                                                              |
| :-------------------------------------  | :--------------| :------------------------------------------------------------------------|
| `Get people with 'Esq' in Company Name` | `List<Object>` | Returns a list of people who have the string 'Esq' in their company name |

#### Get all people whose Company Name contains string 'Esq'

```http
  GET /api/v1/people/[action]
```

| Action                          | ReturnType     | Description                                                       |
| :------------------------------ | :--------------| :-----------------------------------------------------------------|
| `Get people from Derbyshire`    | `List<Object>` | returns a list of people who live in county Derbyshire            |

#### Get all people where house number is three digits

```http
  GET /api/v1/people/[action]
```

| Action                                              | ReturnType    | Description                                                       |
| :---------------------------------------------------| :-------------| :-----------------------------------------------------------------|
| `Get people whose house number is exactly 3 digits` | `List<Object>`| returns a list of people whose house number is exactly 3 digits   |

#### Get all people whose web URL has more than 35 characters

```http
  GET /api/v1/people/[action]
```

| Action                                                              | ReturnType    | Description                                                       |
| :-------------------------------------------------------------------| :-------------| :-----------------------------------------------------------------|
| `Get people whose website URL length is greater than 35 characters` | `List<Object>`| returns a list of people whose URL length > 35                    |

#### Get all people whose postcode contains only one digit after the city code, example SE2

```http
  GET /api/v1/people/[action]
```

| Action                                                        | ReturnType    | Description                                                       |
| :-------------------------------------------------------------| :-------------| :-----------------------------------------------------------------|
| `Get people who live in a postcode with a single digit value` | `List<Object>`| returns list of people whose postcode contains one digit          |


## Pre-requisites <a name="prerequisites"></a>

* C# / .NET 6
* NuGet

## 🔀 Getting Started <a name="gettingStarted"></a>

### Application Setup <a name="applicationsetup"></a>

Fork this repo to your Github and then clone the forked version of this repo.

- Setup:
	- Open up project in Visual Studio
	- This application requires a path pointing to a csv file. By default the path is set to `@"D:\Data\input.csv"`:
	 -  To use this application you will neeed to either specify a new file path or create a folder with a file in the default directory location
	  - You will need to modify the path in the following files:
	    * [ParserManagementService.cs](https://github.com/Hayley96/CsvParser/blob/main/CsvParserApp/Services/ParserManagementService.cs)
	      * ![ParserManagementServiceFilePath](https://github.com/Hayley96/CsvParser/blob/main/ParserManagementService_FilePath.PNG)
	    * [CsvParserTests.cs](https://github.com/Hayley96/CsvParser/blob/main/CsvParserAppTests/CsvParserTests/CsvParserTests.cs)
	      * ![CsvParserTests](https://github.com/Hayley96/CsvParser/blob/main/CsvParserTests_FilePath.PNG)
	    * [ParserServicesTests.cs](https://github.com/Hayley96/CsvParser/blob/main/CsvParserAppTests/Services/ParserServicesTests.cs)
	      * ![ParserServicesTests](https://github.com/Hayley96/CsvParser/blob/main/ParserServicesTest_FilePath.PNG)

### Restore Dependencies <a name="restoredependencies"></a>

- Open up a terminal and navigate to the root folder of the main application directory [CsvParser](./CsvParserApp):
 - run: `dotnet restore`

### Run Application <a name="runapplication"></a>

- You can run the application in Visual Studio, or you can go to your terminal and inside the root of this directory, run:
 - run: `dotnet run`

### Running the Unit Tests <a name="runningtests"></a>

- You can run the unit tests in Visual Studio, or you can go to your terminal and inside the root of this directory, run:
  - `dotnet test`

### Main Entry Point <a name="mainentrypoint"></a>
- The Main Entry Point for the application is: [Program.cs](https://github.com/Hayley96/CsvParser/blob/main/CsvParserApp/Program.cs)


## Thank you!! 👋
