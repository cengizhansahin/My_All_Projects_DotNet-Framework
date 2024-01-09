namespace MeetingApp.Models
{
    public static class Repository
    {
        static Repository()
        {
            Applies.Add(new ApplyInfo()
            {
                Id = 1,
                Name = "Erkin",
                Email = "et@gmail.com",
                Phone = "9546245",
                WillAttend = true,
            });
            Applies.Add(new ApplyInfo()
            {
                Id = 2,
                Name = "Aylin",
                Email = "ae@gmail.com",
                Phone = "954asd6245",
                WillAttend = false,
            });
            Applies.Add(new ApplyInfo()
            {
                Id = 3,
                Name = "Ronmoon",
                Email = "raa@gmail.com",
                Phone = "923245",
                WillAttend = true,
            });
        }
        public static List<ApplyInfo> Applies { get; set; } = new List<ApplyInfo>();
        public static void CreateUser(ApplyInfo user)
        {
            user.Id = Applies.Count + 1;
            Applies.Add(user);
        }
        public static ApplyInfo? GetById(int id)
        {
            return Applies.FirstOrDefault(u => u.Id == id);
        }
    };
}
