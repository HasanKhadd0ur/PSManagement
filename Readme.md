# Project Status Managment Server 
> in this file we will explain the solution\
> and discuss the used patterns and architecture 


___



## Table Of Contents
1. Theoretical Introduction 
2. Solution Components
3. Shared Kernel
4. Domain Layer 
5. Applciation Layer 
6. Infratstucture Layer 
7. Presentaion Layer 
8. Architecture Tests 
9. Integeration With LDAP Explaination 
10. Get Started 
11. conclusion

___

## Theroretical Introuction 
> this chapter give the reader a general and comperhencevie overview on the clean acrchitecture and some DDD principles.


### General Into to CA & DDD
Clean Architecture and Domain-Driven Design (DDD) are both pivotal methodologies in modern software development that focus on creating robust, maintainable, and scalable systems.

**Clean Architecture**, popularized by Robert C. Martin, emphasizes the separation of concerns within an application. It organizes code into distinct layers, each with its own responsibility, such as the domain, application, interface, and infrastructure layers. This separation ensures that business logic remains independent of external factors like UI frameworks and data storage mechanisms. By adhering to this structure, Clean Architecture promotes code that is easier to test, maintain, and evolve over time, as changes in one layer have minimal impact on others.

**Domain-Driven Design (DDD)**, introduced by Eric Evans, centers on modeling complex business domains and aligning the software design closely with business needs. DDD advocates for creating a shared language between developers and domain experts, focusing on the core domain and its interactions. It involves defining bounded contexts, which are distinct areas of the domain with their own models and rules, ensuring that different parts of the system communicate effectively while preserving their own integrity. By focusing on the domain model and its entities, DDD helps in developing software that is more aligned with business objectives and adaptable to changing requirements.

When combined, Clean Architecture and DDD provide a powerful framework for building software that is not only well-organized and maintainable but also deeply aligned with business logic, facilitating clearer communication between technical and non-technical stakeholders and fostering a more responsive and agile development process.



In the context of ASP.NET Core, Clean Architecture and Domain-Driven Design (DDD) can significantly enhance the maintainability and scalability of applications. These methodologies, along with Command Query Responsibility Segregation (CQRS), provide a structured approach to organizing code and managing complex business requirements.

### **Clean Architecture in ASP.NET Core**

**Clean Architecture** focuses on creating a well-organized, decoupled system by separating concerns into distinct layers. In ASP.NET Core, Clean Architecture can be implemented as follows:

1. **Core Layer (Domain Layer)**:
   - **Entities**: Represents the core business objects or models.
   - **Value Objects**: Immutable objects that represent descriptive aspects of the domain.
   - **Aggregates and Aggregate Roots**: Groups of related entities that are treated as a single unit for data changes.
   - **Interfaces**: Define contracts for repositories and services that interact with the domain.

2. **Application Layer**:
   - **Use Cases**: Contains application-specific business logic and orchestrates the flow of data between the domain and presentation layers.
   - **DTOs (Data Transfer Objects)**: Simplified data structures used for communication between the layers.

3. **Infrastructure Layer**:
   - **Repositories**: Implement data access logic and interact with the database or other external storage.
   - **Services**: Implement services like file storage, email sending, etc.

4. **Presentation Layer**:
   - **Controllers**: Handle HTTP requests, interact with the application layer, and return HTTP responses.
   - **Views**: Define the user interface (in web applications) and handle user input.

By adhering to this layered architecture, ASP.NET Core applications can achieve:
- **Separation of Concerns**: Each layer has a clear responsibility, making the system easier to understand and maintain.
- **Testability**: Core business logic is isolated from infrastructure concerns, allowing for easier unit testing.
- **Flexibility**: Changes in one layer (e.g., switching from SQL Server to MongoDB) have minimal impact on other layers.
![alt text](DFDSF.PNG)

### **Domain-Driven Design (DDD) in ASP.NET Core**

**Domain-Driven Design (DDD)** emphasizes building software based on the core business domain and its logic. In ASP.NET Core, DDD is applied through:

1. **Domain Models**: Represent the core business concepts and rules. Entities, value objects, and aggregates are designed to reflect the real-world domain.

2. **Bounded Contexts**: Define distinct areas of the domain with clear boundaries. Each bounded context has its own domain model and language, ensuring that different parts of the system do not interfere with each other.

3. **Ubiquitous Language**: A common vocabulary shared by developers and domain experts to ensure clarity and alignment throughout the project.

4. **Repositories**: Repositories handle data acces, ensuring that domain rules are maintained when data is persisted.By offer a Contract for store and retreive data independ of the data store approach

5. **Domain Events**: Represent significant changes or actions within the domain. They can trigger processes or updates across different parts of the system.

### **Command Query Responsibility Segregation (CQRS) in ASP.NET Core**

**CQRS** is a pattern that separates the read and write operations of a system into distinct models, each optimized for its specific task:

1. **Commands**: Represent actions that change the state of the system. These are handled by command handlers, which process the command, perform the necessary business logic, and update the state.

