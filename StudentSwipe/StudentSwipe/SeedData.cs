// Data/SchoolDomainSeeder.cs
using StudentSwipe.Models;

public static class SchoolDomainSeeder
{ 
    public static List<SchoolDomain> GetPredefinedDomains()
    {
        return new List<SchoolDomain>
        {
            new SchoolDomain { Domain = ".uwinnipeg.ca", SchoolName = "University of Winnipeg" },
            new SchoolDomain { Domain = "umanitoba.ca", SchoolName = "University of Manitoba" },
            new SchoolDomain { Domain = "live.wsd1.org", SchoolName = "Winnipeg School Division" },
            new SchoolDomain { Domain = "lrsd.net", SchoolName = "Louis Riel School Division" },
            new SchoolDomain { Domain = "smail.pembinatrails.ca", SchoolName = "Pembina Trails School Division" },
            new SchoolDomain { Domain = "7oaks.org", SchoolName = "Seven Oaks School Division" },
            new SchoolDomain { Domain = "sjsd.net", SchoolName = "St. James-Assiniboia School Division" },
            new SchoolDomain { Domain = "retsd.mb.ca", SchoolName = "River East Transcona School Division" },
            new SchoolDomain { Domain = "student.mitt.ca", SchoolName = "Manitoba Institute of Trades and Technology" },
            new SchoolDomain { Domain = "academic.rrc.ca", SchoolName = "Red River College of Applied Arts, Science & Technology" },
            new SchoolDomain { Domain = "assiniboine.net. ", SchoolName = "Assiniboine Community College" },
            new SchoolDomain { Domain = "learning.icmanitoba.ca", SchoolName = "International College of Manitoba" },
            new SchoolDomain { Domain = "cmu.ca", SchoolName = "Canadian Mennonite University" },

        };

    }
}
