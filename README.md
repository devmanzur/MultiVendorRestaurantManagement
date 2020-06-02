## MultiVendorRestaurantManagement
A multi vendor restaurant management API built with DDD. While it may not be perfect I am always improving myself and this codebase.
This project also includes a dialogflow based bot that can be used to integrate with any existing platform like facebook, whatsapp, telegram etc.

## Motivation
The motivation for the project was to implement some real world projects. So i took uber eats to begin with.
The motivation for the Ordering Bot was KFC food ordeing bot video on youtube by Haptic. I have tried to imitate the same kind of interaction with the help of DialogFlow & Twilio API. Although I may switch to a cheaper alternative than twilio and also have plans to export the dialogflow bot to RASA, which is an opensource framework.

##Methodologies Applied
<b>CQRS</b>
<b>Domain Driven Design</b>

## Tech/framework used
<b>Built with</b>
- [Asp.net core 3.1](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-3.1)
- [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-2019) as the SQL database for write operations. Will be replaced with [PostgreSQL](https://www.postgresql.org/).
- [MongoDB](https://www.mongodb.com/) as document database for read operations.
- [HangFire](https://www.hangfire.io/)
- [Mediatr](https://github.com/jbogard/MediatR/wiki)
- [Swagger/OpenAPI](https://swagger.io/)
- [EntityFrameworkCore](https://docs.microsoft.com/en-us/ef/core/)
- [Dapper](https://github.com/StackExchange/Dapper)
- [MongoDb C# Driver](https://docs.mongodb.com/drivers/csharp)
- [Minio as image storage server](https://min.io/)
- [Google Cloud DialogFlow](https://dialogflow.com/)
