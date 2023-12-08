# UpdateInventoryMagento
Get inventory info from API endpoint and update inventory in Magento through their API.

This app connects to an API endpoint I created that connects to an oracle database using dapper and returns a list of items and their inventory numbers from our OmegaCube ERP system.  It then connects to a Magento GET inventory API. I loop through that list and compare the inventory numbers with the inventory numbers in OmegaCube. The inventory in Magento is then updated to match the source inventory coming from our ERP software by connecting to a Magento inventory POST API to update the inventory.
