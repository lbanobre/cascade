using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cascade.Api.Entities
{
    public class Citation
    {
        public string AuthorLastName { get; set; }
        public string AuthorFirstName { get; set; }
        public string Title { get; set; }
        public string TitleOfContainer { get; set; }
        public string Publisher { get; set; }
        public string PublicationDate { get; set; }
        public string PageNumbers { get; set; }
        public string VolumeNo { get; set; }
        public string Url { get; set; }
    }
}