2. **Queries**: Represent requests for data without changing the state. These are handled by query handlers, which retrieve data from read models optimized for querying.

In ASP.NET Core, CQRS is implemented as follows:
- **Command Handlers**: Manage the execution of commands, interacting with the domain and possibly updating the state in the database.
- **Query Handlers**: Fetch and return data based on queries, often using specialized read models that are optimized for performance.


**Benefits**:
   - **Maintainability**: Clear separation of concerns and well-defined boundaries make the system easier to maintain and evolve.
   - **Scalability**: CQRS allows for scalable read and write operations, handling complex queries and high-throughput scenarios efficiently.
   - **Alignment with Business Goals**: DDD ensures that the software remains aligned with business needs and processes.

By applying these methodologies in ASP.NET Core, developers can build applications that are well-structured, flexible, and capable of adapting to changing business requirements.



___
## Solution Components 
### General Overview 
![alt text](assets/General.drawio.svg)

### Soltuion Architecture 
the solution to achive the requirement has 8 projects 
and one prpject for teting the architecture as shown below in  the figure 
![alt text](<assets/Screenshot 2024-08-31 111558.png>)

the source code are as the follow : 
1. Domain Layer achoved by domain project 
2. Applciation Layer achived by applciation project 
3. Shared kernell Layer achived by shard kernell project 
4. Presentaion Layer achived by presentaion and api and contracts projects 
5. Infrastructure Layer achived by Persistence and Services projects 
6. Architecture Tests  achived by architecture tests project 

___
## Shared Kernel Layer 
As its defined by " a concept from Domain-Driven Design (DDD) that refers to a part of the domain model that is shared across multiple bounded contexts within a system. It serves as a common area where multiple parts of the system agree on certain domain concepts and implementations, ensuring consistency and reducing duplication".
in our solution we use it to put our absttraction in its.
this figure show it 

![alt text](<assets/Screenshot 2024-08-29 221715.png>)

its contain the following folders 


    1. CQRS :
    which represent the abstracion and base of the cmmands and queries by those interfaces 
    ICommand and ILoggable Command 
    IQuery and ILoaggableQuery 

>
    2. Domain Events: 
    contain the abstraction of events and there handlers by the interfaces IDomainEvent & IDomainEventHandler

>
    3. Domain Errors:   
    the base of the errors 
>
    4. Repository : 
    the base of repository 
    and so on for the rest.


___
## Domain Layer 


this layer and as we mention in the System Design Chapeter in the report in the paragraph **1.7 Design Principles** we have 7 domains which is as the follow : 

        1. Projects Domain
        2. Projects Types Domain
        3. Customers Domain
        4. Employees Domain
        5. Tracking Domain 
        6. Steps Domain 
        7. Financial Spends
so in the domain layer we have 7 folders one for each domain and we have a folder for the identity domain
as shown in the figure below :


![alt text](<assets/Screenshot 2024-08-29 212124.png>)

and as we say we have a similar archs in each folder becuse of the design principles 
so the figure below show this arch in each domain:



![alt text](<assets/Screenshot 2024-08-29 204830.png>)    

so in each folder (mean a Domain we have the follwing folder )


    1. Entities : 
    the entities in this domain which are related to each other 
>
    2. Domain Errors :
    which define an errors that use them the othe layers 

>

    3. Domain Events :
    which define the events in this domain
    this event are published and then any handler for the published event will be notified when the event are dispatched 
    and this events publishing are encapsulated by the domain logic (mehtod in the entity class)

>
    4. Specicification:
    hide and offer an uniformed inteface for oragnize sort order aggregate and paginate the data that are retreived from repository 

>
    5. Value Objects :
    gathe some imutable properties make the reading and understanding of the entier entity better.

>
    6. Repository :
    a contracts that hide the opeations of store and
    retreive data>

___ 
#### **very important note**
in the domain of proejct :
its the mean domain in our system so it has some speicality, 
in it we use in it a State Pattern 
and a builder Pattern 

____


## Application Layer 
this layer responsible for the encapsulation of  the buisness rules via use case.

this layer and as shown in the figure below have to main parts :

    1. Use Cases Encapsulation
    the encapsulation avhived by the CQRS pattern.  

>
    2. Services Abstrraction 
    this abstraction ahcived by  contracts fro this operation (Interfaces)


   ![alt text](<assets/Screenshot 2024-08-29 182735.png>)

### Use Cases Encapsulation 
in this layer we use the follwoing  patternse :


        1. Mediator via MediatR Package to implement CQRS 
>
        2. Event Sourcing also via MediatR Package for handling the events 
>
        3. Result pattern to controll the flow
        and this pattern achive via the Ardalis.Result Package 
>
        4. Unit of Work Pattern for mange the transaction of ops to work as a single unit and it achive via our abstraction in the shared kernell 
>
        5. for logging and validation 
        we use also MediatR via its Pipeline Behavior which achive it via chain of responsiblility pattern

in this layer for use cases we have our 7 domains 
and each domain consist of the folwoing architecture:


        1. Use Cases
        this folder contain two inner folders 
        one for Queries and the second for commands 

