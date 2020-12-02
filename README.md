# PdfTester
Super simple samples of Azure Functions generating PDFs from  and storing them in the Azure Blob Storage.

### 1. FxIronPdfGenerator

This Azure Function uses [IronPdf.core](https://ironpdf.com/) nuget package to work.

IronPDF raises a whole Chromium execution environment that requires more disk space than the one provided by the *Consumption Tier* of Azure Functions, so you have to deploy it on a *Premium or Dedicated* tier.
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTU2NDM1MDkyMSwxOTUxMzIyMjQ2XX0=
-->