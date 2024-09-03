# eCommerce Application using Microservice Architecture
<div align="center">
  <img src="https://badges.pufler.dev/visits/Aronno1920/Microservices_Ecommerce" alt="Years Badge">
  <img src="https://badges.pufler.dev/updated/Aronno1920/Microservices_Ecommerce" alt="Repos Badge">
  <img src="https://badges.pufler.dev/created/Aronno1920/Microservices_Ecommerce" alt="Gists Badge">
</div>
<br /><br />
This is a microservice application built using .NET 7, various technologies and frameworks commonly used in microservices architecture. The application includes microservices for Product, Basket, Discount and Ordering modules, which are essential for building e-commerce applications.

# Implementation
The microservice application is built using a combination of NoSQL and relational databases. MongoDB and Redis are used for storing unstructured data and caching, while PostgreSQL and SqlServer are used for storing structured data.

Communication between microservices is implemented using RabbitMQ for event-driven communication. The Ocelot API Gateway is used to route requests to the appropriate microservices.

The application is built using the principles of Clean Architecture, which emphasizes the separation of concerns in software design. This makes it easy to maintain and modify the application over time.

# Prerequisites
- Basic knowledge of C#, Asp.Net MVC and REST API
- OOP Concept
- Internet Information Service (IIS)
- Github

# Tootls
- .NET7 or above SDK
- Visual Studio 2022
- Internet Information Service (IIS)
- Postman

<br /><br />
# Development

### Catalog.API with MongoDB
- Assign Port for localhost: 5001
- Packages
	- CoreApiResponse - Custom return type
	- MongoRepo - MongoDB database with repository

### Basket.API with Radis
- Assign Port for localhost: 5002
- Packages
	- CoreApiResponse - Custom return type
	- Microsoft.Extensions.Caching.StackExchangeRedis - Redis database

### Discount.API with PostgreSQL
- Assign Port for localhost: 5003
- Packages
	- CoreApiResponse - Custom return type
	- Npgsql - PostgreSQL database
	- Dapper - ORM (Object Relational Mapping) for database related action

### Discount.Grpc with PostgreSQL
- Assign Port for localhost: 5004
- Packages
	- Grpc.AspNetCore - Grpc services
	- Npgsql - PostgreSQL database
	- Dapper - ORM (Object Relational Mapping) for database related action
	- AutoMapper.Extensions.Microsoft.DependencyInjection - AutoMapper by dependency injection
- gRPC (Google Remote Procedure Call) basics: 
	- Proto File/Protobuf (Proto buffer) - Language neutral format for specifying the messages send and received by gRPC services.
	- Service - Protocol buffer compiler will geneate service interface code ans stubs
	- Protobuf Message - Messages are the main data transfer object in profobuf.
	- Naming Conventions
		- Files should be named lower_snake_case.photo
		- Use CamelCase (with a initial capital) for message and service names, ex: DiscountRequest, CreateDiscount
		- Use underscore_separated_names for field names, ex: product_name, discount_rate
		- The "= 1", "= 2" markers on each element indentify the unique "tag" the field uses in the binary encoding
	- Proto file propeties
		- Build Action: Protobuf compiler
		- gRPC Stub Classes: Server only


		






<br /><br />
# Conclusion
This microservice application demonstrates the use of various .NET technologies and frameworks commonly used in microservices architecture. It provides a practical and hands-on approach to learning microservices architecture, which is essential for developers who want to implement microservices in their own projects.

# Credited
<a href="https://www.youtube.com/watch?v=G-zu-loz4qI&list=PLqCbg_KAOnCfGhU8iK-a-jyuQfvM-i1w7&index=1" target="_blank">Programming Palli</a>