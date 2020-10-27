# SymtechWebApi
Symtech WebApi Code Refactoring

Name: SymtechBankApi

** Modifications Done **
1. Renamed Solution & Project to a standard name (*imaginary bank)
2. Standardized namespace, class, method, variable names
3. Used Entity Framework instead of ADO.Net for quicker development, clean and maintainable code
4. Added EF migration
5. Included Unit Test Project
6. Changed data types of properties
7. Included model validation
8. Changed connection string from class to configuration file (web.config)
9. Added UI (for implementing documentation and interface using Swagger/Swashbuckle or similar approach)
10. Included try-catch to manage exception
11. Included response messages for feedback

** Future Improvements **
1. Implement swagger (Swashbuckle) for documentation and to provide a UI for providing more information about API
2. Api should set maximum response per call and need to be documented
3. Allow multiple accounts, transactions per call
4. Handle multiple accounts, transactions per call in a way that any error to a specific account or transaction should not impact others if they are not directly related.
5. Standardize error message and centralize the error messages to a resource file or similar.
6. Provide more detailed error message with a unique key for identifying the errors easily based on the unique key than just the message
7. Log the detailed exceptions/error in the log file/database/text file
8. Implement unit test with full code coverage
9. Implement proper versioning of API


** Assumptions **
1. Updated the "Name" field as required to avoid accounts without valid names get saved
2. In the real scenario, account number logic needs to be implemented (auto-generated)
