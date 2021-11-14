using Newtonsoft.Json;
public class User
{
    // [JsonProperty("UserId")]
    public int UserId { get; set; }
    // [JsonProperty("UserName")]
    public string UserName { get; set; }
    // [JsonProperty("CharacterName")]
    public string CharacterName { get; set; }
    // [JsonProperty("ClassId")]
    public int ClassId{ get; set; }
    // [JsonProperty("RoleID")]
    public int RoleID { get; set; }



               
}
