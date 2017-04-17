// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Compute.Fluent.Disk.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;

    internal partial class DisksImpl 
    {
        /// <summary>
        /// Revoke access granted to a disk.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="diskName">The disk name.</param>
        void Microsoft.Azure.Management.Compute.Fluent.IDisks.RevokeAccess(string resourceGroupName, string diskName)
        {
 
            this.RevokeAccessAsync(resourceGroupName, diskName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Grants access to a disk.
        /// </summary>
        /// <param name="resourceGroupName">A resource group name.</param>
        /// <param name="diskName">A disk name.</param>
        /// <param name="accessLevel">Access level.</param>
        /// <param name="accessDuration">Access duration.</param>
        /// <return>The read-only SAS URI to the disk.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IDisks.GrantAccess(string resourceGroupName, string diskName, AccessLevel accessLevel, int accessDuration)
        {
            return this.GrantAccessAsync(resourceGroupName, diskName, accessLevel, accessDuration).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Begins a definition for a new resource.
        /// This is the beginning of the builder pattern used to create top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Creatable.create().
        /// Note that the  Creatable.create() method is
        /// only available at the stage of the resource definition that has the minimum set of input
        /// parameters specified. If you do not see  Creatable.create() among the available methods, it
        /// means you have not yet specified all the required input settings. Input settings generally begin
        /// with the word "with", for example: <code>.withNewResourceGroup()</code> and return the next stage
        /// of the resource definition, as an interface in the "fluent interface" style.
        /// </summary>
        /// <param name="name">The name of the new resource.</param>
        /// <return>The first stage of the new resource definition.</return>
        Disk.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<Disk.Definition.IBlank>.Define(string name)
        {
            return this.Define(name) as Disk.Definition.IBlank;
        }
    }
}