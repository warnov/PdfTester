# PdfTester
Super simple samples of Azure Functions generating PDFs from  and storing them in the Azure Blob Storage.

### 1. FxIronPdfGenerator

This Azure Function uses [IronPdf.core](https://ironpdf.com/) nuget package to work. It can generate a PDF from an HTML so there is not programming required to assemble the PDF.

Nevertheless, IronPDF raises a whole Chromium execution environment that requires more disk space than the one provided by the *Consumption Tier* of Azure Functions, so you have to deploy it on a *Premium or Dedicated* tier.

The minimal rendering took 2 secs. And the first run takes 25secs. I suppose it is because the Chromium setup required.

### 2. FxPdfSharpGenerator
Uses [PdfSharpCore](https://www.nuget.org/packages/PdfSharpCore/). This package is blazing fast compared against IronPDF. Minimal rendering took 123ms and the penalty for the first execution is unnoticeable. But, and it is a big but, you have to "program" your PDF so this could require a lot of developing extra time.
Another big advantage though, is that it can run smoothly in the *Consumption Tier* of Azure Functions.

<!--stackedit_data:
eyJoaXN0b3J5IjpbMTgwMzIzNDAzMSwxOTUxMzIyMjQ2XX0=
-->