## jqgrid-excel-export-aspnetmvc-sample

This is a small sample how to export jqGrid data to an Excel file using ASP.NET MVC 3.

## Requirements to run

1. .NET Framework 4
2. ASP.NET MVC 3 RTM

## Future enhancements

1. Fix export to *.xlsx extension.
2. Remove form submission from the "Export to Excel" button and execute an AJAX call to server instead.
3. Send the grid data when clicking on "Export to Excel". The current version make two queries instead of one. First to load the grid and the second to write the excel content.
4. Create a custom ActionResult to encapsulate Http Response management.

## Code License

This sample source code is under the MIT license (check out more in http://www.opensource.org/licenses/MIT).