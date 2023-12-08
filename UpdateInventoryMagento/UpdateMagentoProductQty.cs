
using Magento2ConnectorLibrary;
using Magento2ConnectorLibrary.Models;

public static class UpdateMagentoProductQty
{
    public static void UpdateProductQty(MagentoSourceItemsModel updateFollowingInventoryItems, string url, string token)
    {
        var magento = new UpdateInventoryQuantity(url, token);

        var result = magento.UpdateProductQty(updateFollowingInventoryItems, token);

        if (result == false)
        {
            Console.WriteLine("There was a problem updating the magento inventory.");
        }
    }
 }