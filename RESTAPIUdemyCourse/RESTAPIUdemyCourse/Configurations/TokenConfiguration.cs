namespace RESTAPIUdemyCourse.Configurations
{
    public class tokenConfiguration
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string Secret { get; set; }
        public int Minutes { get; set; }
        public int DaysToBeExpired { get; set; }
    }
}
