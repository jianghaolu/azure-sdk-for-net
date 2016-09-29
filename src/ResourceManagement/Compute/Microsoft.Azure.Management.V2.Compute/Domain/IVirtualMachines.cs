// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition;
    /// <summary>
    /// Entry point to virtual machine management API.
    /// </summary>
    public interface IVirtualMachines :
        ISupportsListing<Microsoft.Azure.Management.V2.Compute.IVirtualMachine>,
        ISupportsListingByGroup<Microsoft.Azure.Management.V2.Compute.IVirtualMachine>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.V2.Compute.IVirtualMachine>,
        ISupportsGettingById<Microsoft.Azure.Management.V2.Compute.IVirtualMachine>,
        ISupportsCreating<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IBlank>,
        ISupportsDeleting,
        ISupportsDeletingByGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.V2.Compute.IVirtualMachine>
    {
        /// <returns>available virtual machine sizes</returns>
        IVirtualMachineSizes Sizes();

        /// <summary>
        /// Shuts down the virtual machine and releases the compute resources.
        /// </summary>
        /// <param name="groupName">groupName the name of the resource group the virtual machine is in</param>
        /// <param name="name">name the virtual machine name</param>
        void Deallocate(string groupName, string name);

        /// <summary>
        /// Generalize the virtual machine.
        /// </summary>
        /// <param name="groupName">groupName the name of the resource group the virtual machine is in</param>
        /// <param name="name">name the virtual machine name</param>
        void Generalize(string groupName, string name);

        /// <summary>
        /// Power off (stop) a virtual machine.
        /// </summary>
        /// <param name="groupName">groupName the name of the resource group the virtual machine is in</param>
        /// <param name="name">name the virtual machine name</param>
        void PowerOff(string groupName, string name);

        /// <summary>
        /// Restart a virtual machine.
        /// </summary>
        /// <param name="groupName">groupName the name of the resource group the virtual machine is in</param>
        /// <param name="name">name the virtual machine name</param>
        void Restart(string groupName, string name);

        /// <summary>
        /// Start a virtual machine.
        /// </summary>
        /// <param name="groupName">groupName the name of the resource group the virtual machine is in</param>
        /// <param name="name">name the virtual machine name</param>
        void Start(string groupName, string name);

        /// <summary>
        /// Redeploy a virtual machine.
        /// </summary>
        /// <param name="groupName">groupName the name of the resource group the virtual machine is in</param>
        /// <param name="name">name the virtual machine name</param>
        void Redeploy(string groupName, string name);

        /// <summary>
        /// Captures the virtual machine by copying virtual hard disks of the VM and returns template as json
        /// string that can be used to create similar VMs.
        /// </summary>
        /// <param name="groupName">groupName the resource group name</param>
        /// <param name="name">name the virtual machine name</param>
        /// <param name="containerName">containerName destination container name to store the captured VHD</param>
        /// <param name="overwriteVhd">overwriteVhd whether to overwrites destination VHD if it exists</param>
        /// <returns>the template as JSON string</returns>
        string Capture(string groupName, string name, string containerName, bool overwriteVhd);

    }
}