namespace CapPlacement.Models
{
    // Profile represents a class that holds information about an applicant's profile.
    public class Profile
    {
        public EducationProfile EducationProfile { get; set; }

        public ProfessionalProfile ProfessionalProfile { get; set; }

        public Resume Resume { get; set; }
    }
}
