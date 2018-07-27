using Microsoft.Azure.Documents.Client;
using PSHelloAzureWebApp.Models.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSHelloAzureWebApp.Services
{
    public class CourseStore
    {
        private DocumentClient documentClient;
        private Uri coursesLink;

        public CourseStore()
        {
            var uri = new Uri("https://scaryworks.documents.azure.com:443/");
            var accountKey = "nZ8QolIeRI33T7QbAu6hiNUKCEEAhDoJpDRxPZOhouRF0aPHOKwLTN7LbQKHO1M3mXjiHESCRHlKQrBCDl6BrQ==";
            documentClient = new DocumentClient(uri, accountKey);
            coursesLink = UriFactory.CreateDocumentCollectionUri("pshelloazure", "courses");
        }

        public async Task InsertCourses(IEnumerable<Course> courses)
        {
            foreach (var course in courses)
            {
                await documentClient.CreateDocumentAsync(coursesLink, course);
            }
        }

        public IEnumerable<Course> GetAllCourses()
        {
            var courses = documentClient.CreateDocumentQuery<Course>(coursesLink).OrderBy(c => c.Title);
            return courses;
        }
    }
}
