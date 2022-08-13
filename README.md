# Financial service
> Simple financial app created with Blazor Server.

## Table of contents
- [Financial service](#financial-service)
  - [Table of contents](#table-of-contents)
  - [General info](#general-info)
  - [Technologies](#technologies)
  - [Setup](#setup)
  - [Code Examples](#code-examples)
  - [Features](#features)
  - [Status](#status)


## General info
For now project contains only the simplest features.

Bootstrap replaced with MudBlazor.

Electricity bill adds to FixedCosts every other month. (base is MonthOfFirstPayment)


## Technologies
* [.Net](https://dotnet.microsoft.com/en-us/download) - version 6.0.301
* [C#](https://dotnet.microsoft.com/en-us/download) - version 10
* [MudBlazor](https://mudblazor.com/getting-started/installation#manual-install-add-imports) -  version 6.0.14
* [Docker](https://www.docker.com/get-started/) - version 3.8
* [SQL-Server](https://docs.microsoft.com/en-us/sql/linux/sql-server-linux-docker-container-deployment?view=sql-server-ver16&pivots=cs1-bash) - version 2019-latest

## Setup
* Change '_host' in GetFormatedDataService to your endpoint
* Create your own '.env' file to store database password or just paste your password into 'docker-compose.yaml'
* Set user-secrets for 'sqlConBuilder' in 'Program.cs' or just paste your credentials as string

## Code Examples
Examples:
`Also soon`

## Features
List of features ready and TODOs for future development.

Ready:
* Expenses and Earnings pages. (CRUD support)
* FixedIncome and FixedCosts pages. (CRUD support)
* Basic validation and exception handling for custom components.
* Dashboard page.

To-do list:
* Support for weekly payments (like bi-weekly salary payments)
* Support for monthly elecriticy bills payment (Just add category and write some code in GetFormatedDataService)
* Write some tests



## Status
Project is: _in progress_

