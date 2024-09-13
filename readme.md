## Documents search Web API

The web application is written in ASP.NET just for demo purposes.
The goal is to scan configured folder for txt files, add them into the DB, then search for the files, names of which contains the string as provided in query.

## Suggestions \ plans to improve:
- Auth skipped as not mentioned in the requirements

- Monolithic architecture (with more then one project in the solution) decide because of lack of the time

- Currently the web API will scan file's folder on each call which isn't efficient, it may be improved by various optimizations (need to know better how the API will be used, how often files will be changed, will we have permission to subscribe to changes in file system and so on). Some of the ways - add hangfire or similar scheduler to refresh the data or add cache\lifetime date or separate endpoint to trigger update process.

nice to add:
global exception handler with logging
unit tests
configuration instead of constants
better documentation (Swagger doc, better readme)
