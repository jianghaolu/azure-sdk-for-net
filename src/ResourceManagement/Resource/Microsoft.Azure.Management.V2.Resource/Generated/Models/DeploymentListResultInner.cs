// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.ResourceManager.Models
{
    using System.Linq;

    /// <summary>
    /// List of deployments.
    /// </summary>
    public partial class DeploymentListResultInner
    {
        /// <summary>
        /// Initializes a new instance of the DeploymentListResultInner class.
        /// </summary>
        public DeploymentListResultInner() { }

        /// <summary>
        /// Initializes a new instance of the DeploymentListResultInner class.
        /// </summary>
        /// <param name="value">The list of deployments.</param>
        /// <param name="nextLink">The URL to get the next set of
        /// results.</param>
        public DeploymentListResultInner(System.Collections.Generic.IList<DeploymentExtendedInner> value = default(System.Collections.Generic.IList<DeploymentExtendedInner>), string nextLink = default(string))
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary>
        /// Gets or sets the list of deployments.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "value")]
        public System.Collections.Generic.IList<DeploymentExtendedInner> Value { get; set; }

        /// <summary>
        /// Gets or sets the URL to get the next set of results.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "nextLink")]
        public string NextLink { get; set; }

    }
}
