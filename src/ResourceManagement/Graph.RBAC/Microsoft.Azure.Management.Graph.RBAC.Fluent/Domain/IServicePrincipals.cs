// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Entry point to service principal management API.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
    /// future releases, including removal, regardless of any compatibility expectations set by the containing library
    /// version number.).
    /// </remarks>
    public interface IServicePrincipals  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByName<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<ServicePrincipal.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Graph.RBAC.Fluent.GraphRbacManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipalsOperations>
    {
    }
}