# ODDESTODDS.com .NET Core PoC - Odds Portal

This is an example of a very simplified odds display/management system made in a simple DDD/TDD architecture using:

## Technologies

* .NET Core 2.2
* Entity Framework Core 2.2.0
* SignalR 1.1
* Visual Studio 2019
* xUnit Testing Framework 2.4
* Moq 4.11
* FluentValidation.AspNetCore 8.4


**Comprehensive guide describing exactly the architecture, applied design patterns and technologies can be seen above.**

For simplicity purpose, I tried not to use too many separated library as I do when developing any production ready application, for the purpose of this test,
I collocated all the segments in a single project. 



## Setup
To run this project, use either of the following IDE:

* Visual Studio Online
* Visual Studio 2019 Locally

Build to install all referenced packages
Run the project



## Business Case
A simple Real Time ODDs application to Create, Update, Delete, View and Publish new Odds.

The functional requirements for the POC are described using the ’As a... I want... so...’ stories. 

ID	GIG-POC-1
As a	Punter
I want	A screen
So that	I can see 1x2 odds in real time

ID	GIG-POC-2
As a	Odds Handler
I want	A Screen where I can see the current odds 
So that	I can see all the odds from 1 point

ID	GIG-POC-3
As a	Odds Handler
I want	A delete function in the above screen
So that	I delete existing odds

ID	GIG-POC-4
As a	Odds Handler
I want	A Create/Update screen in the backoffice
So that	I can add/update new odds

ID	GIG-POC-5
As a	Odds Handler
I want	A publish button in the backoffice
So that	I can view the latest odds on the screen

