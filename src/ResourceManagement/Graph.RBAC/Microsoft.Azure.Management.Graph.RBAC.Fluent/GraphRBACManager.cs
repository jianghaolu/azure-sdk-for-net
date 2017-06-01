﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent;

namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    /// <summary>
    /// Entry point to Azure Graph RBAC management.
    /// </summary>
    public class GraphRbacManager : Manager<IGraphRbacManagementClient>, IGraphRbacManager, IBeta
    {
        #region Fluent private collections
        internal RestClient restClient;
        internal string tenantId;
        private IActiveDirectoryUsers users;
        private IActiveDirectoryGroups groups;
        private IActiveDirectoryApplications applications;
        private IServicePrincipals servicePrincipals;
        private IRoleDefinitions roleDefinitions;
        private IRoleAssignments roleAssignments;
        private IAuthorizationManagementClient roleInner;
        #endregion

        #region ctrs

        public GraphRbacManager(RestClient restClient, string subscriptionId, string tenantId) :
            base(restClient, subscriptionId, new GraphRbacManagementClient(new Uri(restClient.BaseUri),
                restClient.Credentials,
                restClient.RootHttpHandler,
                restClient.Handlers.ToArray())
            {
                TenantID = tenantId
            })
        {
            string resourceManagerUrl = AzureEnvironment.AzureGlobalCloud.ResourceManagerEndpoint;
            if (restClient.Credentials is AzureCredentials)
            {
                resourceManagerUrl = ((AzureCredentials)restClient.Credentials).Environment.ResourceManagerEndpoint;
            }
            roleInner = new AuthorizationManagementClient(new Uri(resourceManagerUrl),
                restClient.Credentials,
                restClient.RootHttpHandler,
                restClient.Handlers.ToArray());
            this.tenantId = tenantId;
        }

        #endregion

        #region Graph RBAC Manager builder

        public static IGraphRbacManager Authenticate(AzureCredentials credentials, string subscriptionId, string tenantId)
        {
            return new GraphRbacManager(RestClient.Configure()
                    .WithBaseUri(credentials.Environment.GraphEndpoint)
                    .WithCredentials(credentials)
                    .WithDelegatingHandler(new ProviderRegistrationDelegatingHandler(credentials))
                    .Build(), subscriptionId, tenantId);
        }

        public static IGraphRbacManager Authenticate(RestClient restClient, string subscriptionId, string tenantId)
        {
            return new GraphRbacManager(restClient, subscriptionId, tenantId);
        }

        public static IConfigurable Configure()
        {
            return new Configurable();
        }

        #endregion


        #region IConfigurable and it's implementation

        public interface IConfigurable : IAzureConfigurable<IConfigurable>
        {
            IGraphRbacManager Authenticate(AzureCredentials credentials, string subscriptionId, string tenantId);
        }

        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            public IGraphRbacManager Authenticate(AzureCredentials credentials, string subscriptionId, string tenantId)
            {
                return new GraphRbacManager(BuildRestClientForGraph(credentials), subscriptionId, tenantId);
            }
        }

        #endregion

        #region IGraphRbacManager implementation 

        public IAuthorizationManagementClient RoleInner
        {
            get
            {
                return roleInner;
            }
        }

        public IActiveDirectoryUsers Users
        {
            get
            {
                if (users == null)
                {
                    users = new ActiveDirectoryUsersImpl(this);
                }

                return users;
            }
        }

        public IActiveDirectoryGroups Groups
        {
            get
            {
                if (groups == null)
                {
                    groups = new ActiveDirectoryGroupsImpl(this);
                }

                return groups;
            }
        }

        public IActiveDirectoryApplications Applications
        {
            get
            {
                if (applications == null)
                {
                    applications = new ActiveDirectoryApplicationsImpl(this);
                }

                return applications;
            }
        }

        public IServicePrincipals ServicePrincipals
        {
            get
            {
                if (servicePrincipals == null)
                {
                    servicePrincipals = new ServicePrincipalsImpl(this);
                }
                return servicePrincipals;
            }
        }

        public IRoleDefinitions RoleDefinitions
        {
            get
            {
                if (roleDefinitions == null)
                {
                    roleDefinitions = new RoleDefinitionsImpl(this);
                }
                return roleDefinitions;
            }
        }

        public IRoleAssignments RoleAssignments
        {
            get
            {
                if (roleAssignments == null)
                {
                    roleAssignments = new RoleAssignmentsImpl(this);
                }
                return roleAssignments;
            }
        }
        #endregion
    }

    public interface IGraphRbacManager : IManager<IGraphRbacManagementClient>
    {
        IAuthorizationManagementClient RoleInner { get; }
        IActiveDirectoryUsers Users { get; }
        IActiveDirectoryGroups Groups { get; }
        IActiveDirectoryApplications Applications { get; }
        IServicePrincipals ServicePrincipals { get; }
        IRoleDefinitions RoleDefinitions { get; }
        IRoleAssignments RoleAssignments { get; }
    }
}