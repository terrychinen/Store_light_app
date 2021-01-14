using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Domain.Models
{
    public class Token
    {
        private int tokenId;
        private string tokenKey;
        private DateTime createdAt;
        private int expiresIn;
        private int state;

        [JsonProperty("token_id")]
        public int TokenId { get => tokenId; set => tokenId = value; }
        [JsonProperty("token")]
        public string TokenKey { get => tokenKey; set => tokenKey = value; }
        [JsonProperty("date")]
        public DateTime CreatedAt { get => createdAt; set => createdAt = value; }
        [JsonProperty("expires_in")]
        public int ExpiresIn { get => expiresIn; set => expiresIn = value; }
        public int State { get => state; set => state = value; }
    }
}
