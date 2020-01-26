﻿using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters;
using Okex.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Okex.Net.RestObjects.Spot
{
    public class OrderBook
    {
        [JsonProperty("instrument_id"), JsonOptionalProperty]
        public string Symbol { get; set; } = "";

        [JsonProperty("checksum"), JsonOptionalProperty]
        public long Checksum { get; set; }

        [JsonOptionalProperty, JsonConverter(typeof(SpotOrderBookDataTypeConverter))]
        public SpotOrderBookDataType DataType { get; set; } = SpotOrderBookDataType.Api;

        /// <summary>
        /// Selling side
        /// </summary>
        [JsonProperty("asks")]
        public IEnumerable<OrderBookEntry> Asks { get; set; } = new List<OrderBookEntry>();

        /// <summary>
        /// Buying side
        /// </summary>
        [JsonProperty("bids")]
        public IEnumerable<OrderBookEntry> Bids { get; set; } = new List<OrderBookEntry>();

        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
    }

    [JsonConverter(typeof(ArrayConverter))]
    public class OrderBookEntry
    {
        /// <summary>
        /// The price for this entry
        /// </summary>
        [ArrayProperty(0)]
        public decimal Price { get; set; }

        /// <summary>
        /// The quantity for this entry
        /// </summary>
        [ArrayProperty(1)]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Number of orders at the price
        /// </summary>
        [ArrayProperty(2)]
        public decimal OrdersCount { get; set; }
    }
}
