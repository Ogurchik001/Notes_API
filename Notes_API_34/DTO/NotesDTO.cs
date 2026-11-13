using System.Text.Json.Serialization;

namespace Notes_API_34.DTO
{
    public class NotesDTO
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
        [JsonPropertyName("title_user")]
        public string TitleUser { get; set; } = string.Empty;
        [JsonPropertyName("content")]
        public string Content {  get; set; } = string.Empty;
        [JsonPropertyName("formatted_date")]
        public string FormattedDate {  get; set; } = string.Empty;
    }
}
