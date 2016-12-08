// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Appservice.Fluent.AppServiceCertificateOrder.Definition
{
    using Microsoft.Azure.Management.Appservice.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Resource.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.KeyVault.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefinition  :
        IBlank,
        IWithHostName,
        IWithCertificateSku,
        IWithDomainVerificationFromWebApp,
        IWithKeyVault,
        IWithCreate
    {
    }

    /// <summary>
    /// An app service certificate order definition allowing hostname to be set.
    /// </summary>
    public interface IWithHostName 
    {
        /// <summary>
        /// Specifies the hostname the certificate binds to.
        /// </summary>
        /// <param name="hostName">The bare host name, without "www". Use *. prefix if it's a wild card certificate.</param>
        Microsoft.Azure.Management.Appservice.Fluent.AppServiceCertificateOrder.Definition.IWithCertificateSku WithHostName(string hostName);
    }

    /// <summary>
    /// An app service certificate order definition with sufficient inputs to create a new
    /// app service certificate order in the cloud, but exposing additional optional inputs to
    /// specify.
    /// </summary>
    public interface IWithCreate  :
        ICreatable<Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateOrder>,
        IWithValidYears,
        IWithAutoRenew,
        IDefinitionWithTags<Microsoft.Azure.Management.Appservice.Fluent.AppServiceCertificateOrder.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// An app service certificate order definition allowing resource group to be set.
    /// </summary>
    public interface IBlank  :
        IWithGroup<Microsoft.Azure.Management.Appservice.Fluent.AppServiceCertificateOrder.Definition.IWithHostName>
    {
    }

    /// <summary>
    /// An app service certificate order definition allowing valid years to be set.
    /// </summary>
    public interface IWithValidYears 
    {
        /// <summary>
        /// Specifies the valid years of the certificate.
        /// </summary>
        /// <param name="years">Minimum 1 year, and maximum 3 years.</param>
        Microsoft.Azure.Management.Appservice.Fluent.AppServiceCertificateOrder.Definition.IWithCreate WithValidYears(int years);
    }

    /// <summary>
    /// An app service certificate order definition allowing SKU to be set.
    /// </summary>
    public interface IWithCertificateSku 
    {
        /// <summary>
        /// Specifies the SKU of the certificate to be wildcard. It will provide
        /// SSL support to any sub-domain under the hostname.
        /// </summary>
        Microsoft.Azure.Management.Appservice.Fluent.AppServiceCertificateOrder.Definition.IWithDomainVerification WithWildcardSku();

        /// <summary>
        /// Specifies the SKU of the certificate to be standard. It will only provide
        /// SSL support to the hostname, and www.hostname. Wildcard type will provide
        /// SSL support to any sub-domain under the hostname.
        /// </summary>
        Microsoft.Azure.Management.Appservice.Fluent.AppServiceCertificateOrder.Definition.IWithDomainVerificationFromWebApp WithStandardSku();
    }

    /// <summary>
    /// An app service certificate order definition allowing auto-renew settings to be set.
    /// </summary>
    public interface IWithAutoRenew 
    {
        /// <summary>
        /// Specifies if the certificate should be auto-renewed.
        /// </summary>
        /// <param name="enabled">True if the certificate order should be auto-renewed.</param>
        Microsoft.Azure.Management.Appservice.Fluent.AppServiceCertificateOrder.Definition.IWithCreate WithAutoRenew(bool enabled);
    }

    /// <summary>
    /// An app service certificate order definition allowing domain verification method to be set.
    /// </summary>
    public interface IWithDomainVerification 
    {
        /// <summary>
        /// Specifies the Azure managed domain to verify the ownership of the domain.
        /// </summary>
        /// <param name="domain">The Azure managed domain.</param>
        Microsoft.Azure.Management.Appservice.Fluent.AppServiceCertificateOrder.Definition.IWithKeyVault WithDomainVerification(IAppServiceDomain domain);
    }

    /// <summary>
    /// An app service certificate order definition allowing more domain verification methods to be set.
    /// </summary>
    public interface IWithKeyVault 
    {
        /// <summary>
        /// Creates a new key vault to store the certificate private key.
        /// 
        /// DO NOT use this method if you are logged in from an identity without access
        /// to the Active Directory Graph.
        /// </summary>
        /// <param name="vaultName">The name of the new key vault.</param>
        /// <param name="region">The region to create the vault.</param>
        Microsoft.Azure.Management.Appservice.Fluent.AppServiceCertificateOrder.Definition.IWithCreate WithNewKeyVault(string vaultName, Region region);

        /// <summary>
        /// Specifies an existing key vault to store the certificate private key.
        /// 
        /// The vault MUST allow 2 service principals to read/write secrets:
        /// f3c21649-0979-4721-ac85-b0216b2cf413 and abfa0a7c-a6b6-4736-8310-5855508787cd.
        /// If they don't have access, an attempt will be made to grant access. If you are
        /// logged in from an identity without access to the Active Directory Graph, this
        /// attempt will fail.
        /// </summary>
        /// <param name="vault">The vault to store the private key.</param>
        Microsoft.Azure.Management.Appservice.Fluent.AppServiceCertificateOrder.Definition.IWithCreate WithExistingKeyVault(IVault vault);
    }

    /// <summary>
    /// An app service certificate order definition allowing more domain verification methods to be set.
    /// </summary>
    public interface IWithDomainVerificationFromWebApp  :
        IWithDomainVerification
    {
        /// <summary>
        /// Specifies the web app to verify the ownership of the domain. The web app needs to
        /// be bound to the hostname for the certificate.
        /// </summary>
        /// <param name="webApp">The web app bound to the hostname.</param>
        Microsoft.Azure.Management.Appservice.Fluent.AppServiceCertificateOrder.Definition.IWithKeyVault WithWebAppVerification(IWebAppBase<object> webApp);
    }
}