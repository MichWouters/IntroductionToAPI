namespace MyFirstApi
{
    public class Photo
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public bool IsProfilePicture { get; set; }

        // Foreign Key
        public int AppUserId { get; set; }

        // Many to one
        public AppUser User { get; set; }
    }
}