namespace TicketAlarm.API
{
    public static class ApiRoutes
    {
        public const string Base = "~/api/";

        public const string ArtistBaseUrl = Base + "artists/";
        public const string CreateArtist = ArtistBaseUrl;
        public const string GetArtists = ArtistBaseUrl;

        public const string ShowBaseUrl = Base + "shows/";
        public const string UpdateShow = ShowBaseUrl + "{idShow}";
        public const string GetShow = ShowBaseUrl + "{idShow}";
        public const string GetShows = ShowBaseUrl;
        public const string CreateShow = ShowBaseUrl;

        public const string AlarmBaseUrl = Base + "alarms/";
        public const string UpdateAlarm = AlarmBaseUrl + "{idAlarm}";
        public const string GetAlarms = AlarmBaseUrl + "{idShow}";
        public const string CreateAlarm = AlarmBaseUrl;

        public const string AvailabilityBaseUrl = Base + "availabilitys/";
        public const string CreateAvailability = AvailabilityBaseUrl;

        public const string EmailBaseUrl = Base + "email/";
        public const string SendEmail = EmailBaseUrl;

        public const string UserBaseUrl = Base + "users/";
        public const string Authenticate = "authenticate";
    }
}
