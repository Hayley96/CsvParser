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
3. [Getting Started](#gettingStarted)
    1. [Pre-requisites](#prerequisites)


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



## 🔀 Getting Started <a name="gettingStarted"></a>

### Pre-requisites <a name="prerequisites"></a>

* C# / .NET 6
* NuGet

//IN PROGRESS
