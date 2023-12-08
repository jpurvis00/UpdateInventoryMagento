
using Magento2ConnectorLibrary.Models;
using UpdateInventoryMagentoUI.Models;

public static class CheckForInventoryUpdates
{
    public static MagentoSourceItemsModel CheckIfInventoryNeedsToBeUpdated(List<InventoryModel> allOmegaCubeInventory, ApiResponseModel allMagentoInventory)
    {
        MagentoSourceItemsModel updateMagentoInventory = new MagentoSourceItemsModel();

        foreach (var ocInv in allOmegaCubeInventory)
        {
            foreach (var magInv in allMagentoInventory.Items)
            {
                if (string.Equals(magInv.Sku, ocInv.Sku, StringComparison.OrdinalIgnoreCase) && ocInv.Quantity != magInv.Quantity)
                {
                    Console.WriteLine($"oc sku: {ocInv.Sku}: qty: {ocInv.Quantity}    mag sku: {magInv.Sku}: qty: {magInv.Quantity}");

                    ItemModel itemSku = new ItemModel();
                    itemSku.Sku = magInv.Sku;
                    itemSku.Quantity = ocInv.Quantity;
                    itemSku.Source_Code = magInv.Source_Code;
                    itemSku.Status = magInv.Status;

                    updateMagentoInventory.SourceItems.Add(itemSku);
                }
            }
        }

        return updateMagentoInventory;
    }
}