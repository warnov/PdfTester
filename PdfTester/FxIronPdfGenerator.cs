using System;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace PdfTester
{
    public static class FxIronPdfGenerator
    {
        [FunctionName("FxIronPdfGenerator")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req)
        {

                string cloudStorageAccountConnectionString = Environment.GetEnvironmentVariable("AzureStorageConnectionString");



                BlobContainerClient container = new BlobContainerClient(cloudStorageAccountConnectionString, "pdftest");
                var blobClient = container.GetBlobClient("ebill3.pdf");








              
                var html = @$"
<html>
<!-- Text between angle brackets is an HTML tag and is not displayed.
Most tags, such as the HTML and /HTML tags that surround the contents of
a page, come in pairs; some tags, like HR, for a horizontal rule, stand 
alone. Comments, such as the text you're reading, are not displayed when
the Web page is shown. The information between the HEAD and /HEAD tags is 
not displayed. The information between the BODY and /BODY tags is displayed.-->
<head>
<title>FACTURA ELECTRONICA</title>
</head>
<!-- The information between the BODY and /BODY tags is displayed.-->
<body>
<h1>FACTURA ELECTRONICA from {Environment.GetEnvironmentVariable("Environment")}</h1>
<p>Be <b>bold</b> in stating your key points. Put them in a list: </p>
<ul>
<li>The first item in your list</li>
<li>The second item; <i>italicize</i> key words</li>
</ul>
<p>Improve your image by including an image. </p>
<p><img src=http://aljadco.com/wp-content/uploads/2017/09/e-billing-apps-300x225.jpg alt='A Great HTML Resource'></p>
<p>Add a link to your favorite <a href=https://www.dummies.com/>Web site</a>.
Break up your page with a horizontal rule or two. </p>
<hr>
<p>Finally, link to <a href=page2.html>another page</a> in your own Web site.</p>
<!-- And add a copyright notice.-->
<p>&#169; Wiley Publishing, 2011</p>
</body>
</html>";





                var renderer = new IronPdf.HtmlToPdf();
                renderer.PrintOptions.CreatePdfFormsFromHtml = true;
                var pdfBytes = renderer.RenderHtmlAsPdf(html).Stream;


                blobClient.Upload(pdfBytes, overwrite: true);


                return new OkResult();
                        


        }
    }
}
