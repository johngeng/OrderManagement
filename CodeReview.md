# Solution Structure

 - Classes should be logically group together, group into folders will be easier to maintenance

# Issues of Shape

 - Lack of interfaces
 - Too much responsibilities for shape and sub classes
	 - Move out **AdditionalCharge**,**NumberOfxxx** ,**TotalQuantityOfShape()**,**AdditionalChargeTotal()** of shape to make it easy to increase flexibility and easy to extend.
	 - Can simplify constructors of  Subclasses of **Shape** (**Circle**, **Square**, **Triangle**) to use **:base("xxx", price, type)**
	 - Move out duplicate functions that should not be responsible from shape to **Order** class
# Issues of Order
 - **Order** should be  responsible of collect order data, should not be responsible for generate report. So **CuttingListReport**, **InvoiceReport** and **PaintingReport** should not be extend from **Order**, better to create new class e.g. **OrderReport** to perform generate report function.
 - Move out **CustomerName**, **Address**  to new class Customer for better extensibility.
 - **DueDate** should be **DateTime** format
 - **OrderNumber** better use **long** instead of **int** for improving scale capacity.
 - Move **AdditionalCharges** from **Shape** to **Order** here as it is order specific.
 - Suggest add some logical functions e.g. **AddShape**, **AddShapes**, **GetTotalNumberOfShape**, **GetTotalPrice** which belong to order
 - In **CuttingListReport**, **InvoiceReport** and **PaintingReport** have many similar functions which can be refactor make to reusable, suggest to move new class e.g. **Utility** class.
 - Some method names are not following MS guideline **PascalCase** and also naming conversion not good to understand as function.
 - Suggest create interface **IOrderReportService** to implement **GenerateReport** function
 - Suggest create new abstract class **OrderReport** and implement interface **IOrderReportService** , Make **GenerateReport** function extendable and two functions **GenerateReportHeader** and **GenerateTable** abstract as per unique requirement of each report.
 - Suggest add new abstract property **DisplayerOrder** in **OrderReport** to make sort order of generate report can be flexible.
 - Suggest create some thin interfaces e.g. **ICuttingListingReport**, **IInvoiceReport**, **IPaintingReport** as increase flexibility and extendibility
 - The constructor of CuttingListReport, InvoiceReport and PaintingReport can be refactored to  **:base(order, TABLEWIDTH, shapes)**
 - **tableWidth**property  suggest to be constant and should be all capital case
 - A lot dependencies of hard code and concrete classes  **Shape** and **Color** in  **CuttingListReport**, **InvoiceReport** and **PaintingReport**, which can be refactored to use **Enum** and use **Enum,GetNames()** to make better flexibility
 - Use **Utility** class helper functions to print line and row to avoid duplicate code.
 - Use template string interpolation to make code tidy and easy to understand
 - The **GenerateReport** function of **InvoiceReport** have more requirements than others so need override base function **GenerateReport** with add new function **GenerateInvoiceReport** (implement interface **IInvoiceReport**)
 - **OrderSquareDetails**, **OrderTriangleDetails** and **OrderCircleDetails** functions can be combined into one function with **shapes** as passed in and a foreach loop to print out so that can avoid hard code, also naming should be like function e.g. **GenerateShapeOrderDetails**
 - **GenerateTable** function can be refactored use **Utility.PrintLine()**, **Utility.PrintRow()**, and foreach loop through **ShapeType** and **Color** enums so make the code more flexibility.

# Issues of Program

 - Functions should be better naming e.g. use **GetCustomerInfoInput()** instead of **CustomerInfoInput()**
 - Functions except **Main** should be private
 - Suggest add new function **SetupInitalValues** to setup initial values e.g. order number, shapes, additional charges.
 - **userInput** function should be rename to easy to identify as function like **GetUserInput** and also need handle with number and datetime format, so better split to some helper functions e.g. **GetUserInputString**, **GetUserInputDate**, **GetUserInputNumber** move to **Utility** Class.
 - **CustomerOrderInput()** function should only have single responsibility which is collect customer information Name and Address so should be rename to **GetCustomerInfoInput** and only return back **Customer** object. Move out order information to new function e.g. **GetCustomerOrderInput**
 - **CustomerOrderInput**  function can be refactored to with foreach loop over **shape** enum to make more flexible. 
 - In **Main** function can use reflection to loop through reports which implement interface **IOrderReportService** and call the the function of interface **GenerateReport** by the **DisplayOrder**, can avoid to hard code call **GenerateReport** of **InvoiceReport**, **CuttingListReport** and **PaintingReport** individually.
# Future improvements
 
 - It is possible to move some constant values e.g. price, tablewidth, additionalcharge, displayorder to configuration file e.g. application.setting so make program more flexible.