>
        2. Common
        the common folder conatino the DTO's(Data Transfare Objects)

        3. Events Handlers
        this folder contain the handlers of the events tht should be handled in this layer which are publish from the domain layer.

as shown in figure below 

![alt text](<assets/Screenshot 2024-08-29 182927.png>) 


__

the figure below show how we implement the CQRS

![alt text](<assets/Screenshot 2024-08-29 183327.png>)


events handlers Ex.

![alt text](<assets/Screenshot 2024-08-29 183414.png>)
__

**Note**
> and we have a folder for the behavior 
> one for validation behavior \
> and the second for loggin (and for loogin we use the serilog package)

__

### Application Contracts 
this folder contain interfaces for the follwoing servise :

    1. email service [jsut for sending email ] 
>
    2. file service [for hide the way of store/retrive the attachments ]
>
    3. Providers :
    one for the current user data 
    one for the employees data [should the implementation retive them from LDAP]
    one fr Departments

>
    4. syncronizing :
    one for employees 
    one for departmets 
    [the need of this interfaces is to write real implementation of the data integration]

>
    5. occupancy notification :
    this is to publsih the work hours of the employees 
>
    6. Authentication & Authorization 
>
    7. Tokens Generation 

the figure below show this folders 


![alt text](<assets/Screenshot 2024-08-29 182850.png>)

___


## Infrastructure Layer
this layer contain two projects 
one  for persisting the data  and its responsibilites is to implement the repositories 
and it should only depend on the doamin layer 
and the second for implement the contracts in the application layer and it should only depend on the applicaation layer>

as shown in the figure below

![alt text](<assets/Screenshot 2024-08-29 232828.png>) 

![alt text](<assets/Screenshot 2024-08-29 232900.png>)

the service layer conatin a real implementation for the integration of the employee data  
and contain only dummy implementation of bringing the data.

its also contain cron job for sync the data 
its call the (sync data service for sync)





___
.

.

.

.

.
___
## Presentaion Layer 
the presentaion layer contain three projects
 one for contract and has no dependency on ay project, its conatin the request and response for the API Endpoints 

 one for API config and middlewares sets 
 its responsibile for inject the deoendencies and chose the infrastructure layer.
 and one for presentation its contain the controllers and mappers from request to commands and from DTO's to Response.

contracts project

![alt text](assets/imageerdf.png)

Presentation proejct

![alt text](assets/imageeer.png)

API Dependency Config in its project
![alt text](assets/image.png)





___
.

.

.

.

___



## Architecture Tests


**Architecture Testing for Clean Architecture** is a practice that ensures the adherence to architectural principles and patterns defined in the Clean Architecture approach. In Clean Architecture, the primary goal is to achieve a separation of concerns where business logic is independent of frameworks, UI, and external systems. Architecture tests verify that the dependencies between layers are correctly enforced — for example, ensuring that the application layer does not directly reference the infrastructure layer. They also ensure that use cases and domain logic remain isolated from external frameworks. 

**Naming Convention Tests for CQRS and Events** (Command Query Responsibility Segregation) are designed to enforce consistency and clarity in naming commands, queries, handlers, and other components associated with the CQRS pattern.
Naming convention tests ensure that commands and queries are named descriptively and according to predefined standards (e.g., suffixing with `Command` or `Query`), which helps maintain clarity and understanding of their responsibilities.and the smae for events.



## for dependency test (layer test)
we do the test that shown in the image and its success 

![alt text](<assets/Screenshot 2024-08-31 090622.png>) 


and we do test for tme naming convention inapplcation 
like all command should have suffix command
and the same for event query and its handlers

![alt text](<assets/Screenshot 2024-08-31 090506.png>) 

and a test for the doamin layer naming convention for events and repositories.

![alt text](<assets/Screenshot 2024-08-31 090540.png>)



____
.

.

.

.

____

### Integration with LDAP 
for integrate with LDAP you only should impment the 
IEmployeeesDataProviders servcie 


___
.

.

.
___
### Get Started 

for run the backend server you should do this steps :

#### Prerequesite
> you should have SQL Server DataBase 
> you should have dotnet  

1. first clone the project 

    ````bash 
        git clone https://git.hiast.edu.sy/hasan.bahjat/projectsstatusmanagement.git


        cd projectsstatusmanagement
    ````

2. create empty data base and put he connection string in the appsetting.json 

3. move to the persistence project 
  
    ```bash
        cd PSManagement.Persistence
    ```
4. Apply the migrations 

    ```bash
    
    dotnet ef database update

    ```
5. run the project 
    ```bash
        dotnet run
    ```

6. go to the get started in the frontentsdie 

7. if you dont like  to use the front end you can run it with swagger in iis 


___
## Conclusion 
in conclusion, we build a scalable,maintainable,integratable system using clea architecture and DDD some of priciples.
it consiste of near to 80 API Endpoint

in future we can do a test for the use case and develop a recomendation system for partiipants in the project using AI models.
we can integrate it with LDAP.