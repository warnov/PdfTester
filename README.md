# PdfTester
A super simple sample of an Azure Function generating PDFs from HTML and storing it in the Azure Blob Storage.

This Azure Function uses [IronPdf.core](https://ironpdf.com/) nuget package to work.

IronPDF raises a whole Chromium execution environment that requires more disk space than the one provided by the *Consumption Tier* of Azure Functions, so you have to deploy it on a *Premium or 
<!--stackedit_data:
eyJoaXN0b3J5IjpbMTg3NjkyNzExN119
-->