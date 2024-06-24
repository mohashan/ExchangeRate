------------------------------Requirement---------------------------------------
* Endpoint to get a list of available financial instruments. >> done
** https://localhost:7137/api/Exchangerate

* Endpoint to get the current price of a specific financial instrument. >> done
** https://localhost:7137/api/Exchangerate/EURUSD

* Subscribe to live price updates for a specific financial instrument(s) from the list above. >> done
** https://localhost:7137/rateHub::newRate

* Broadcast price updates to all subscribed clients. >> done
** https://localhost:7137/rateHub::ReceiveAsync

* Use a public API like Alpha Vantage or CEX.io to fetch live price data >> done
** Placed in appsettings

* Efficiently manage 1,000+ WebSocket subscribers with a single connection to the data provider. >> done

* implement event and error logging capabilities. >> done
** By injecting ILogger you can log any data everywhere


----------------------------Optional features --------------------------------------
* Using CQRS in order to reduce dependency injection, and make modules testable and easy to maintain
** using MediatR

* Using Temporal table make it  possible to keep trace of changes
** EF-core and sql server built-in functionality

* Implement project base on clean architecture
** Thank to Milan Jovanovic

* Using Sql-Server as database
** By using EF-core

---------------------------Have to do in the future----------------------------------
* Implementing unit test

* Refactoring code and make it cleaner

* Implementing Authentication and Authorization
