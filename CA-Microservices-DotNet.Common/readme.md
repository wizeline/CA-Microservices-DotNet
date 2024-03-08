
## Common project

It acts as a central repository for code that's used by multiple parts of the application, but doesn't belong to any specific layer (Domain, Application, Presentation, Infrastructure).
This can include:

**Utility classes:** Helper functions or Extensio methods for common tasks like string manipulation, date/time handling, or userId retrival, etc..

**Enumeration classes:** Defining constants or predefined options used across the application.
Interfaces: Interfaces that define contracts used by multiple layers. These interfaces promote loose coupling and testability.

**Models/DTO:** Are those clases that are used to encapsulate the entities and its logic from outsider layers or consumers and clients. 