﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Alpaca.Markets
{
    [SuppressMessage(
        "Microsoft.Performance", "CA1812:Avoid uninstantiated internal classes",
        Justification = "Object instances of this class will be created by Newtonsoft.JSON library.")]
    internal sealed class JsonAccountUpdate : IAccountUpdate
    {
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid AccountId { get; set; }

        [JsonProperty(PropertyName = "status", Required = Required.Always)]
        public AccountStatus Status { get; set; }

        [JsonProperty(PropertyName = "currency", Required = Required.Default)]
        public String? Currency { get; set; }

        [JsonProperty(PropertyName = "cash", Required = Required.Always)]
        public Decimal TradableCash { get; set; }

        [JsonProperty(PropertyName = "cash_withdrawable", Required = Required.Default)]
        public Decimal WithdrawableCash { get; set; }

        [JsonIgnore] 
        public DateTime CreatedAt => CreatedAtUtc;

        [JsonIgnore] 
        public DateTime UpdatedAt => UpdatedAtUtc;

        [JsonIgnore] 
        public DateTime? DeletedAt => DeletedAtUtc;

        [JsonProperty(PropertyName = "created_at", Required = Required.Always)]
        [JsonConverter(typeof(AssumeUtcIsoDateTimeConverter))]
        public DateTime CreatedAtUtc { get; set; }

        [JsonProperty(PropertyName = "updated_at", Required = Required.Always)]
        [JsonConverter(typeof(AssumeUtcIsoDateTimeConverter))]
        public DateTime UpdatedAtUtc { get; set; }

        [JsonProperty(PropertyName = "deleted_at", Required = Required.AllowNull)]
        [JsonConverter(typeof(AssumeUtcIsoDateTimeConverter))]
        public DateTime? DeletedAtUtc { get; set; }

        [OnDeserialized]
        internal void OnDeserializedMethod(
            StreamingContext context)
        {
            if (String.IsNullOrEmpty(Currency))
            {
                Currency = "USD";
            }
        }
    }
}
