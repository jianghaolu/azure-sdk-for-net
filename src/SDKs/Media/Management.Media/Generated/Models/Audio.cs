// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Media.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Defines the common properties for all audio codecs.
    /// </summary>
    [Newtonsoft.Json.JsonObject("#Microsoft.Media.Audio")]
    public partial class Audio : Codec
    {
        /// <summary>
        /// Initializes a new instance of the Audio class.
        /// </summary>
        public Audio()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Audio class.
        /// </summary>
        /// <param name="label">An optional label for the codec. The label can
        /// be used to control muxing behavior.</param>
        /// <param name="channels">The number of channels in the audio.</param>
        /// <param name="samplingRate">The sampling rate to use for encoding in
        /// hertz.</param>
        /// <param name="bitrate">The bitrate, in bits per second, of the
        /// output encoded audio.</param>
        public Audio(string label = default(string), int? channels = default(int?), int? samplingRate = default(int?), int? bitrate = default(int?))
            : base(label)
        {
            Channels = channels;
            SamplingRate = samplingRate;
            Bitrate = bitrate;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the number of channels in the audio.
        /// </summary>
        [JsonProperty(PropertyName = "channels")]
        public int? Channels { get; set; }

        /// <summary>
        /// Gets or sets the sampling rate to use for encoding in hertz.
        /// </summary>
        [JsonProperty(PropertyName = "samplingRate")]
        public int? SamplingRate { get; set; }

        /// <summary>
        /// Gets or sets the bitrate, in bits per second, of the output encoded
        /// audio.
        /// </summary>
        [JsonProperty(PropertyName = "bitrate")]
        public int? Bitrate { get; set; }

    }
}